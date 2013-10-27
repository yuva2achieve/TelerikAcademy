namespace Twitter.Controls
{
    using System;

    public static class Verificator
    {
        private const int MessageMaxLength = 200;
        private const int MessageMinLength = 3;
        private const int ChannelMaxLength = 100;
        private const int ChannelMinLength = 5;

        public static void ValidateMessage(string inputMessage)
        {
            inputMessage = inputMessage.Trim();

            if (String.IsNullOrWhiteSpace(inputMessage) || String.IsNullOrEmpty(inputMessage))
            {
                throw new ArgumentNullException("Message should not be empty.");
            }
            if (inputMessage.Length < MessageMinLength || inputMessage.Length > MessageMaxLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Message should be at least {0} symbols and maximum {1} symbols.",
                        MessageMinLength, MessageMaxLength));
            }
        }

        public static void ValidateChannel(string inputChannelName)
        {
            inputChannelName = inputChannelName.Trim(); 

            if (String.IsNullOrWhiteSpace(inputChannelName) || String.IsNullOrEmpty(inputChannelName))
            {
                throw new ArgumentNullException("Channel name should not be empty.");
            }
            if (inputChannelName.Length < ChannelMinLength || inputChannelName.Length > ChannelMaxLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Channel name should be at least {0} symbols and maximum {1} symbols.",
                        ChannelMinLength, ChannelMaxLength));
            }
        }
    }
}