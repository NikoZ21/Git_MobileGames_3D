using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZigZag._Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject menuCanvas;
        [SerializeField] private GameObject endCanvas;
        public bool hasGameStarted;
        private int score;


        private void Update()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !hasGameStarted)
            {
                StartGame();
            }
        }

        private void StartGame()
        {
            hasGameStarted = true;
            menuCanvas.SetActive(false);

            PlayerPrefs.SetInt("GamesPlayed", PlayerPrefs.GetInt("GamesPlayed") + 1);
        }
        public void EndGame()
        {
            endCanvas.SetActive(true);
        }

        public void IncreaseScore()
        {
            score++;
            scoreText.text = score.ToString();

            if (score > GetHighScore())
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }

        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public int GetHighScore()
        {
            int i = PlayerPrefs.GetInt("HighScore");
            return i;
        }

        public int GetGamesPlayed()
        {
            int i = PlayerPrefs.GetInt("GamesPlayed");
            return i;
        }

        public int GetCurrentScore()
        {
            return score;
        }
    }
}
