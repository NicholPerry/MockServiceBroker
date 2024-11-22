namespace ModbusMockService.Models.Signals
{
    public class BoolSignal : Signal
    {
        public int Bit { get; private set; }
        public bool CurrentValue { get; set; }

        public BoolSignal(SignalName signalName, int word, int byteNum, int bit, string note)
            : base(signalName, SignalType.Bool, word, byteNum, note)
        {
            Bit = bit;
        }
    }
}
