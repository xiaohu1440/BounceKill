using UnityEngine;

namespace PlayerState
{
    public class RunningState : IPlayerState
    {
        private PlayerStateManager _stateManager;
        private Rigidbody2D rb;
        private Vector2 targetVelocity;

        public RunningState(PlayerStateManager manager)
        {
            _stateManager = manager;
        }
        public void EnterState()
        {
            
            rb = _stateManager.gameObject.GetComponent<Rigidbody2D>();
        }

        public void UpdateState()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            float moveHorizontalRaw = Input.GetAxisRaw("Horizontal");
            float moveVerticalRaw = Input.GetAxisRaw("Vertical");

            if (moveHorizontal <= 0 && moveVertical <= 0)
            {
                _stateManager.ChangerState(PlayerStateManager.PlayerState.Idle);
            
            }

            Vector2 currentVelocity = rb.velocity;
            
            if (Mathf.Abs(moveHorizontalRaw) == 0 || Mathf.Abs(moveVerticalRaw) == 0)
            {
                targetVelocity=new Vector2(moveHorizontal * _stateManager.attributes.speed,
                    moveVertical * _stateManager.attributes.speed); 
                
            }
            else
            {
                targetVelocity = new Vector2(moveHorizontal * _stateManager.attributes.speed*0.7f,
                    moveVertical * _stateManager.attributes.speed*0.7f); 
            } 
            rb.velocity = Vector2.Lerp(currentVelocity, targetVelocity, 1f);

        }

        public void ExitState()
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
