using UnityEngine;

namespace HelixJump._Scripts
{
    public class HelixTowerRotator : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeedModifier = 0.1f;

        private Touch _touch;

        private Quaternion _rotationY;

        private void Update()
        {
            if (!GameManager.IsGameStarted) return;

            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);

                if (_touch.phase == TouchPhase.Moved)
                {
                    _rotationY = Quaternion.Euler(0, -_touch.deltaPosition.x * Time.deltaTime * _rotateSpeedModifier,
                        0);

                    transform.rotation = _rotationY * transform.rotation;
                }
            }
        }
    }
}