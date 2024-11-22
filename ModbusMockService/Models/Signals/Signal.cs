namespace ModbusMockService.Models.Signals
{
    public abstract class Signal
    {
        public SignalName SignalName { get; private set; }
        public SignalType Type { get; private set; }
        public int Word { get; private set; }
        public int Byte { get; private set; }
        public string Note { get; private set; }
        public int RegisterAddress { get; private set; }

        protected Signal(SignalName signalName, SignalType type, int word, int byteNum, string note)
        {
            SignalName = signalName;
            Type = type;
            Word = word;
            Byte = byteNum;
            Note = note;
            RegisterAddress = CalculateRegisterAddress();
        }

        private int CalculateRegisterAddress()
        {
            return Word * 8 + Byte;
        }
    }
}
