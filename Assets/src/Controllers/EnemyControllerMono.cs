using System.Collections.Generic;
using UnityEngine;

namespace src.Controllers
{
    public class EnemyControllerMono : MonoBehaviour
    {
        public EnemyControllerMono()
        {
            Enemies = new List<EnemyMono>();
        }

        public List<EnemyMono> Enemies { get; }
    }
}