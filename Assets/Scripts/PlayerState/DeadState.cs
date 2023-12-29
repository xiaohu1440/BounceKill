namespace PlayerState
{
    public class DeadState : IPlayerState
    {
        private PlayerStateManager _stateManager;

        public DeadState(PlayerStateManager manager)
        {
            _stateManager = manager;
        }
        public void EnterState()
        {
        
        }

        public void UpdateState()
        {
        
        }

        public void ExitState()
        {
        
        }
    }
}
