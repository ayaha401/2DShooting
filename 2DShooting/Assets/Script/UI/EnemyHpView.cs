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
        /// HP�o�[������������
        /// </summary>
        /// <param name="hp">HP�̗�</param>
        /// <param name="maxHp">�ő�HP</param>
        public void Init(int hp, int maxHp)
        {
            this.maxHp = maxHp;
            hpSlider.value = (float)hp / (float)this.maxHp;
        }

        /// <summary>
        /// HP�̗ʂ�ύX����
        /// </summary>
        /// <param name="hp">HP�̗�</param>
        public void ChangeHP(int hp)
        {
            hpSlider.value = (float)hp / (float)maxHp;
        }
    }
}

