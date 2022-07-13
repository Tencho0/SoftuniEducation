namespace T08.CollectionHierarchy.Models.Interfaces
{
    public interface IAddRemoveCollection<T> : IAddCollection<T>
    {
        T Remove();
    }
}
