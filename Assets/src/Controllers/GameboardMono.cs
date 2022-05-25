using src.Models;
using UnityEngine;

namespace src.Controllers
{
    public class GameboardMono : MonoBehaviour
    {
        public GameboardDataMono gameboardData;
        public Camera mainCamera;
        public GameObject boardMono;
        public Vector3 point;
        public GameObject cube;
        private float cellSize;
        private float height;
        private float width;

        private void Awake()
        {
            width = gameboardData.GetBoardWidth();
            height = gameboardData.GetBoardHeight();
            cellSize = height / gameboardData.rowCount;
        }

        private void Update()
        {
            
        }

        private void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                bool raycast = Raycast(ray, out Vector3 clickedCell);
                if (raycast)
                {
                    point = clickedCell;
                    cube.transform.position = clickedCell + new Vector3(0, 1f, 0);
                    
                    float positionX = point.x - gameboardData.bottomRight.transform.position.x;
                    float positionZ = point.z - gameboardData.topRight.transform.position.z;
                    float columnCount = positionX / 2;
                    float rowCount = positionZ / 2;
                    Debug.Log($"point.x : {point.x} - br.x {gameboardData.bottomRight.transform.position.x} = {positionX}");
                    Debug.Log($"point.z : {point.z} - br.x {gameboardData.topRight.transform.position.z} = {positionX}");
                    Debug.Log($"{columnCount} = {positionX} / {2}");
                    Debug.Log($"{rowCount} = {positionZ} / {2}");
                    Debug.Log("----------------------");
                }
            }
        }

        private static bool Raycast(Ray ray, out Vector3 cell)
        {
            cell = Vector3Int.zero;
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                cell = hit.point;
                return true;
            }

            return false;
        }
    }
}