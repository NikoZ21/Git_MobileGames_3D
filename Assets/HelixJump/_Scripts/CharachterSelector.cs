using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharachterSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] balls;
    private int selectedBallIndex = 0;

    void Start()
    {
        foreach (GameObject ball in balls)
        {
            ball.SetActive(false);
        }

        balls[selectedBallIndex].SetActive(true);
    }

    public void ChangeBall(int newBallIndex)
    {
        balls[selectedBallIndex].SetActive(false);
        selectedBallIndex = newBallIndex;
        balls[newBallIndex].SetActive(true);
    }
}