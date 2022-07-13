namespace T08.CollectionHierarchy.Models.Interfaces
{
    public interface IMyList<T> : IAddRemoveCollection<T>
    {
        int Used { get; }
    }
}
