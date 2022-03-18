using UnityEngine;

namespace StateMachine
{
    public interface IState<T> 
    {
        /// <summary>
        /// Start actions for current State
        /// </summary>
        /// <param name="StateObject">Current State Object</param>
        void OnStateEnter(T StateObject);

        /// <summary>
        /// Updates for the current state or the next state
        /// </summary>
        void Update();

        /// <summary>
        /// Destroys current State
        /// </summary>
        /// <param name="StateObject">Current State Object</param>
        void OnStateExit(T StateObject);

    }
}
