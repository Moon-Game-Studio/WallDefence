using UnityEngine;

namespace src
{
    public class RemovableMono : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Laser Beam"))
            {
                Destroy(gameObject);
            }
        }
    }
}