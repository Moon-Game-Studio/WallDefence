using UnityEngine;

namespace src.Models
{
    public class GameboardDataMono : MonoBehaviour
    {
        public int rowCount;
        public int columnCount;
        public Transform bottomRight;
        public Transform bottomLeft;
        public Transform topRight;
        public Transform topLeft;

        public float GetBoardWidth()
        {
            return Vector3.Distance(bottomRight.transform.position, bottomLeft.transform.position) / columnCount;
        }

        public float GetBoardHeight()
        {
            return Vector3.Distance(bottomRight.transform.position, bottomLeft.transform.position) / columnCount;
        }
    }
}