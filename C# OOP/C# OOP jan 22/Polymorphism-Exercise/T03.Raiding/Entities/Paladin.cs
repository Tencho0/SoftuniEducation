using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name)
        : base(name)
        {
            this.Power = 100;
        }
        public override string CastAbility()
        {
            return $"{base.CastAbility()} healed for {this.Power}";
        }
    }
}
