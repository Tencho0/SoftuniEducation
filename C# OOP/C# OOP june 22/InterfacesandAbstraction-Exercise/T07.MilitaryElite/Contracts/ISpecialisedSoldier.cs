namespace T07.MilitaryElite.Contracts
{
    using Enums;
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
