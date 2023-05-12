using System;
using UnityEngine;

namespace Assets.CodeBase.Enemy.StateMachine
{
    public class AttackState : IEnemyState
    {
        private EnemyStateMachine _enemyStateMachine;
        private EnemyStateMachineParameters _parameters;

        public AttackState(EnemyStateMachine enemyStateMachine, EnemyStateMachineParameters parameters)
        {
            _enemyStateMachine = enemyStateMachine;
            _parameters = parameters;
        }

        public void Enter()
        {
            _parameters.Agent.speed = 0f;
        }

        public void Exit()
        {
            _parameters.Agent.speed = _parameters.Characteristics.MovementSpeed;
        }

        public void Tick()
        {
            if (GetDistanceToTarget() > _parameters.Characteristics.RangeOfAttack)
            {
                _enemyStateMachine.Enter<FollowState>();
            }
        }
        private float GetDistanceToTarget()
            => Vector3.Distance(_parameters.SelfTransform.position, _parameters.Target.position);
    }
}
