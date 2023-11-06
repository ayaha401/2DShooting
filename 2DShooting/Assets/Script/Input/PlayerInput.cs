using UnityEngine;

namespace MyInput
{
    public class PlayerInput
    {
        /// <summary>
        /// �ړ������̓���
        /// </summary>
        public Vector2 CheckMoveDirInput()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            return new Vector2(x, y).normalized;
        }

        /// <summary>
        /// �e���o�����̓���
        /// </summary>
        public bool CheckShotInput()
        {
            return Input.GetMouseButton(0);
        }
    }
}

