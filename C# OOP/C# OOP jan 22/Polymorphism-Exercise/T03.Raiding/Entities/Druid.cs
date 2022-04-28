using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string name)
        : base(name)
        {
            this.Power = 80;
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} healed for {this.Power}";
        }
    }
}
