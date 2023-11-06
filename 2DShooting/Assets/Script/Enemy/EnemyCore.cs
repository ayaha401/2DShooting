using UnityEngine;
using System;
using Utility;

namespace Enemy
{
    public class EnemyCore : IMoveable, IShotable
    {
        public event Action<int> hpChangeCallback;
        public readonly int maxHp = 100;
        private int hp;
        public int HP { 
            get => hp; 
            set => ClampHP(value);
        }

        private float moveSpeed = 0.05f;
        public float MoveSpeed => moveSpeed;

        private float moveDist = 5f;
        public float MoveDist => moveDist;

        private float shotInterval = 0.2f;
        public float ShotInterval => shotInterval;

        public EnemyCore()
        {
            hp = maxHp;
            Locator<IMoveable>.Bind(this);
            Locator<IShotable>.Bind(this);
        }

        /// <summary>
        /// HP‚ðƒNƒ‰ƒ“ƒv‚·‚é
        /// </summary>
        private int ClampHP(int value)
        {
            hp = value;
            hpChangeCallback?.Invoke(hp);
            return hp = (int)Mathf.Clamp(hp, 0f, maxHp);
        }
    }
}
