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
            (bool isRaycastSuccesfull, BoardCell cell) = GameBoardHelper.TryGetBoardCell(ray, gameboardData);
            if (isRaycastSuccesfull)
            {
                const float turretSpawnY = 0.7f;
                Vector3 worldCoordinate = GameBoardHelper.ConvertToWorldCoordinate(
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
    }
}