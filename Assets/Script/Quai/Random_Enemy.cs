using System.Collections;
using UnityEngine;

public class Random_Enemy : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int maxNumberOfEnemies = 10; //Sl max

    public float spawnRadius = 10f; //Bán kính sản sinh
    public float timeBetweenSpawns = 2f; //Thời gian giữa các lần sản sinh

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(SpawnEnemyRoutine());
    }
    //Hàm đợi để tạo enemy theo thời gian
    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            if (CountEnemies() < maxNumberOfEnemies)
            {
                SpawnEnemies();
            }

            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    //hàm trả về số lượng enemy hiện có
    int CountEnemies()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void SpawnEnemies()
    {
        // Tính toán vị trí spawn sao cho quái không gần người chơi
            //Bán kính sinh sản
        Vector3 randomPosition = Random.insideUnitCircle.normalized * spawnRadius;
            //Vị trí sinh sản
        Vector3 spawnPosition = new Vector3(randomPosition.x, randomPosition.y, -5f) + transform.position;

        // Đảm bảo khoảng cách tối thiểu giữa quái và người chơi
        if (Vector3.Distance(spawnPosition, player.position) < 10)
        {
            spawnPosition += (spawnPosition - player.position).normalized * 10;
        }

        // Tạo quái tại vị trí tính toán
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        float randomSpeed = Random.Range(1f, 2.5f);
        float random_Mau = Random.Range(20f, 100f);
        enemy.GetComponent<Enemy>().speed = randomSpeed;
        enemy.GetComponent<Enemy>().target = player;
        enemy.GetComponent<Enemy>().mau = random_Mau;
    }
}
