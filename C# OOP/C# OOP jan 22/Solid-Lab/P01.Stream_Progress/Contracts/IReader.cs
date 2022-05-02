namespace P01.Stream_Progress
{
    public interface IReader
    {
        int Length { get; set; }

        int BytesSent { get; set; }
    }
}
