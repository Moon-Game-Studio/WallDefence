using UnityEngine;

namespace src.Controllers.Mono
{
    public class ShooterMono : MonoBehaviour
    {
        public float shootForce;
        public float upwardForce;

        public float timeBetweenShooting;
        public float spread;
        public float reloadTime;

        public BulletMono bulletPrefab;
        private EnemyMono enemyMono;

        
        public void Setup(EnemyMono target)
        {
            enemyMono = target;
        }

        private void Update()
        {
            if (enemyMono != null)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            
        }
    }
}