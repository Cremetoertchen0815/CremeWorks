package main

import (
	"bufio"
	"bytes"
	"fmt"
	"net"
	"os"
	"strconv"
	"strings"
	"time"

	"github.com/ebitengine/oto/v3"
	"github.com/hajimehoshi/go-mp3"
)

func main() {
	//Show title
	fmt.Print("CremeWorks v1.0 SoundPlayer\n\n")
	fmt.Println("Searching for server...")

	//Listen to UDP broadcast
	pc, err := net.ListenPacket("udp4", ":25565")
	if err != nil {
		panic("Finder port could not be opened!")
	}
	defer pc.Close()

	//Receive finder data
	buf := make([]byte, 1024)
	n, addr, err := pc.ReadFrom(buf)
	if err != nil {
		panic(err)
	}

	//Check if finder header is correct
	if string(buf[:n]) != "CremeWorks Listener v1.0" {
		panic("Broadcast header is incorrect! Header was " + string(buf[:n]))
	}
	fmt.Printf("Server found at: %s\n", addr)
	pc.Close()

	//Connect to server
	ip := strings.Split(addr.String(), ":")[0]
	client, err := net.Dial("tcp", fmt.Sprintf("%s:187", ip))
	if err != nil {
		fmt.Println("Couldn't connect to server! Error:", err)
		return
	}
	defer client.Close()

	//Start handshake
	lineBuffer := createLineBuffer()
	data, err := lineBuffer.readLine(client)
	if err != nil {
		panic(err)
	} else if data != "Welcome to CremeWorks!" {
		panic(fmt.Sprintf("Handshake failed! Message: %s", data))
	}
	client.Write([]byte("SoundPlayer\r\n"))
	fmt.Print("Connected to server!\n\n")

	// Read the mp3 file into memory
	fileBytes, err := os.ReadFile("./kick.mp3")
	if err != nil {
		panic("Click file could not be opened!")
	}

	// Convert the pure bytes into a reader object that can be used with the mp3 decoder
	fileBytesReader := bytes.NewReader(fileBytes)

	// Decode file
	decodedMp3, err := mp3.NewDecoder(fileBytesReader)
	if err != nil {
		panic("mp3.NewDecoder failed: " + err.Error())
	}

	// Prepare an Oto context (this will use your default audio device) that will
	// play all our sounds. Its configuration can't be changed later.

	op := &oto.NewContextOptions{}

	// Usually 44100 or 48000. Other values might cause distortions in Oto
	op.SampleRate = 44100

	// Number of channels (aka locations) to play sounds from. Either 1 or 2.
	// 1 is mono sound, and 2 is stereo (most speakers are stereo).
	op.ChannelCount = 2

	// Format of the source. go-mp3's format is signed 16bit integers.
	op.Format = oto.FormatSignedInt16LE

	// Remember that you should **not** create more than one context
	otoCtx, readyChan, err := oto.NewContext(op)
	if err != nil {
		panic("oto.NewContext failed: " + err.Error())
	}
	// It might take a bit for the hardware audio devices to be ready, so we wait on the channel.
	<-readyChan

	// Create a new 'player' that will handle our sound. Paused by default.
	player := otoCtx.NewPlayer(decodedMp3)

	// Start metronome timer
	t := time.NewTicker(time.Second)
	t.Stop()

	//Start metronome loop
	go func() {
		for range t.C {
			player.Seek(0, 0)
			player.Play()
		}
	}()

	//Start chat loop
	go func() {
		for {
			reader := bufio.NewReader(os.Stdin)
			text, _ := reader.ReadString('\n')
			text = strings.Replace(text, "\n", "", -1)
			text = strings.Replace(text, "\r", "", -1)

			if text != "" {
				client.Write([]byte(fmt.Sprintf("6\r\n%s\r\n", text)))
			}
		}
	}()

	for {
		data, err := lineBuffer.readLine(client)
		//Receive instruction data
		if err != nil {
			fmt.Printf("Stream interrupted, couldn't receive instruction! Error: %e", err)
			break
		}

		messageType, err := strconv.Atoi(data)
		if err != nil {
			fmt.Printf("Illegal instruction! Error: %e\n", err)
			break
		}

		//Receive payload
		payload, err := lineBuffer.readLine(client)
		if err != nil {
			fmt.Printf("Stream interrupted, couldn't receive payload! Error: %e\n", err)
			break
		}

		switch messageType {
		case 5:
			if payload == "off" {
				t.Stop()
			} else {
				tempo, err := strconv.Atoi(payload)
				if err == nil {
					t.Reset(time.Duration(60000/tempo) * time.Millisecond)
				}
			}
		case 6:
			fmt.Println(payload)
		}
	}

	// Now that the sound finished playing, we can restart from the beginning (or go to any location in the sound) using seek
	// newPos, err := player.(io.Seeker).Seek(0, io.SeekStart)
	// if err != nil{
	//     panic("player.Seek failed: " + err.Error())
	// }
	// println("Player is now at position:", newPos)
	// player.Play()

	// If you don't want the player/sound anymore simply close
	err = player.Close()
	if err != nil {
		panic("player.Close failed: " + err.Error())
	}
}

func (parent *LineBuffer) readLine(conn net.Conn) (string, error) {
	//Dequeue item if available
	if len(parent.queue) > 0 {
		retVal := parent.queue[0]
		parent.queue = parent.queue[1:]
		return retVal, nil
	}

	//If no item is available, read data from stream
	n, err := conn.Read(parent.buffer)
	if err != nil {
		return "", err
	}

	//Return first element(split by \r\n) and add rest to queue
	str := strings.Split(string(parent.buffer[:n]), "\r\n")
	if len(str) > 1 {
		parent.queue = append(parent.queue, str[1:len(str)-1]...)
	}
	return str[0], nil
}

func createLineBuffer() LineBuffer {
	return LineBuffer{
		queue:  make([]string, 0),
		buffer: make([]byte, 1024),
	}
}

type LineBuffer struct {
	queue  []string
	buffer []byte
}
