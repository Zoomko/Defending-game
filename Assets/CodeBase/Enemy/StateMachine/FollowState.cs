using System;
using UnityEngine;

namespace Assets.CodeBase.Enemy.StateMachine
{
    public class FollowState : IEnemyState
    {
        private EnemyStateMachine _enemyStateMachine;
        private EnemyStateMachineParameters _parameters;

        public FollowState(EnemyStateMachine enemyStateMachine, EnemyStateMachineParameters parameters)
        {
            _enemyStateMachine = enemyStateMachine;
            _parameters = parameters;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }

        public void Tick()
        {
            ChangeTargetIfItCloser();
            if(GetDistanceToTarget() < _parameters.Characteristics.RangeOfAttack)
            {
                _enemyStateMachine.Enter<AttackState>();
            }
        }
        private void ChangeTargetIfItCloser()
        {
            float distanceToPlayer = GetDistanceToPlayer();
            float distanceToCrystal = GetDistanceToCrystal();
            if(distanceToPlayer < distanceToCrystal)
            {
                _parameters.Target = _parameters.Player;
            }
            else
            {
                _parameters.Target = _parameters.Crystal;
            }
            _parameters.Agent.destination = _parameters.Target.position;
        }

        private float GetDistanceToCrystal() 
            => Vector3.Distance(_parameters.SelfTransform.position, _parameters.Crystal.position);

        private float GetDistanceToPlayer() 
            => Vector3.Distance(_parameters.SelfTransform.position, _parameters.Player.position);

        private float GetDistanceToTarget()
            => Vector3.Distance(_parameters.SelfTransform.position, _parameters.Target.position);

    }
}
