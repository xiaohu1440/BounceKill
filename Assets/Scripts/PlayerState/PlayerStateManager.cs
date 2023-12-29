using System.Collections.Generic;
using UnityEngine;

namespace PlayerState
{
    public class PlayerStateManager : MonoBehaviour
    {
        private IPlayerState currentState;
        public PlayerAttributes attributes;
        public enum PlayerState
        {
            Idle,
            Running,
            Dead
        }

        private Dictionary<PlayerState, IPlayerState> stateDictionary =
            new Dictionary<PlayerState, IPlayerState>();
        void Start()
        {
            RegisterState(PlayerState.Idle,new IdleState(this));
            RegisterState(PlayerState.Running,new RunningState(this));
            RegisterState(PlayerState.Dead,new DeadState(this));
        
            ChangerState(PlayerState.Idle);
        
        }

    
        void Update()
        {
            if (currentState != null)
            {
                currentState.UpdateState();
            }
                
        }

        public void ChangerState(PlayerState newState)
        {
            if (currentState != null)
            {
                currentState.ExitState();
            }

            currentState = stateDictionary[newState];
            currentState.EnterState();
        }

        public void RegisterState(PlayerState state, IPlayerState stateInstance)
        {
            stateDictionary[state] = stateInstance;
        }
    }
}
