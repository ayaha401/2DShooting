using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using Enemy;

namespace UI.Enemy
{
    public class EnemyHpPresenter : MonoBehaviour
    {
        [SerializeField]
        private EnemyHpView view;

        private EnemyCore core;

        private void Start()
        {
            core = Locator<EnemyCore>.GetT();

            core.hpChangeCallback += view.ChangeHP;

            view.Init(core.HP, core.maxHp);
        }
    }
}
