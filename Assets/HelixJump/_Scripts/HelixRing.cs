using UnityEngine;

namespace HelixJump._Scripts
{
    public class HelixRing : MonoBehaviour
    {
        private Transform player;

        void Start()
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        void Update()
        {
            if (player.position.y < transform.position.y)
            {
                FindObjectOfType<AudioManager>().Play("whoosh");
                GameManager.NumberOfPassedRings++;
                enabled = false;
            }
        }
    }
}