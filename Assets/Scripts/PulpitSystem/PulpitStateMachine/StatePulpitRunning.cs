using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PulpitSystem
{
    public class StatePulpitRunning : IState<PulpitController>
    {
        public PulpitController currPulpit;
        public bool isNextPulpitSpawned = false;
        public bool isRunning = false;
        private float timeElapsed = 0;
        public void OnStateExit(PulpitController StateObject)
        {
            isNextPulpitSpawned = false;
        }

        public void OnStateEnter(PulpitController StateObject)
        {
            timeElapsed = 0;
            currPulpit = StateObject;
            currPulpit.CurrPulpitState = PulpitState.Running;
        }
        public void Update()
        {
            timeElapsed += Time.deltaTime;
            currPulpit.timeToDestroy -= Time.deltaTime;
            currPulpit.timerText.text = currPulpit.timeToDestroy.ToString("n2");
            if (timeElapsed >= PulpitSystem.Instance.spawnTimer && !isNextPulpitSpawned)
            {
                isNextPulpitSpawned = true;
                PulpitSystem.Instance.SpawnPulpit?.Invoke();
            }
            if (currPulpit.timeToDestroy <= 0)
            {
                currPulpit.PulpitStateMachine.stateMachine.ChangeState(currPulpit.PulpitStateMachine.DisabledState);
            }
        }

    }
}
