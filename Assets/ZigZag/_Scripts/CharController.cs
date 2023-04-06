using UnityEngine;

namespace ZigZag._Scripts
{
    public class CharController : MonoBehaviour
    {
        [SerializeField] private Transform rayStart;
        [SerializeField] private float speed = 5;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private GameObject diamondVFX;
        private Rigidbody _rb;
        private Animator _animator;
        private bool isWalkingRight = true;
        private bool isFalling = false;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            if (!gameManager.hasGameStarted)
            {
                return;
            }
            else
            {
                _animator.SetTrigger("gameStarted");
            }

            _rb.transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        }

        void Update()
        {
            if (!gameManager.hasGameStarted)
            {
                return;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {

                print("tapping");
                if (!isFalling)
                {
                    SwitchDirection();
                    gameManager.IncreaseScore();
                }
            }

            RaycastHit hit;

            if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
            {
                _animator.SetTrigger("IsFalling");
                isFalling = true;
            }

            if (transform.position.y <= -2)
            {
                gameManager.EndGame();
            }
        }

        private void SwitchDirection()
        {
            isWalkingRight = !isWalkingRight;
            if (isWalkingRight)
            {
                transform.rotation = Quaternion.Euler(0f, 45, 0f);
            }
            else if (!isWalkingRight)
            {
                transform.rotation = Quaternion.Euler(0f, -45, 0f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Diamond")
            {
                gameManager.IncreaseScore();
                GameObject g = Instantiate(diamondVFX, rayStart.transform.position, Quaternion.identity);
                Destroy(g, 2);
                Destroy(other.gameObject);
            }
        }
    }
}
