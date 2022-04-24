namespace MilitaryElite
{
    using System.Collections.Generic;
    public interface ILieutenantGeneral : IPrivate
    {
        Dictionary<int, IPrivate> Privates { get; set; }
    }
}
