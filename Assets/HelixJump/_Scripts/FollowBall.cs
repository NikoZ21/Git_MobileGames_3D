using UnityEngine;

namespace HelixJump._Scripts
{
    public class FollowBall : MonoBehaviour
    {
        [SerializeField] private Transform _ball;
        [SerializeField] private float _smoothSpeed = 0.04f;
        private Vector3 offset;

        void Start()
        {
            offset = transform.position - _ball.position;
        }


        private void Update()
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, _ball.position + offset, _smoothSpeed);

            transform.position = newPosition;
        }
    }
}
