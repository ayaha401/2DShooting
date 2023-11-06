using UnityEngine;
using State;
using Utility;

namespace Enemy
{
    public class MoveState : IState
    {
        private EnemyController enemy;
        private Transform transform;
        private Vector2 startPos = new Vector2();
        private Vector2 dir = Vector2.right;
        private IMoveable moveable;

        public MoveState(EnemyController enemy)
        {
            this.enemy = enemy;
            transform = enemy.GetComponent<Transform>();

            startPos = transform.position;

            moveable = Locator<IMoveable>.GetT();
        }

        void IState.Enter()
        {
        }

        void IState.Update()
        {
            if(Vector2.Distance(startPos, transform.position) >= moveable.MoveDist)
            {
                dir = dir == Vector2.right ? Vector2.left : Vector2.right;
                enemy.EnemyStateMachine.TransitionTo(enemy.GetState(EnemyState.Shot));
            }
            Move(dir);
        }

        void IState.Exit()
        {
        }

        /// <summary>
        /// ¶‰E‚ÉˆÚ“®‚·‚é
        /// </summary>
        /// <param name="dir">¡‰ñ‚ÌˆÚ“®•ûŒü</param>
        private void Move(Vector2 dir)
        {
            Vector2 pos = transform.position;
            pos += dir * moveable.MoveSpeed;
            transform.position = pos;
        }
    }
}
