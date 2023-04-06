using TMPro;
using UnityEngine;

namespace ZigZag._Scripts
{
    public class SetHighScoreText : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private bool needsMessage = false;

        private void OnEnable()
        {
            if (needsMessage)
            {
                GetComponent<TextMeshProUGUI>().text = "HighScore: " + gameManager.GetHighScore().ToString();
            }
            else
            {
                GetComponent<TextMeshProUGUI>().text = gameManager.GetHighScore().ToString();
            }
        }
    }
}
