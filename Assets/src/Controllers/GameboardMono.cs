using src.Models;
using src.Turrets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace src.Controllers
{
    public class GameboardMono : MonoBehaviour
    {
        public GameboardDataMono gameboardData;
        public Camera mainCamera;
        private float cellSize;
        private float height;
        private bool isSpawning;
        private InputAction playerControls;
        private TurretBaseMono turret;
        private float width;

        private void Awake()
        {
            width = gameboardData.BoardWidth;
            height = gameboardData.BoardHeight;
            cellSize = height / gameboardData.rowCount;
            playerControls = new InputAction(binding: "<Mouse>/leftButton");
            playerControls.performed += delegate
            {
                if (isSpawning)
                {
                    StopFollowing();
                }
            };
        }

        private void FixedUpdate()
        {
            if (isSpawning)
            {
                FollowTurretToMouseLocation();
            }
        }

        private void OnEnable()
        {
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        private void StopFollowing()
        {
            isSpawning = false;
            turret = null;
        }


        private void FollowTurretToMouseLocation()
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            (bool isRaycastSuccesfull, BoardCell cell) = TryGetBoardCell(ray, gameboardData);
            if (isRaycastSuccesfull)
            {
                const float turretSpawnY = 0.7f;
                Vector3 worldCoordinate = ConvertToWorldCoordinate(
                    cell,
                    gameboardData.bottomRight.position,
                    turretSpawnY);
                turret.transform.position = worldCoordinate;
            }
        }

        public void SpawnTurret(TurretBaseMono turretPrefab)
        {
            turret = Instantiate(turretPrefab);
            isSpawning = true;
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