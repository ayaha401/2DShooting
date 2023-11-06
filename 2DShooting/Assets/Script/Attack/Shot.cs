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
        /// �����Ă�����ɒ��i��������
        /// </summary>
        private void Move()
        {
            Vector2 moveDir = transform.up;
            Vector2 pos = transform.position;
            pos += moveDir * moveSpeed;
            transform.position = pos;
        }

        /// <summary>
        /// �e�����ł��邽�߂̏���
        /// </summary>
        private IEnumerator CountLifeTime()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(this.gameObject);
        }
    }
}
