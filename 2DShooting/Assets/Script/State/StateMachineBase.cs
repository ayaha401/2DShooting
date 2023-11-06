using System;

namespace State
{
    public class StateMachineBase
    {
        public IState CurrentState { get; set; }

        public event Action<IState> stateChanged;

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="state">ステート</param>
        public void Initialize(IState state)
        {
            CurrentState = state;
            state.Enter();

            stateChanged?.Invoke(state);
        }

        /// <summary>
        /// ステートを変更する
        /// </summary>
        /// <param name="nextState">次のステート</param>
        public void TransitionTo(IState nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();

            stateChanged?.Invoke(nextState);
        }

        /// <summary>
        /// ステートのUpdateを動かす
        /// </summary>
        public void Update()
        {
            if (CurrentState != null)
            {
                CurrentState.Update();
            }
        }
    }
}
