
namespace _07.Military_Elite.Contracts
{
    public interface IMission
    {
        public string CodeName { get; }

        public string State { get; }

        void CompleteMission();
    }
}
