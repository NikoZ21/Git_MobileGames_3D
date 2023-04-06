using TMPro;
using UnityEngine;

namespace ZigZag._Scripts
{
    public class SetCurrentScore : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;


        private void OnEnable()
        {
            GetComponent<TextMeshProUGUI>().text = gameManager.GetCurrentScore().ToString();
        }
    }
}
