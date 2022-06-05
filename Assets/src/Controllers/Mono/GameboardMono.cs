using src.Models;
using src.Turrets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace src.Controllers.Mono
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
            (bool isRaycastSuccesfull, BoardCell cell) = GameBoardHelper.MouseToBoardPosition(mainCamera, gameboardData);
            if (!isRaycastSuccesfull)
            {
                return;
            }

            Vector3 worldCoordinate = GameBoardHelper.ConvertToWorldCoordinate(cell, gameboardData.bottomRight.position);
            turret.transform.position = worldCoordinate;
        }

        public void SpawnTurret(TurretBaseMono turretPrefab)
        {
            turret = Instantiate(turretPrefab);
            isSpawning = true;
        }
    }
}