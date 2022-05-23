using UnityEngine;

namespace src.Game
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallMovementMono : MonoBehaviour
    {
        public Transform target;
        public float speed = 1f;
        private Rigidbody rigid;

        private void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (target == null)
            {
                return;
            }
            
            transform.LookAt(target.position);
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}