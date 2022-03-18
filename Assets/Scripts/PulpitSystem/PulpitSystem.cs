using MonoSingleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extensions;
using GameSystem;

namespace PulpitSystem
{
    public class PulpitSystem : MonoSingleton<PulpitSystem>
    {
        public PulpitPool pulpitPool;

        public Queue<PulpitController> pulpitQueue;
        public DirectionSystem directionSystem;
        public float spawnTimer;
        public Action SpawnPulpit;
        public Action OnStateChange;
        public Vector3 lastSpawnedPulpitPos;

        protected override void Awake()
        {
            base.Awake();
            directionSystem = new DirectionSystem();
        }

        private void Start()
        {
            pulpitQueue = new Queue<PulpitController>();
            SpawnPulpit += SpawnNewPulpit;
            spawnTimer = GameManager.Instance.GameData.pulpitData.PulpitSpawnTime;
            InitializeFirstPulpit();

        }

        private void InitializeFirstPulpit()
        {
            var Pulpit = pulpitPool.GetItemFromPool();
            pulpitQueue.Enqueue(Pulpit);
            Pulpit.gameObject.transform.position = Vector3.zero;
            Pulpit.gameObject.SetActive(true);
            Pulpit.PulpitStateMachine.stateMachine.ChangeState(Pulpit.PulpitStateMachine.InitialiseState);
            lastSpawnedPulpitPos = Pulpit.transform.position;
        }

        private void SpawnNewPulpit()
        {
            Direction randomDirection = directionSystem.GetRandomDirection();
            var Pulpit = pulpitPool.GetItemFromPool();
            pulpitQueue.Enqueue(Pulpit);
            Pulpit.gameObject.SetActive(true);
            Pulpit.PulpitStateMachine.stateMachine.ChangeState(Pulpit.PulpitStateMachine.InitialiseState);
            SetPulpitPosition(Pulpit, randomDirection);
            lastSpawnedPulpitPos = Pulpit.transform.position;

        }
        
        private void SetPulpitPosition(PulpitController pulpit, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    pulpit.transform.position = new Vector3(lastSpawnedPulpitPos.x, lastSpawnedPulpitPos.y, lastSpawnedPulpitPos.z + pulpit.transform.localScale.z);
                    break;
                case Direction.South:
                    pulpit.transform.position = new Vector3(lastSpawnedPulpitPos.x, lastSpawnedPulpitPos.y, lastSpawnedPulpitPos.z - pulpit.transform.localScale.z);
                    break;
                case Direction.East:
                    pulpit.transform.position = new Vector3(lastSpawnedPulpitPos.x + pulpit.transform.localScale.x, lastSpawnedPulpitPos.y, lastSpawnedPulpitPos.z);
                    break;
                case Direction.West:
                    pulpit.transform.position = new Vector3(lastSpawnedPulpitPos.x - pulpit.transform.localScale.x, lastSpawnedPulpitPos.y, lastSpawnedPulpitPos.z);
                    break;
            }

        }

        private void OnDestroy()
        {
            directionSystem = null;
        }
    }
}
