namespace CommandPattern.IO.Contracts
{
    public interface IWriter
    {
        void Write(string givenValue);
        void WriteLine(string givenValue);
        void ResetStyle();
    }
}
