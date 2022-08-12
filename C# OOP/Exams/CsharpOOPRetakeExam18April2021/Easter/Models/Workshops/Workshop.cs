namespace Easter.Models.Workshops
{
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Eggs.Contracts;
    using Easter.Models.Workshops.Contracts;
    using System.Linq;

    public class Workshop : IWorkshop
    {
        public Workshop()
        {
        }

        public void Color(IEgg egg, IBunny bunny)
        {
            foreach (var dye in bunny.Dyes.Where(x => !x.IsFinished()))
            {
                while (!dye.IsFinished())
                {
                    bunny.Work();
                    dye.Use();
                    egg.GetColored();

                    if (egg.IsDone())
                        break;
                }

                if (egg.IsDone())
                    break;
                if (bunny.Energy == 0)
                    break;
            }
        }
    }
}
