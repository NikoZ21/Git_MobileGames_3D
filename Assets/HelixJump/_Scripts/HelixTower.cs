using UnityEngine;

namespace HelixJump._Scripts
{
    public class HelixTower : MonoBehaviour
    {
        [SerializeField] private GameObject[] _helixRings;
        [SerializeField] private float _ySpawn;
        [SerializeField] private float _ringDistance;
        [SerializeField] private Transform _parent;
        public int _numberOfRings;

        void Start()
        {
            _numberOfRings = GameManager.CurrentLevelIndex + 5;

            for (int i = 0; i < _numberOfRings; i++)
            {
                if (i == 0)
                {
                    SpawnRing(0);
                }
                else
                {
                    SpawnRing(Random.Range(1, _helixRings.Length - 1));
                }
            }

            SpawnRing(_helixRings.Length - 1);
        }

        private void SpawnRing(int ringIndex)
        {
            Instantiate(_helixRings[ringIndex], transform.up * _ySpawn, Quaternion.identity, _parent);
            _ySpawn -= _ringDistance;
        }
    }
}