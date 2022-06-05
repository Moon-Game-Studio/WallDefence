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
        private TestEnemyMono testEnemyMono;

        
        public void Setup(TestEnemyMono target)
        {
            testEnemyMono = target;
        }

        private void Update()
        {
            if (testEnemyMono != null)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            
        }
    }
}