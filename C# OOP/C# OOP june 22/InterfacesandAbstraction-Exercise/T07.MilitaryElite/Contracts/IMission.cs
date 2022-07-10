namespace T07.MilitaryElite.Contracts
{
    using Enums;
    public interface IMission
    {
        public string CodeName { get; set; }
        public State State { get; set; }
        public void CompleteMission();
    }
}
