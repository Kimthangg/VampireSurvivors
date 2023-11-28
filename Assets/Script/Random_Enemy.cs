using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Enemy : MonoBehaviour
{
    public GameObject enemyPrefab;  // Kéo và thả Prefab kẻ địch vào đây
    public int numberOfEnemies = 5;  // Số lượng kẻ địch cần tạo ra
    public float spawnRadius = 10f;  // Bán kính để tạo ra kẻ địch

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Tạo ra một vị trí ngẫu nhiên trong bán kính spawnRadius
            Vector3 randomPosition = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = new Vector3(randomPosition.x, randomPosition.y , -5f) + transform.position;

            // Tạo ra kẻ địch tại vị trí ngẫu nhiên
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            //Gắn tốc độ ngẫu nhiên
            float randomSpeed = Random.Range(1f, 2.5f);
            enemy.GetComponent<Enemy>().speed = randomSpeed;
        }
    }
}
