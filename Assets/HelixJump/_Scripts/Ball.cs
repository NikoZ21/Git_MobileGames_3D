using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace HelixJump._Scripts
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private float _bounceForce = 6;
        private AudioManager _audioManager;

        private void Awake()
        {
            _audioManager = FindObjectOfType<AudioManager>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            FindObjectOfType<AudioManager>().Play("bounce");
            _rb.velocity = new Vector3(_rb.velocity.x, _bounceForce, _rb.velocity.z);

            string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
            print(materialName);

            switch (materialName)
            {
                case "Safe (Instance)":
                    print("this is safe zone");
                    break;
                case "Danger (Instance)":
                    GameManager.IsGameOver = true;
                    _audioManager.Play("game-over");
                    break;
                case "LastRing (Instance)":
                    GameManager.IsLevelCompleted = true;
                    _audioManager.Play("win level");
                    _rb.velocity = Vector3.zero;
                    break;
            }
        }
    }
}