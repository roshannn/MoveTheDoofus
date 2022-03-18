using GameSystem;
using StateMachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PulpitSystem
{
    public class PulpitController : MonoBehaviour
    {
        public float minPulpitDestroyTime;
        public float maxPulpitDestroyTime;

        public PulpitStateMachine PulpitStateMachine;


        public PulpitState CurrPulpitState;

        public TMP_Text timerText;
        public float timeToDestroy;

        private void Awake()
        {
            SetUpStateMachine();
            minPulpitDestroyTime = GameManager.Instance.GameData.pulpitData.MinPulpitDestroyTime;
            maxPulpitDestroyTime = GameManager.Instance.GameData.pulpitData.MaxPulpitDestroyTime;
        }

        private void SetUpStateMachine()
        {
            PulpitStateMachine = new PulpitStateMachine(this);
        }

        // Update is called once per frame
        void Update()
        {
            PulpitStateMachine.stateMachine?.Update();
        }
    } 
}
