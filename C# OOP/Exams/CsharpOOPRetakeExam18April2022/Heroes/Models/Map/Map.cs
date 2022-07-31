namespace Heroes.Models.Map
{
    using System.Collections.Generic;
    using System.Linq;

    using global::Heroes.Models.Contracts;
    using global::Heroes.Models.Heroes;

    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            //    /*ICollection<IHero>*/
            //    var barbarians = new Queue<IHero>();
            //    /*ICollection<IHero>*/
            //    var knights = new Queue<IHero>();

            ICollection<IHero> barbarians = new List<IHero>();
            ICollection<IHero> knights = new List<IHero>();

            foreach (var player in players)
            {
                if (player is Barbarian)
                    barbarians.Add(player);
                else if (player is Knight)
                    knights.Add(player);

                //  barbarians.Enqueue(player);
                // knights.Enqueue(player);

                //barbarians.Add(player);
                //knights.Add(player);
            }

            while (barbarians.Any(x => x.IsAlive) && knights.Any(x => x.IsAlive))
            {
                // var barbarian = barbarians.Dequeue();
                // var knight = knights.Dequeue();

                var barbarian = barbarians.ToList()[0];
                var knight = knights.ToList()[0];


                if (knight.IsAlive)
                {
                    var points = knight.Weapon.DoDamage();
                    barbarian.TakeDamage(points);
                }
                else
                {
                    barbarians.Add(barbarians.ToList()[0]);
                    barbarians.Remove(barbarians.ToList()[0]);
                }

                if (barbarian.IsAlive)
                {
                    var points = barbarian.Weapon.DoDamage();
                    knight.TakeDamage(points);
                }
                else
                {
                    knights.Add(barbarians.ToList()[0]);
                    knights.Remove(barbarians.ToList()[0]);
                }

                //  barbarians.Enqueue(barbarian);
                //  knights.Enqueue(knight);
            }

            return Result(knights, barbarians);
        }

        private string Result(ICollection<IHero> knights, ICollection<IHero> barbarians)
        {
            if (!knights.Any(x => x.IsAlive))
                return $"The knights took {knights.Count(x => !x.IsAlive)} casualties but won the battle.";

            return $"The barbarians took {barbarians.Count(x => !x.IsAlive)} casualties but won the battle";

        }

        // private string Result(Queue<IHero> knights, Queue<IHero> barbarians)
        // {
        //     if (!knights.Any(x => x.IsAlive))
        //         return $"The knights took {knights.Count(x => !x.IsAlive)} casualties but won the battle.";
        //
        //     return $"The barbarians took {barbarians.Count(x => !x.IsAlive)} casualties but won the battle";
        // }
    }
}