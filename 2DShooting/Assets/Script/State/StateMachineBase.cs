using System;

namespace State
{
    public class StateMachineBase
    {
        public IState CurrentState { get; set; }

        public event Action<IState> stateChanged;

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="state">�X�e�[�g</param>
        public void Initialize(IState state)
        {
            CurrentState = state;
            state.Enter();

            stateChanged?.Invoke(state);
        }

        /// <summary>
        /// �X�e�[�g��ύX����
        /// </summary>
        /// <param name="nextState">���̃X�e�[�g</param>
        public void TransitionTo(IState nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();

            stateChanged?.Invoke(nextState);
        }

        /// <summary>
        /// �X�e�[�g��Update�𓮂���
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
