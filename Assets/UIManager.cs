using MonoSingleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameSystem;
using TMPro;

namespace UIManager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject MainScreenPanel;
        [SerializeField] private GameObject PlayScreenPanel;
        [SerializeField] private GameObject GameOverPanel;

        [Header("MainPanel")]
        [SerializeField] private Button playButton;

        [Header("PlayScreenPanel")]
        [SerializeField] private TMP_Text scoreText;

        [Header("GameOverPanel")]
        [SerializeField] private Button restartButton;
        [SerializeField] private Button homeButton;


        private void Start()
        {
            MainScreenPanel.SetActive(true);
            playButton.onClick.AddListener(PlayGame);
            GameManager.GameOver += ShowGameOverPanel;
            restartButton.onClick.AddListener(PlayGame);
            homeButton.onClick.AddListener(ShowMainScreenPanel);
            PlayerSystem.PlayerSystem.OnPulpitChange += UpdateScoreText;
        }

        private void ShowMainScreenPanel()
        {
            MainScreenPanel.SetActive(true);
            GameOverPanel.SetActive(false);
            PlayScreenPanel.SetActive(false);
        }

        private void ShowGameOverPanel()
        {
            //await System.Threading.Tasks.Task.Delay(1000);
            MainScreenPanel.SetActive(false);
            PlayScreenPanel.SetActive(false);
            GameOverPanel.SetActive(true);
        }

        private void PlayGame()
        {
            MainScreenPanel.SetActive(false);
            GameOverPanel.SetActive(false);
            PlayScreenPanel.SetActive(true);
            GameManager.InitializeGame?.Invoke();
            GameManager.gameState = GameState.PlayState;
        }

        private void OnDestroy()
        {
            GameManager.GameOver -= ShowGameOverPanel;
            playButton.onClick.RemoveAllListeners();
            restartButton.onClick.RemoveAllListeners();
            homeButton.onClick.RemoveAllListeners();
            PlayerSystem.PlayerSystem.OnPulpitChange -= UpdateScoreText;
        }

        private void UpdateScoreText()
        {
            scoreText.text = PlayerSystem.PlayerSystem.Instance.scoreSystem.Score.ToString();
        }
    }
}

