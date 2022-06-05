using System.Collections;
using System.Collections.Generic;
using System.Data;
using src.Models;
using UnityEngine;

namespace src.Controllers.Mono
{
    public class EnemyControllerMono : MonoBehaviour
    {
        public List<TestEnemyMono> enemies;
        public float spawnDelayTime = 1f;
        public bool keepSpawning = true;
        public GameObject enemyPrefab;
        public GameboardDataMono gameboardData;

        private void Start()
        {
            if (enemyPrefab == null)
            {
                throw new NoNullAllowedException(nameof(enemyPrefab));
            }

            enemies ??= new List<TestEnemyMono>();
            StartCoroutine(nameof(Spawn));
        }

        public IEnumerator Spawn()
        {
            Vector3 bottomRightPosition = gameboardData.bottomRight.position;
            while (true)
            {
                if (keepSpawning)
                {
                    int randomColumn = Random.Range(0, gameboardData.columnCount) + 1;
                    const int row = 1;
                    Vector3 position = GameBoardHelper.ConvertToWorldCoordinate(
                        new BoardCell(row, randomColumn),
                        bottomRightPosition);
                    GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
                    var enemyMono = enemy.GetComponent<EnemyMono>();
                    Vector3 target = GameBoardHelper.ConvertToWorldCoordinate(
                        new BoardCell(gameboardData.rowCount, randomColumn),
                        bottomRightPosition);
                    enemyMono.Setup(target);
                }

                yield return new WaitForSeconds(spawnDelayTime);
            }
        }
    }
}