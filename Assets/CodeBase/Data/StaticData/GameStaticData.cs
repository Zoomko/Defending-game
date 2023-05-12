using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Data.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Game", fileName = "GameStaticData")]
    public class GameStaticData : ScriptableObject
    {
        public GameObject Crystal;
    }
}
