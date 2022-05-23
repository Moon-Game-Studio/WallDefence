using System.Collections;
using System.Collections.Generic;
using src.Controllers;
using UnityEngine;

namespace src.Game
{
    public class BallSpawnMono : MonoBehaviour
    {
        public Transform objectToLookAt;
        public GameObject prefab;
        public List<Transform> spawnPoints;
        private readonly List<GameObject> spawns;

        public BallSpawnMono()
        {
            spawns = new List<GameObject>();
        }

        public IEnumerator Start()
        {
            spawns.Clear();
            for (var i = 0; i < 2000; i++)
            {
                Spawn();
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void Spawn()
        {
            Transform spawnPoint = spawnPoints.GetRandomItem();
            GameObject spawn = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            var mono = spawn.GetComponent<BallMovementMono>();
            mono.target = objectToLookAt;
            spawns.Add(spawn);
        }
    }
}