using UnityEngine;
using State;

namespace Enemy
{
    public class DieState : MonoBehaviour, IState
    {
        [SerializeField]
        private Color dieColor = Color.black;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void IState.Enter()
        {
            spriteRenderer.color = dieColor;
        }

        void IState.Update()
        {
        }

        void IState.Exit()
        {
        }
    }
}
