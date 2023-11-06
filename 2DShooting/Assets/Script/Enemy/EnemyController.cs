using UnityEngine;
using State;
using Attack;
using Utility;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private EnemyCore core;

        private EnemyStateMachine enemyStateMachine;
        public EnemyStateMachine EnemyStateMachine => enemyStateMachine;

        private void Awake()
        {
            core = new EnemyCore();
            Locator<EnemyCore>.Bind(core);

            enemyStateMachine = new EnemyStateMachine(this);
        }

        private void Start()
        {
            enemyStateMachine.Initialize(enemyStateMachine.move);
        }

        private void Update()
        {
            enemyStateMachine.Update();
        }

        public IState GetState(EnemyState state)
        {
            switch (state)
            {
                case EnemyState.Idol:
                    return enemyStateMachine.idle;
                case EnemyState.Move:
                    return enemyStateMachine.move;
                case EnemyState.Shot:
                    return enemyStateMachine.shot;
                case EnemyState.Die:
                    return enemyStateMachine.die;
                default:
                    return null;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(enemyStateMachine.CurrentState is DieState)
            {
                return;
            }

            bool hasAttackable = collision.gameObject.GetComponent<IAttackable>() != null;
            bool isPlayerShot = collision.gameObject.GetComponent<Shot>().AttackerKind == AttackerKinds.Player;
            if (hasAttackable && isPlayerShot)
            {
                IAttackable attackable = collision.gameObject.GetComponent<IAttackable>();
                int damage = attackable.Damage;

                core.HP -= damage;
                if(core.HP == 0)
                {
                    enemyStateMachine.TransitionTo(GetState(EnemyState.Die));
                }
            }
        }
    }
}
