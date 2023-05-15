using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Data.StaticData.Enemy;
using UnityEngine.UIElements;

namespace Assets.CodeBase.Services
{
    public interface IStaticDataService
    {
        PlayerStaticData PlayerStaticData { get; }
        EnemiesStaticData EnemiesStaticData { get; }
        Waves WavesStaticData { get; }

        BulletsStaticData BulletsStaticData { get; }
        GameStaticData GameStaticData { get; }
        VisualTreeAsset HUD { get; }
        PanelSettings UIPanelSettings { get; }
        void Load();
    }
}