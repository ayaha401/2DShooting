using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State;

namespace Enemy
{
    public class IdleState : IState
    {
        private EnemyController enemy;

        public IdleState(EnemyController enemy)
        {
            this.enemy = enemy;
        }

        void IState.Enter()
        {
        }

        void IState.Update()
        {
        }

        void IState.Exit()
        {
        }
    }
}
