using src.Models;
using UnityEngine;

namespace src.Controllers
{
    public static class GameBoardHelper
    {
        public static Vector3 ConvertToWorldCoordinate(BoardCell cell, Vector3 bottomRight, float y)
        {
            const int cellSize = 2;
            float x = bottomRight.x - cell.Column * cellSize + 1;
            float z = bottomRight.z + cell.Row * cellSize - 1;
            return new Vector3(x, y, z);
        }
        
        public static (bool raycast, BoardCell cell) TryGetBoardCell(Ray ray, GameboardDataMono gameboardData)
        {
            (bool isRaycastSuccesfull, RaycastHit hit) = UnityHelper.Raycast(ray);
            if (!isRaycastSuccesfull)
            {
                return (false, default);
            }

            Vector3 boardReferencePoint = gameboardData.bottomRight.transform.position;
            BoardCell boardCell = GetBoardPosition(hit.point, boardReferencePoint);
            return (true, boardCell);
        }

        public static BoardCell GetBoardPosition(Vector3 hitPoint, Vector3 transformPosition)
        {
            float positionX = Mathf.Abs(hitPoint.x - transformPosition.x);
            float positionZ = Mathf.Abs(hitPoint.z - transformPosition.z);

            const int cellSize = 2;
            float column = positionX / cellSize;
            float row = positionZ / cellSize;

            var boardCell = new BoardCell(Mathf.CeilToInt(row), Mathf.CeilToInt(column));
            return boardCell;
        }

    }
}