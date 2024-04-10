using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks.Client.Networking
{
    public enum MessageTypeEnum : byte
    {
        CONCERT_NAME = 0x00,
        SET_DATA = 0x01,
        CURRENT_SONG = 0x02,
        CLICK_INFO = 0x03,
        CHAT_MESSAGE = 0x04,
        LIGHT_MESSAGE = 0x05
    }
}