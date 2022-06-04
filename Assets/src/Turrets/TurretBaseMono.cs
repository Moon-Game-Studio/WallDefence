using System.Collections;
using src.Controllers;
using src.Controllers.Mono;
using UnityEngine;

namespace src.Turrets
{
    public class TurretBaseMono : MonoBehaviour
    {
        private static readonly int AnimationStatusTrigger = Animator.StringToHash("AnimationStatusTrigger");
        public Animator animator;
        public GameObject bulletPrefab;
        public Transform target;
        public Transform bulletSpawnTransform;
        public float bulletSpeed = 10f;
        public float attackWaitTime = 0.1f;
        public bool keepShooting = true;

        private void Start()
        {
            StartCoroutine(nameof(Shoot));
            //animator.Play("");
        }

        private void Update()
        {
            transform.LookAt(target);
        }

        public IEnumerator Shoot()
        {
            while (keepShooting)
            {
                animator.SetTrigger(AnimationStatusTrigger);
                SpawnBullet();
                yield return new WaitForSeconds(attackWaitTime);
            }

            yield return null;
        }

        private void SpawnBullet()
        {
            GameObject bulletObject = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity);
            var bullet = bulletObject.GetComponent<BulletMono>();
            bullet.Setup(bulletSpeed, target);
        }
    }
}