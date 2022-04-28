using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name)
        : base(name)
        {
            this.Power = 100;
        }
        public override string CastAbility()
        {
            return $"{base.CastAbility()} hit for {this.Power} damage";
        }
    }
}
