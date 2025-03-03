using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class SpawnManager : MonoBehaviour
    {
        [Header("Prefabs")] 
        public GameObject meleeEnemyPrefab;
        public GameObject rangedEnemyPrefab;
        public GameObject bossPrefab;
        public GameObject enemiesParent;
        public Transform spawnPointsParent;

        [Header("Spawn Data")] 
        public int bossRound = 3;
        public int enemiesPerRound = 5;

        private int currentRound;
        private GameObject[] currentEnemies;
        private Transform[] spawnPoints;

        private void Start()
        {
            currentRound = 1;
            GetSpawnPoints();
            RandomlySpawnEnemies();
        }

        private void Update()
        {
            int currentEnemyCount = UpdateCurrentEnemyCount();

            if (currentEnemyCount == 0)
            {
                currentRound++;
                if (currentRound == bossRound)
                    SpawnBoss();
                else
                    RandomlySpawnEnemies();
            }
        }
        
        private int UpdateCurrentEnemyCount()
        {
            if (currentEnemies == null)
                return 0;
            
            int currentEnemyNumber = 0;
            for (var i = 0; i < currentEnemies.Length; i++)
                if (currentEnemies[i] != null)
                    currentEnemyNumber++;

            return currentEnemyNumber;
        }
        
        private void SpawnBoss()
        {
            currentEnemies = new GameObject[1];
            int currentSpawnPointIndex = Random.Range(0, spawnPoints.Length);
            currentEnemies[0] = Instantiate(bossPrefab, spawnPoints[currentSpawnPointIndex].position,
                Quaternion.identity, enemiesParent.transform);
        }

        private void RandomlySpawnEnemies()
        {
            currentEnemies = new GameObject[enemiesPerRound];
            for (int j = 0; j < enemiesPerRound; j++)
            {
                int currentSpawnPointIndex = Random.Range(0, spawnPoints.Length);
                int meleeOrDistance = Random.Range(0, 2);
                currentEnemies[j] = Instantiate(meleeOrDistance == 0 ? meleeEnemyPrefab : rangedEnemyPrefab,
                    spawnPoints[currentSpawnPointIndex].position, Quaternion.identity, enemiesParent.transform);
            }
        }

        private void GetSpawnPoints()
        {
            if (spawnPointsParent.childCount == 0)
            {
                spawnPoints = new Transform[1];
                spawnPoints[0] = spawnPointsParent;
                return;
            }
            
            spawnPoints = new Transform[spawnPointsParent.childCount];
            for (var i = 0; i < spawnPointsParent.childCount; i++)
                spawnPoints[i] = spawnPointsParent.GetChild(i);
        }
    }
}