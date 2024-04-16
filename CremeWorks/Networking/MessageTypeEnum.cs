namespace CremeWorks.Networking
{
    public enum MessageTypeEnum : byte
    {
        CONCERT_NAME = 0x01,
        SET_DATA = 0x02,
        CURRENT_SONG = 0x03,
        CUE_INDEX = 0x04,
        CLICK_INFO = 0x05,
        CHAT_MESSAGE = 0x06,
        LIGHT_MESSAGE = 0x07
    }
}