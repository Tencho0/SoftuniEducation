namespace T04.BorderControl
{
    using Contracts;

    public abstract class PartOfSociety : IIdentifiable
    {
        public PartOfSociety(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
