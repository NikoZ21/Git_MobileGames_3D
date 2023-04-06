using System.Collections;
using System.Collections.Generic;
using HelixJump._Scripts;
using TMPro;
using UnityEngine;

public class OnClickEvents : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _muteText;

    void Start()
    {
        _muteText.enabled = false;
    }

    public void ToggleMute()
    {
        GameManager.IsMuted = !GameManager.IsMuted;
        _muteText.enabled = GameManager.IsMuted;
    }

    public void QuitGame()
    {
        Application.Quit();
        print("game has been quit");
    }
}