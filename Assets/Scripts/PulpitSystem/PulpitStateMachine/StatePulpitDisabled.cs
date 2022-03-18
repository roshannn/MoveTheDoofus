using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PulpitSystem
{
    public class StatePulpitDisabled : IState<PulpitController>
    {
        public PulpitController pulpitView;
        public void OnStateEnter(PulpitController StateObject)
        {
            Debug.Log("Disabled State");

            pulpitView = StateObject;
            pulpitView.CurrPulpitState = PulpitState.Disabled;
            PulpitSystem.Instance.pulpitQueue.Dequeue();
            PulpitSystem.Instance.pulpitPool.ReturnItemToPool(pulpitView);
        }

        public void OnStateExit(PulpitController StateObject)
        {
            
        }

        public void Update()
        {

        }
    } 
}
