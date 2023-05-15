﻿using Assets.CodeBase.App.StateMachine;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.App
{
    public class EntryPoint : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;

        [Inject]
        public void Contructor(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        private void Start()
        {
            _gameStateMachine.Enter<LoadStaticDataState>();
        }
    }
}
