using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StateMachine
{
    public class StateMachine<T>
    {
        private T StateObject = default;
        public IState<T> CurrentState = default;

        /// <summary>
        /// Intitalize State
        /// </summary>
        /// <param name="StateObject">Current State Object</param>
        public StateMachine(T StateObject)
        {
            this.StateObject = StateObject;
        }

        public void Update()
        {
            CurrentState?.Update();
        }

        /// <summary>
        /// Change the current state to another state
        /// </summary>
        /// <param name="NewState">Contains the state that the current state would switch to</param>
        public void ChangeState(IState<T> NewState)
        {
            CurrentState?.OnStateExit(StateObject);
            CurrentState = NewState;
            CurrentState?.OnStateEnter(StateObject);
        }
    } 
}