using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Data.StaticData.Enemy;

namespace Assets.CodeBase.Services
{
    public interface IStaticDataService
    {
        PlayerStaticData PlayerStaticData { get; }
        EnemiesStaticData EnemiesStaticData { get; }
        Waves WavesStaticData { get; }

        BulletsStaticData BulletsStaticData { get; }
        GameStaticData GameStaticData { get; }
        void Load();
    }
}