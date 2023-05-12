using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.Enemy.StateMachine
{
    public interface IEnemyState
    {
        void Enter();

        void Tick();
        void Exit();
    }
}
