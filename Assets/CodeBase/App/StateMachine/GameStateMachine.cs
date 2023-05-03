using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.App.StateMachine
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _currentState;
        public GameStateMachine()
        {
            _states= new Dictionary<Type, IState>();
        }

        public void Enter<T>() where T : INoneParameterizedState
        {
            if(!_states.ContainsKey(typeof(T)))
                throw new KeyNotFoundException();

            if (_currentState == null)
            {
                var state = _states[typeof(T)] as INoneParameterizedState;
                _currentState = state;
                state.Enter();
            }
            else
            {
                _currentState.Exit();
                var state = _states[typeof(T)] as INoneParameterizedState;
                _currentState = state;
                state.Enter();
            }                
        }

        public void Enter<T1,T2>(T2 data) where T1 : IParameterizedState
        {
            if (!_states.ContainsKey(typeof(T1)))
                throw new KeyNotFoundException();
            if (_currentState == null)
            {
                var state = _states[typeof(T1)] as IParameterizedState;
                _currentState = state;
                state.Enter(data);
            }
            else
            {
                _currentState.Exit();
                var state = _states[typeof(T1)] as IParameterizedState;
                _currentState = state;
                state.Enter(data);
            }
        }
    }
}
