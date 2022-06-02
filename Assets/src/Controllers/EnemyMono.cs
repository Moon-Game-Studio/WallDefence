using UnityEngine;

namespace src.Controllers
{
    public class EnemyMono : MonoBehaviour
    {
        public Vector3 pointA;
        public Vector3 pointB;
        public float speed = 2.5f;
        private Vector3 destination;

        private void Awake()
        {
            destination = pointA;
        }

        private void Update()
        {
            if (IsDestinationReached())
            {
                SwapDestination();
            }

            Move();
        }

        private void Move()
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destination, step);
        }

        private bool IsDestinationReached()
        {
            return Vector3.Distance(transform.position, destination) < 0.001f;
        }

        private void SwapDestination()
        {
            destination = destination == pointA ? pointB : pointA;
        }
    }
}