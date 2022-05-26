using src.Models;
using UnityEngine;

namespace src.Controllers
{
    public class GameboardMono : MonoBehaviour
    {
        public GameboardDataMono gameboardData;
        public Camera mainCamera;
        public GameObject cube;
        private float cellSize;
        private float height;
        private float width;

        private void Awake()
        {
            width = gameboardData.BoardWidth;
            height = gameboardData.BoardHeight;
            cellSize = height / gameboardData.rowCount;
        }

        private void Update() { }

        private void FixedUpdate()
        {
            //if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                (bool isRaycastSuccesfull, BoardCell cell) = TryGetBoardCell(ray, gameboardData);
                if (isRaycastSuccesfull)
                {
                    Vector3 worldCoordinate = ConvertToWorldCoordinate(
                        cell,
                        gameboardData.bottomRight.position,
                        gameObject.transform.position.y);
                    cube.transform.position = worldCoordinate;
                }
            }
        }

        private static Vector3 ConvertToWorldCoordinate(BoardCell cell, Vector3 bottomRight, float y)
        {
            const int cellSize = 2;
            float x = bottomRight.x - cell.Column * cellSize + 1;
            float z = bottomRight.z + cell.Row * cellSize - 1;
            return new Vector3(x, y, z);
        }

        private static (bool raycast, BoardCell cell) TryGetBoardCell(Ray ray, GameboardDataMono gameboardData)
        {
            (bool isRaycastSuccesfull, RaycastHit hit) = Raycast(ray);
            if (!isRaycastSuccesfull)
            {
                return (false, default);
            }

            Vector3 boardReferencePoint = gameboardData.bottomRight.transform.position;
            BoardCell boardCell = GetBoardPosition(hit.point, boardReferencePoint);
            //Debug.Log(hit.point);
            return (true, boardCell);
        }

        private static BoardCell GetBoardPosition(Vector3 hitPoint, Vector3 transformPosition)
        {
            float positionX = Mathf.Abs(hitPoint.x - transformPosition.x);
            float positionZ = Mathf.Abs(hitPoint.z - transformPosition.z);

            const int cellSize = 2;
            float column = positionX / cellSize;
            float row = positionZ / cellSize;

            var boardCell = new BoardCell(Mathf.CeilToInt(row), Mathf.CeilToInt(column));
            return boardCell;
        }


        private static (bool, RaycastHit) Raycast(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                return (true, hit);
            }

            return (false, default);
        }
    }
}