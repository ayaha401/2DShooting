using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State;

namespace Enemy
{
    public class EnemyStateMachine : StateMachineBase
    {
        public IdleState idle;
        public MoveState move;
        public ShotState shot;
        public DieState die;

        public EnemyStateMachine(EnemyController enemyController)
        {
            idle = new IdleState(enemyController);
            move = new MoveState(enemyController);
            shot = enemyController.gameObject.GetComponent<ShotState>();
            die = enemyController.gameObject.GetComponent<DieState>();
        }
    }
}
