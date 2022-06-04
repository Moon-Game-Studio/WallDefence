using UnityEngine;

namespace src.Controllers
{
    public static class UnityHelper
    {
        public static (bool, RaycastHit) Raycast(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                return (true, hit);
            }

            return (false, default);
        }
    }
}