namespace Enemy
{
    public interface IMoveable
    {
        /// <summary>
        /// �ړ����x
        /// </summary>
        public float MoveSpeed { get; }

        /// <summary>
        /// �ړ�����
        /// </summary>
        public float MoveDist { get; }
    }
}