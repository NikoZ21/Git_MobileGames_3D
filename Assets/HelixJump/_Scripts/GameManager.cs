using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HelixJump._Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _levelCompletedPanel;
        [SerializeField] private GameObject _startMenuPanel;
        [SerializeField] private GameObject _gameplayPanel;

        public static bool IsGameOver;
        public static bool IsLevelCompleted;
        public static bool IsGameStarted;
        public static bool IsMuted = false;

        [SerializeField] private Slider _gameProgressSlider;
        [SerializeField] private TextMeshProUGUI _currentLevelText;
        [SerializeField] private TextMeshProUGUI _nextLevelText;
        public static int CurrentLevelIndex;
        private HelixTower _helixTower;

        public static int NumberOfPassedRings;


        private void Awake()
        {
            CurrentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex");
            _helixTower = FindObjectOfType<HelixTower>();
        }

        void Start()
        {
            NumberOfPassedRings = 0;
            Time.timeScale = 1;
            IsGameStarted = IsGameOver = IsLevelCompleted = false;
        }

        private void Update()
        {
            _currentLevelText.text = CurrentLevelIndex.ToString();
            _nextLevelText.text = (CurrentLevelIndex + 1).ToString();

            int progress = NumberOfPassedRings * 100 / _helixTower._numberOfRings;
            _gameProgressSlider.value = progress;

            if (IsGameOver)
            {
                ProccessGameOver();
            }
            else if (IsLevelCompleted)
            {
                ProcessLevelCompleted();
            }
        }

        public void ProcessGameStart()
        {
            if (!IsGameStarted)
            {
                IsGameStarted = true;
                _gameplayPanel.SetActive(true);
                _startMenuPanel.SetActive(false);
            }
        }

        private void ProcessLevelCompleted()
        {
            _levelCompletedPanel.SetActive(true);

            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    PlayerPrefs.SetInt("CurrentLevelIndex", CurrentLevelIndex + 1);
                    SceneManager.LoadScene("HelixJump");
                }
            }
        }

        private void ProccessGameOver()
        {
            Time.timeScale = 0;
            _gameOverPanel.SetActive(true);
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }
}