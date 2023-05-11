using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Data.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Waves", fileName = "Waves")]
    public class Waves : ScriptableObject
    {
        public List<Wave> EnemyWaves;
    }
}