using src.Models;
using UnityEngine;

namespace src.Controllers
{
    public class MapGridGizmosDrawerMono : MonoBehaviour
    {
        public GameboardDataMono gameboardData;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Vector3 br = gameboardData.bottomRight.transform.position;
            Vector3 bl = gameboardData.bottomLeft.transform.position;
            Vector3 tl = gameboardData.topLeft.transform.position;
            float height = gameboardData.GetBoardHeight();
            float width = gameboardData.GetBoardWidth();

            for (var i = 0; i <= gameboardData.columnCount; i++)
            {
                Vector3 from = bl + new Vector3(width, 0, 0) * -i;
                Vector3 to = tl + new Vector3(width, 0, 0) * -i;
                Gizmos.DrawLine(from, to);
            }

            for (var i = 0; i <= gameboardData.rowCount; i++)
            {
                Vector3 from = bl + new Vector3(0, 0, height) * -i;
                Vector3 to = br + new Vector3(0, 0, height) * -i;
                Gizmos.DrawLine(from, to);
            }
        }
    }
}