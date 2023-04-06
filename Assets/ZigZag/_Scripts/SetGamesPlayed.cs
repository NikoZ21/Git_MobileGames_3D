using TMPro;
using UnityEngine;

namespace ZigZag._Scripts
{
    public class SetGamesPlayed : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;

        private void OnEnable()
        {
            GetComponent<TextMeshProUGUI>().text = "Games Played: " + gameManager.GetGamesPlayed().ToString();
        }
    }
}
