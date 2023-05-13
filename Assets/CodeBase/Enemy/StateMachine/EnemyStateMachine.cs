using Assets.CodeBase.Data.StaticData.Enemy;
using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Enemy.StateMachine
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyStateMachine : MonoBehaviour
    {
        private EnemyTypeHolder _enemyTypeHolder;

        private EnemyCharacteristics _enemyCharacteristics;
        private Transform _player;
        private Transform _crystal;
        private NavMeshAgent _agent;
        private IAttackController _attackController;



        private Dictionary<Type, IEnemyState> _states;
        private IEnemyState _currentState;

        public void Contructor(EnemyCharacteristics enemyCharacteristics , Transform player, Transform crystal, IAttackController attackController)
        {
            _enemyCharacteristics = enemyCharacteristics;
            _player = player;
            _crystal = crystal;
            _attackController = attackController;
        }

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _enemyTypeHolder = GetComponent<EnemyTypeHolder>();
        }

        private void Start()
        {
            EnemyStateMachineParameters parameters = InitializeParameters();
            InitializeAgent();

            _states = new Dictionary<Type, IEnemyState>()
            {
                {typeof(FollowState), new FollowState(this, parameters) },
                {typeof(AttackState), new AttackState(this, parameters) }
            };

            Enter<FollowState>();
        }

        private void InitializeAgent()
        {
            _agent.speed = _enemyCharacteristics.MovementSpeed;
            _agent.angularSpeed = _enemyCharacteristics.RotationSpeed;
        }

        private EnemyStateMachineParameters InitializeParameters()
        {
            EnemyStateMachineParameters parameters = new EnemyStateMachineParameters();
            parameters.Characteristics = _enemyCharacteristics;
            parameters.Player = _player;
            parameters.Crystal = _crystal;
            parameters.SelfTransform = transform;
            parameters.Agent = _agent;
            parameters.AttackController = _attackController;
            return parameters;
        }

        private void Update()
        {
            _currentState.Tick();
        }

        public void Enter<T>() where T : IEnemyState
        {
            if (!_states.ContainsKey(typeof(T)))
                throw new KeyNotFoundException();

            if (_currentState == null)
            {
                var state = _states[typeof(T)];
                _currentState = state;
                state.Enter();
            }
            else
            {
                _currentState.Exit();
                var state = _states[typeof(T)];
                _currentState = state;
                state.Enter();
            }
        }

    }
}
