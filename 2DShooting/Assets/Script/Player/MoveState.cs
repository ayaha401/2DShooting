using UnityEngine;
using State;
using Utility;

namespace Player
{
    public class MoveState : IState
    {
        private PlayerController player;
        private IMoveable moveable;
        private Transform transform;

        public MoveState(PlayerController player)
        {
            this.player = player;
            moveable = Locator<IMoveable>.GetT();
        }

        void IState.Enter()
        {
            transform = player.GetComponent<Transform>();
        }

        void IState.Update()
        {
            bool isNotMove = player.MoveDir.sqrMagnitude <= float.Epsilon;
            if (isNotMove)
            {
                player.PlayerStateMachine.TransitionTo(player.GetState(PlayerState.Idol));
            }

            if (player.IsShot)
            {
                player.PlayerStateMachine.TransitionTo(player.GetState(PlayerState.Shot));
            }

            Move(player.MoveDir);
        }

        void IState.Exit()
        {
        }

        /// <summary>
        /// “ü—Í•ûŒü‚ÉˆÚ“®‚·‚é
        /// </summary>
        /// <param name="moveDir">ˆÚ“®•ûŒü</param>
        private void Move(Vector2 moveDir)
        {
            moveDir *= moveable.MoveSpeed;
            Vector2 pos = transform.position;
            pos.x += moveDir.x;
            pos.y += moveDir.y;
            transform.position = pos;
        }
    }
}