using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State;

namespace Player
{
    public class PlayerStateMachine : StateMachineBase
    {
        public IdleState idle;
        public MoveState move;
        public ShotState shot;

        public PlayerStateMachine(PlayerController playerController)
        {
            idle = new IdleState(playerController);
            move = new MoveState(playerController);
            shot = playerController.gameObject.GetComponent<ShotState>();
        }
    }
}
