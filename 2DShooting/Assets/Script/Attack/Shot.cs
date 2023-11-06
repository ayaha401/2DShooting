using System.Collections;
using UnityEngine;

namespace Attack
{
    public class Shot : MonoBehaviour, IAttackable
    {
        [SerializeField]
        private float moveSpeed = 0.05f;

        [SerializeField]
        private float lifeTime = 0.5f;

        [SerializeField]
        private int damage = 10;
        public int Damage => damage;
        
        [SerializeField]
        private AttackerKinds attackerKind = AttackerKinds.None;
        public AttackerKinds AttackerKind => attackerKind;

        private void Start()
        {
            StartCoroutine(CountLifeTime());
        }

        void Update()
        {
            Move();
        }

        /// <summary>
        /// Œü‚¢‚Ä‚é•ûŒü‚É’¼i‚µ‘±‚¯‚é
        /// </summary>
        private void Move()
        {
            Vector2 moveDir = transform.up;
            Vector2 pos = transform.position;
            pos += moveDir * moveSpeed;
            transform.position = pos;
        }

        /// <summary>
        /// ’e‚ª©–Å‚·‚é‚½‚ß‚Ìˆ—
        /// </summary>
        private IEnumerator CountLifeTime()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(this.gameObject);
        }
    }
}
