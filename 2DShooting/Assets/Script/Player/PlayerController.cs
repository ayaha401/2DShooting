using UnityEngine;
using State;
using Utility;
using MyInput;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerCore core;
        private PlayerInput playerInput;
        
        private PlayerStateMachine playerStateMachine;
        public PlayerStateMachine PlayerStateMachine => playerStateMachine;

        private Vector2 moveDir = Vector2.zero;
        public Vector2 MoveDir => moveDir;
        private bool isShot = false;
        public bool IsShot => isShot;

        private void Awake()
        {
            core = new PlayerCore();
            Locator<PlayerCore>.Bind(core);

            playerInput = Locator<PlayerInput>.GetT();

            playerStateMachine = new PlayerStateMachine(this);
        }

        void Start()
        {
            playerStateMachine.Initialize(playerStateMachine.idle);
        }

        void Update()
        {
            PlayerInput();
            playerStateMachine.Update();
        }

        /// <summary>
        /// コントローラーからの入力
        /// </summary>
        private void PlayerInput()
        {
            moveDir = playerInput.CheckMoveDirInput();
            isShot = playerInput.CheckShotInput();
        }

        public IState GetState(PlayerState state)
        {
            switch (state)
            {
                case PlayerState.Idol:
                    return playerStateMachine.idle;
                case PlayerState.Move:
                    return playerStateMachine.move;
                case PlayerState.Shot:
                    return playerStateMachine.shot;
                default:
                    return null;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            bool hasAttackable = collision.gameObject.GetComponent<Attack.IAttackable>() != null;
            bool isEnemyShot = collision.gameObject.GetComponent<Attack.Shot>().AttackerKind == AttackerKinds.Enemy;
            if (hasAttackable && isEnemyShot)
            {
            }
        }

        private void OnDestroy()
        {
            Locator<PlayerCore>.UnBind();
        }
    }
}
