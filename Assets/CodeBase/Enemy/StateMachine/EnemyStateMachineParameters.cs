using Assets.CodeBase.Data.StaticData.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Enemy.StateMachine
{
    public class EnemyStateMachineParameters
    {
        public Transform Target;
        public EnemyCharacteristics Characteristics;
        public Transform Player;
        public Transform Crystal;
        public NavMeshAgent Agent;
        public Transform SelfTransform;
    }
}
