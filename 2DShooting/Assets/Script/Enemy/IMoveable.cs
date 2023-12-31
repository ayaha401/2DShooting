namespace Enemy
{
    public interface IMoveable
    {
        /// <summary>
        /// 移動速度
        /// </summary>
        public float MoveSpeed { get; }

        /// <summary>
        /// 移動距離
        /// </summary>
        public float MoveDist { get; }
    }
}