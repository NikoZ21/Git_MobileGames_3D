using UnityEngine;

namespace ZigZag._Scripts
{
    public class RoadGenrator : MonoBehaviour
    {
        [SerializeField] private GameObject roadPart;
        [SerializeField] private Vector3 lastPos;
        [SerializeField] private float offset = 0.7071067f;
        private float roadCount = 0;


        private void CreateNewRoadPart()
        {
            print("Create new road part");

            Vector3 spawnPos = Vector3.zero;

            float chance = Random.Range(0, 100);
            if (chance < 50)
            {
                spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
            }
            else
            {
                spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
            }

            GameObject g = Instantiate(roadPart, spawnPos, Quaternion.Euler(0, 45, 0));
            lastPos = g.transform.position;

            roadCount++;

            if (roadCount % 5 == 0)
            {
                g.transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        void Update()
        {
            CreateNewRoadPart();
        }
    }
}
