namespace Assets.CodeBase.Services
{
    public interface IStaticDataService
    {
        PlayerStaticData PlayerStaticData { get; }

        void Load();
    }
}