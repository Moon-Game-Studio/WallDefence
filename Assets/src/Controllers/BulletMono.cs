using UnityEngine;

namespace src.Controllers
{
    public class BulletMono : MonoBehaviour
    {
        public bool followTarget;
        public float shootForce;
        public Transform targetObject;
        public Vector3 targetPosition;

        private void Start()
        {
            Destroy(gameObject, 2f);
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float step = shootForce * Time.deltaTime;
            if (followTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetObject.position, step);
                transform.LookAt(targetObject.transform);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            }
        }

        public void Setup(float shootingForce, Transform target)
        {
            targetObject = target;
            shootForce = shootingForce;
            followTarget = true;
            transform.LookAt(targetObject.transform);
        }

        public void Setup(float shootingForce, Vector3 target)
        {
            shootForce = shootingForce;
            followTarget = false;
            targetPosition = target;
            transform.LookAt(target);
        }
    }
}