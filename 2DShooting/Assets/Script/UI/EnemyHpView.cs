using UnityEngine;
using UnityEngine.UI;

namespace UI.Enemy
{
    public class EnemyHpView : MonoBehaviour
    {
        [SerializeField]
        private Slider hpSlider;

        private int maxHp;

        /// <summary>
        /// HPバーを初期化する
        /// </summary>
        /// <param name="hp">HPの量</param>
        /// <param name="maxHp">最大HP</param>
        public void Init(int hp, int maxHp)
        {
            this.maxHp = maxHp;
            hpSlider.value = (float)hp / (float)this.maxHp;
        }

        /// <summary>
        /// HPの量を変更する
        /// </summary>
        /// <param name="hp">HPの量</param>
        public void ChangeHP(int hp)
        {
            hpSlider.value = (float)hp / (float)maxHp;
        }
    }
}

