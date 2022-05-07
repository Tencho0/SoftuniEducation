namespace T01.Logger
{
    public interface ILogFile
    {
        void Write(string message);
        int Size { get; }

    }
}