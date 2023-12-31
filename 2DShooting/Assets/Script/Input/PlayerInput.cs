using UnityEngine;

namespace MyInput
{
    public class PlayerInput
    {
        /// <summary>
        /// 移動方向の入力
        /// </summary>
        public Vector2 CheckMoveDirInput()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            return new Vector2(x, y).normalized;
        }

        /// <summary>
        /// 弾を出す時の入力
        /// </summary>
        public bool CheckShotInput()
        {
            return Input.GetMouseButton(0);
        }
    }
}

