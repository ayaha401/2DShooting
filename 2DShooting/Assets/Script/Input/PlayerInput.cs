using UnityEngine;

namespace MyInput
{
    public class PlayerInput
    {
        /// <summary>
        /// ˆÚ“®•ûŒü‚Ì“ü—Í
        /// </summary>
        public Vector2 CheckMoveDirInput()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            return new Vector2(x, y).normalized;
        }

        /// <summary>
        /// ’e‚ğo‚·‚Ì“ü—Í
        /// </summary>
        public bool CheckShotInput()
        {
            return Input.GetMouseButton(0);
        }
    }
}

