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
        /// HPƒo[‚ğ‰Šú‰»‚·‚é
        /// </summary>
        /// <param name="hp">HP‚Ì—Ê</param>
        /// <param name="maxHp">Å‘åHP</param>
        public void Init(int hp, int maxHp)
        {
            this.maxHp = maxHp;
            hpSlider.value = (float)hp / (float)this.maxHp;
        }

        /// <summary>
        /// HP‚Ì—Ê‚ğ•ÏX‚·‚é
        /// </summary>
        /// <param name="hp">HP‚Ì—Ê</param>
        public void ChangeHP(int hp)
        {
            hpSlider.value = (float)hp / (float)maxHp;
        }
    }
}

