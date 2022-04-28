namespace Raiding
{
    public interface IBaseHero
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name}";
        }
    }
}
