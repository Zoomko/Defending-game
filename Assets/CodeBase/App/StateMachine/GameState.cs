using Assets.CodeBase.Factory;
using UnityEngine;

namespace Assets.CodeBase.App.StateMachine
{
    public class GameState : INoneParameterizedState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ICrystalFactory _crystalFactory;

        public GameState(GameStateMachine gameStateMachine,ICrystalFactory crystalFactory)
        {
            _gameStateMachine = gameStateMachine;
            _crystalFactory = crystalFactory;
        }

        public void Enter()
        {
            _crystalFactory.HasDestroyed += OnDestroy;
        }

        private void OnDestroy()
        {
            Debug.Log("Game is ended");
        }

        public void Exit()
        {
            _crystalFactory.HasDestroyed -= OnDestroy;
        }
    }
}
