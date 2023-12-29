using UnityEngine;

namespace PlayerState
{
    public class IdleState : IPlayerState
    {
        private  PlayerStateManager _stateManager;

        public IdleState(PlayerStateManager manager)
        {
            _stateManager = manager;
        }
        public void EnterState()
        {
            Debug.Log("进入Idle"); 
        }

        public void UpdateState()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Debug.Log(moveHorizontal+moveVertical);
        
            if (moveHorizontal != 0 || moveVertical != 0)
            {
                _stateManager.ChangerState(PlayerStateManager.PlayerState.Running);
            } 
        }

        public void ExitState()
        {
        
        }
    }
}
