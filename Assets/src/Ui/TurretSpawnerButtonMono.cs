using src.Controllers;
using src.Turrets;
using UnityEngine;
using UnityEngine.UI;

namespace src.Ui
{
    public class TurretSpawnerButtonMono : MonoBehaviour
    {
        public Button spawnTurretButton;
        public GameboardMono gameboard;
        public TurretBaseMono turretPrefab;

        private void Start()
        {
            spawnTurretButton.onClick.AddListener(OnSpawnTurret);
        }

        private void OnSpawnTurret()
        {
            gameboard.SpawnTurret(turretPrefab);
        }
    }
}