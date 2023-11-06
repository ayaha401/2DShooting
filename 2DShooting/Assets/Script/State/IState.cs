namespace State
{
    public interface IState
    {
        /// <summary>
        /// ステートに入った時の処理
        /// </summary>
        public void Enter();

        /// <summary>
        /// 毎フレームやる処理
        /// </summary>
        public void Update();

        /// <summary>
        /// ステート終わるときの処理
        /// </summary>
        public void Exit();
    }

}
