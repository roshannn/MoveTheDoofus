using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonoSingleton;
using PulpitSystem;
using System;
using GameSystem;

namespace PlayerSystem
{
    public class PlayerSystem : MonoSingleton<PlayerSystem>
    {
        public PlayerFactory playerFactory;
        public PlayerController playerController;
        public ScoreSystem scoreSystem;
        public static Action OnPulpitChange;
        private Action IncrementScore;


        protected override void Awake()
        {
            base.Awake();
            GameManager.InitializeGame += InitializePlayer;
            GameManager.GameOver += OnGameOver;
        }
        private void Start()
        {
            playerController = new PlayerController();
            IncrementScore = delegate { scoreSystem.IncrementScore(); };
            OnPulpitChange += IncrementScore;
            playerController.playerView.gameObject.SetActive(false);
        }
        private void OnGameOver()
        {
            playerController.playerView.gameObject.SetActive(false);
            playerController.prevPulpit = null;
        }

        public void InitializePlayer()
        {
            playerController.playerView.gameObject.transform.position = Vector3.zero + new Vector3(0, 0.5f, 0);
            playerController.playerView.gameObject.SetActive(true);
            scoreSystem.InitialiseScore();
            OnPulpitChange?.Invoke();
        }
        private void OnDisable()
        {
            OnPulpitChange = null;
            GameManager.InitializeGame -= InitializePlayer;
            GameManager.GameOver -= OnGameOver;


        }

    }
}
