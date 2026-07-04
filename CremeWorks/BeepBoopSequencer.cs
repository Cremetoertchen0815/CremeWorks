using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks.App;

public sealed class BeepBoopSequencer : IDisposable
{
    private readonly WasapiOut output;
    private readonly BufferedWaveProvider buffer;

    private readonly byte[] accentClick;
    private readonly byte[] normalClick;

    public BeepBoopSequencer()
    {
        var format = new WaveFormat(44100, 16, 1);

        buffer = new BufferedWaveProvider(format)
        {
            DiscardOnBufferOverflow = true,
            BufferLength = format.AverageBytesPerSecond * 2
        };

        output = new WasapiOut(AudioClientShareMode.Shared, true, 10);

        output.Init(buffer);
        output.Play();

        normalClick = CreateClick(format, 1000, 0.015);
        accentClick = CreateClick(format, 1800, 0.020);
    }

    public void Click(bool accent)
    {
        var click = accent ? accentClick : normalClick;
        if (buffer.BufferedBytes < buffer.BufferLength - click.Length)
            buffer.AddSamples(click, 0, click.Length);
    }

    private static byte[] CreateClick(
        WaveFormat format,
        double frequency,
        double durationSeconds)
    {
        int sampleCount = (int)(format.SampleRate * durationSeconds);

        byte[] pcm = new byte[sampleCount * 2];

        for (int i = 0; i < sampleCount; i++)
        {
            double envelope = 1.0 - (double)i / sampleCount;

            short sample = (short)(
                Math.Sin(2 * Math.PI * frequency * i / format.SampleRate)
                * envelope
                * short.MaxValue
                * 0.8);

            pcm[i * 2] = (byte)(sample & 0xff);
            pcm[i * 2 + 1] = (byte)(sample >> 8);
        }

        return pcm;
    }

    public void Dispose()
    {
        output?.Dispose();
    }
}