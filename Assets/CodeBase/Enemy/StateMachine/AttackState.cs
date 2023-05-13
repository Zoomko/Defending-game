using System;
using UnityEngine;

namespace Assets.CodeBase.Enemy.StateMachine
{
    public class AttackState : IEnemyState
    {
        private EnemyStateMachine _enemyStateMachine;
        private EnemyStateMachineParameters _parameters;
     
        private float _timeToReload;
        private float _timeToPrepair;

        private bool _isReloading;
        private bool _isPrepairing;

        public AttackState(EnemyStateMachine enemyStateMachine, EnemyStateMachineParameters parameters)
        {
            _enemyStateMachine = enemyStateMachine;
            _parameters = parameters;
        }

        public void Enter()
        {
            _parameters.Agent.speed = 0f;

            _isPrepairing = true;
            _isReloading = false;

            _timeToPrepair = Time.time + _parameters.Characteristics.TimeToPrepaiarForAttack;
        }

        public void Exit()
        {
            _parameters.Agent.speed = _parameters.Characteristics.MovementSpeed;            
        }

        public void Tick()
        {
            if (GetDistanceToTarget() > _parameters.Characteristics.RangeOfAttack && !_isPrepairing)
            {
                _enemyStateMachine.Enter<FollowState>();
            }

            if (Time.time > _timeToPrepair && _isPrepairing)
            {
                _parameters.AttackController.Attack();

                _timeToReload = Time.time + (1f/_parameters.Characteristics.AttackPerSecond);
                _isPrepairing = false;
                _isReloading = true;
            }
            else if(Time.time >  _timeToReload && _isReloading)
            {
                _timeToPrepair = Time.time + _parameters.Characteristics.TimeToPrepaiarForAttack;
                _isPrepairing = true;
                _isReloading = false;
            }
        }

        private float GetDistanceToTarget()
            => Vector3.Distance(_parameters.SelfTransform.position, _parameters.Target.position);
    }
}
