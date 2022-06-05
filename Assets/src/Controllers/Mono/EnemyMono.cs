using UnityEngine;

namespace src.Controllers.Mono
{
    public class EnemyMono : MonoBehaviour
    {
        public float speed = 10f;
        public Vector3 target;

        private void Update()
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }

        public void Setup(Vector3 targetVector)
        {
            target = targetVector;
        }
    }
}