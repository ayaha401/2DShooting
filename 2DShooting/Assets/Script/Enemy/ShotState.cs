using UnityEngine;
using State;
using Utility;

namespace Enemy
{
    public class ShotState : MonoBehaviour, IState
    {
        [SerializeField]
        private GameObject shotObj;

        [SerializeField]
        private Vector2 shotOffset;

        private EnemyController enemy;
        private IShotable shotable;
        private float stateChangeTimer = 0.0f;
        private float stateChangeInterval = 1.0f;
        private float shotTimer = float.MaxValue;
        private float exitTime = 0.0f;

        private void Awake()
        {
            enemy = GetComponent<EnemyController>();
        }

        private void Start()
        {
            shotable = Locator<IShotable>.GetT();
        }

        void IState.Enter()
        {
            if (Time.time - exitTime >= shotable.ShotInterval)
            {
                shotTimer = float.MaxValue;
            }
        }

        void IState.Update()
        {
            stateChangeTimer += Time.deltaTime;
            if(stateChangeTimer >= stateChangeInterval)
            {
                stateChangeTimer = 0.0f;
                enemy.EnemyStateMachine.TransitionTo(enemy.GetState(EnemyState.Move));
            }

            Shot();
        }

        void IState.Exit()
        {
        }

        /// <summary>
        /// íeÇèoÇ∑
        /// </summary>
        private void Shot()
        {
            bool isShot = shotTimer >= shotable.ShotInterval;
            if (isShot)
            {
                Instantiate(shotObj, transform.position + (Vector3)shotOffset, transform.rotation);
                shotTimer = 0.0f;
            }
            shotTimer += Time.deltaTime;
        }
    }

}
