using Utility;

namespace Player
{
    public class PlayerCore : IMoveable, IShotable
    {
        private float moveSpeed = 0.05f;
        float IMoveable.MoveSpeed => moveSpeed;

        private float shotInterval = 0.1f;
        float IShotable.ShotInterval => shotInterval;

        public PlayerCore()
        {
            Locator<IMoveable>.Bind(this);
            Locator<IShotable>.Bind(this);
        }
    }
}
