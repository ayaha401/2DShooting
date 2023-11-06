using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State;

namespace Player
{
    public class IdleState : IState
    {
        private PlayerController player;

        public IdleState(PlayerController player)
        {
            this.player = player;
        }

        void IState.Enter()
        {
        }

        void IState.Update()
        {
            bool isMove = player.MoveDir.sqrMagnitude != 0;
            if(isMove)
            {
                player.PlayerStateMachine.TransitionTo(player.GetState(PlayerState.Move));
            }

            if(player.IsShot)
            {
                player.PlayerStateMachine.TransitionTo(player.GetState(PlayerState.Shot));
            }
        }

        void IState.Exit()
        {
        }
    }
}
