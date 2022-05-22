using UnityEngine;

namespace src.Laser
{
    public class LazerTurnMono : MonoBehaviour
    {
        public float rotationSpeed = 1f;
        
        private void Update()
        {
            transform.Rotate(0, rotationSpeed, 0);
        }
    }
}