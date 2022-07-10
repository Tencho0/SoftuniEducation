namespace T07.MilitaryElite.Contracts
{
    using System.Collections.Generic;
    public interface ILieutenantGeneral : IPrivate
    {
        public Dictionary<int, IPrivate> Privates { get; set; }
    }
}
