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

        public float BoardWidth { get; private set; }
        public float BoardHeight { get; private set; }

        private void Start()
        {
            BoardWidth = GetBoardWidth();
            BoardHeight = GetBoardHeight();
        }

        private float GetBoardWidth()
        {
            return Vector3.Distance(bottomRight.transform.position, bottomLeft.transform.position) / columnCount;
        }

        private float GetBoardHeight()
        {
            return Vector3.Distance(bottomRight.transform.position, bottomLeft.transform.position) / columnCount;
        }

        
    }
}