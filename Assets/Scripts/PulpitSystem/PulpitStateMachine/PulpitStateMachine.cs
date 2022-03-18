using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PulpitSystem
{
    public class PulpitStateMachine
    {
        public StateMachine<PulpitController> stateMachine;
        public StatePulpitInitialise InitialiseState;
        public StatePulpitRunning RunningState;
        public StatePulpitDisabled DisabledState;

        public PulpitStateMachine(PulpitController pc)
        {
            stateMachine = new StateMachine<PulpitController>(pc);
            InitialiseState = new StatePulpitInitialise();
            RunningState = new StatePulpitRunning();
            DisabledState = new StatePulpitDisabled();
        }
    } 
}
