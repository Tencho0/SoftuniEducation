namespace T03.Raiding.Model
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public abstract int Power { get; }
        public abstract string CastAbility();
    }
}
