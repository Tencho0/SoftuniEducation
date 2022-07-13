namespace T09.ExplicitInterfaces
{
    public interface IResident
    {
        string Name { get; set; }
        int Age { get; set; }
        string GetName();
    }
}
