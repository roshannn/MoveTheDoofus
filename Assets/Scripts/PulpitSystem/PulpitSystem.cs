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
            GameManager.InitializeGame += InitializeFirstPulpit;
            GameManager.GameOver += GameOver;
        }

        private void GameOver()
        {
            SpawnPulpit -= SpawnNewPulpit;
            pulpitPool.ReturnAllItemsToPool();
        }
        private void Start()
        {
            directionSystem = new DirectionSystem();
            pulpitQueue = new Queue<PulpitController>();
            spawnTimer = GameManager.Instance.GameData.pulpitData.PulpitSpawnTime;
            //InitializeFirstPulpit();
        }

        public void InitializeFirstPulpit()
        {
            SpawnPulpit += SpawnNewPulpit;
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
            SetPulpitPosition(Pulpit, randomDirection);
            Pulpit.gameObject.SetActive(true);
            Pulpit.PulpitStateMachine.stateMachine.ChangeState(Pulpit.PulpitStateMachine.InitialiseState);
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
            GameManager.GameOver -= GameOver;

            directionSystem = null;
        }
    }
}
