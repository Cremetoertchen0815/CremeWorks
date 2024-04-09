using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks.Client.Networking;
public enum MessageTypeEnum : byte
{
    PLAYLIST_DATA = 0x00,
    CURRENT_SONG = 0x01,
    CLICK_INFO = 0x02,
    CHAT_MESSAGE = 0x03,
    LIGHT_MESSAGE = 0x04
}
