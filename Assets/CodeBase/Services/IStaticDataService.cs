using Assets.CodeBase.Data.StaticData;

namespace Assets.CodeBase.Services
{
    public interface IStaticDataService
    {
        PlayerStaticData PlayerStaticData { get; }
        EnemiesStaticData EnemiesStaticData { get; }
        Waves WavesStaticData { get; }

        BulletsStaticData BulletsStaticData { get; }
        void Load();
    }
}