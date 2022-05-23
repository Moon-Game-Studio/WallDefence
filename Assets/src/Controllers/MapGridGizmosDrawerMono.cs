using UnityEngine;

namespace src.Controllers
{
    public class MapGridGizmosDrawerMono : MonoBehaviour
    {
        public int rowCount;
        public int columnCount;
        public Transform bottomRight;
        public Transform bottomLeft;
        public Transform topRight;
        public Transform topLeft;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            
            Vector3 br = bottomRight.transform.position;
            Vector3 bl = bottomLeft.transform.position;
            //Vector3 tr = topRight.transform.position;
            Vector3 tl = topLeft.transform.position;
            float height = Vector3.Distance(bl, tl) / rowCount;
            float width = Vector3.Distance(br, bl) / columnCount;

            for (var i = 0; i <= columnCount; i++)
            {
                Vector3 from = bl + new Vector3(width, 0, 0) * -i;
                Vector3 to = tl + new Vector3(width, 0, 0) * -i;
                Gizmos.DrawLine(from, to);
            }

            for (var i = 0; i <= rowCount; i++)
            {
                Vector3 from = bl + new Vector3(0, 0, height) * -i;
                Vector3 to = br + new Vector3(0, 0, height) * -i;
                Gizmos.DrawLine(from, to);
            }
        }
    }
}