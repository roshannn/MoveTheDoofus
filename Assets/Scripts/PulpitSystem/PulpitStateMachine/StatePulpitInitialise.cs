using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PulpitSystem
{
    public class StatePulpitInitialise : IState<PulpitController>
    {
        private PulpitController currPulpitView;
       
        public void OnStateEnter(PulpitController StateObject)
        {
            Debug.Log("Entering Init State");
            currPulpitView = StateObject;
            currPulpitView.CurrPulpitState = PulpitState.Initialise;
            currPulpitView.gameObject.SetActive(true);
            currPulpitView.timeToDestroy = Random.Range(currPulpitView.minPulpitDestroyTime, currPulpitView.maxPulpitDestroyTime);
            currPulpitView.timerText.gameObject.SetActive(true);
            currPulpitView.timerText.text = currPulpitView.timeToDestroy.ToString("n2");
            PulpitSystem.Instance.OnStateChange += ChangeState;
            ChangeState();
        }

        private void ChangeState()
        {
            currPulpitView.PulpitStateMachine.stateMachine.ChangeState(currPulpitView.PulpitStateMachine.RunningState);
        }

        public void OnStateExit(PulpitController StateObject)
        {
            PulpitSystem.Instance.OnStateChange -= ChangeState;
        }

        public void Update()
        {

        }
    }
}
