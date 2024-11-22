namespace ModbusMockService.Models.Signals
{
    public class ByteSignal : Signal
    {
        public byte CurrentValue { get; private set; }
        public ByteSignal(SignalName signalName, int word, int byteNum, string note)
            : base(signalName, SignalType.Byte, word, byteNum, note)
        {
        }
    }
}
