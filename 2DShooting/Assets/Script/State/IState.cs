namespace State
{
    public interface IState
    {
        /// <summary>
        /// �X�e�[�g�ɓ��������̏���
        /// </summary>
        public void Enter();

        /// <summary>
        /// ���t���[����鏈��
        /// </summary>
        public void Update();

        /// <summary>
        /// �X�e�[�g�I���Ƃ��̏���
        /// </summary>
        public void Exit();
    }

}
