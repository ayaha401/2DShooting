using UnityEngine;
using State;
using Utility;

namespace Player
{
    public class ShotState : MonoBehaviour, IState
    {
        [SerializeField]
        private GameObject shotObj;

        [SerializeField]
        private Vector2 shotOffset;

        private PlayerController player;
        private IShotable shotable;
        private float shotTimer = float.MaxValue;
        private float exitTime = 0.0f;

        private void Awake()
        {
            player = GetComponent<PlayerController>();
        }

        private void Start()
        {
            shotable = Locator<IShotable>.GetT();
        }

        void IState.Enter()
        {
            if(Time.time - exitTime >= shotable.ShotInterval)
            {
                shotTimer = float.MaxValue;
            }
        }

        void IState.Update()
        {
            if (!player.IsShot)
            {
                player.PlayerStateMachine.TransitionTo(player.GetState(PlayerState.Idol));
            }

            Shot();
        }

        void IState.Exit()
        {
            exitTime = Time.time;
        }

        /// <summary>
        /// íeÇèoÇ∑
        /// </summary>
        private void Shot()
        {
            bool isShot = shotTimer >= shotable.ShotInterval;
            if(isShot)
            {
                Instantiate(shotObj, transform.position + (Vector3)shotOffset, Quaternion.identity);
                shotTimer = 0.0f;
            }
            shotTimer += Time.deltaTime;
        }
    }
}

