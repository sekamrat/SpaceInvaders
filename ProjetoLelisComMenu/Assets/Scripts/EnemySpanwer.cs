using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float minX = -40f, maxX = 40f;
    public float minY = 30f, maxY = 50f;
    public float minDistance = 5f; // Distância mínima entre inimigos
    public float minSpawnInterval = 0.15f; // Novo: intervalo mínimo permitido

    private float nextSpawnTime;
    private float difficultyTimer = 0f;
    private List<GameObject> activeEnemies = new List<GameObject>();

    void Update()
    {
        // Remove inimigos destruídos da lista
        activeEnemies.RemoveAll(e => e == null);

        if (Time.time >= nextSpawnTime)
        {
            TrySpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }

        // Aumenta a dificuldade gradualmente e de forma mais agressiva
        difficultyTimer += Time.deltaTime;
        if (difficultyTimer > 7f && spawnInterval > minSpawnInterval)
        {
            // Reduz o intervalo de spawn mais rápido e até um valor menor
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval * 0.85f);
            difficultyTimer = 0f;
        }
    }

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            TrySpawnEnemy();
        }
        nextSpawnTime = Time.time + spawnInterval;
    }

    void TrySpawnEnemy()
    {
        for (int i = 0; i < 10; i++) // Tenta até 10 vezes achar um lugar livre
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            Vector3 pos = new Vector3(x, y, 50f);

            bool tooClose = false;
            foreach (var enemy in activeEnemies)
            {
                if (Vector3.Distance(enemy.transform.position, pos) < minDistance)
                {
                    tooClose = true;
                    break;
                }
            }

            if (!tooClose)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, pos, Quaternion.identity);
                activeEnemies.Add(newEnemy);
                break;
            }
        }
    }
}
