using System;
using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed = 3f;
    public Transform target;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 1f;
    public float bulletLifetime = 2f; // Thời gian tồn tại của đạn
    public float bulletSpeed = 5f; // Tốc độ di chuyển của đạn
    private float nextFireTime;
    public float mau = 50;
    private Transform player;
    public static event Action OnBossActivation;
    private GameObject gameController;
    private bool bossActivated=false;
    

    
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextFireTime = Time.time + 1 / fireRate; // Set initial fire time
        Enemy.OnEnemyKilled += CheckEnemyCount;
        gameObject.SetActive(false);
    }

     void OnDestroy()
    {
        // Hủy đăng ký sự kiện khi hủy đối tượng
        Enemy.OnEnemyKilled -= CheckEnemyCount;
    }

    void Update()
    {
        if (target != null)
        {
            // Calculate the direction to the player
            Vector3 direction = target.position - transform.position;

            // Normalize the direction to get a unit vector
            direction.Normalize();

            // Move towards the player
            transform.Translate(direction * speed * Time.deltaTime);

            // Check if it's time to fire
            if (Time.time >= nextFireTime)
            {
                // Call the function to shoot
                StartCoroutine(Shoot());
                nextFireTime = Time.time + 1 / fireRate; // Update next fire time
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            if (gameController != null)
            {
                gameController.GetComponent<GameController>().EndGame();
            }
        }

    }

    IEnumerator Shoot()
    {
        // Instantiate a new bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Lấy hướng từ Boss đến mục tiêu (Player)
        Vector3 shootingDirection = target.position - bulletSpawnPoint.position;

        // Tránh va chạm ngay từ khi đạn được sinh ra bằng cách dời vị trí bắt đầu về phía trước một chút
        Vector3 bulletStartPosition = bulletSpawnPoint.position + shootingDirection.normalized * 1f;

        // Set the bullet's position
        bullet.transform.position = bulletStartPosition;

        // Set the bullet's direction
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = shootingDirection.normalized * bulletSpeed;

        // Hủy đạn sau thời gian tồn tại
        yield return new WaitForSeconds(bulletLifetime);
        Destroy(bullet);

        // Spawn lại đạn sau khi đạn cũ biến mất
        StartCoroutine(Shoot());
    }
    public void TakeDamage(int damageAmount)
    {
        
        mau -= damageAmount;

        if (mau <= 0)
        {
            DeactivateBoss();
            Destroy(gameObject);
        }
    }
    void CheckEnemyCount()
    {
        // Kiểm tra xem đã giết đủ enemy chưa
        if (Enemy.count >= 2 && !bossActivated)
        {
            // Nếu đã giết đủ, thì kích hoạt boss
            TryActivateBoss();
        }
    }

    public void TryActivateBoss()
    {
        if (!gameObject.activeSelf)
        {
            Debug.Log("Try to activate boss");
            OnBossActivation?.Invoke();
            ActivateBoss();
        }
    }

    void ActivateBoss()
    {
        Debug.Log("Boss activated");
        bossActivated=true;
        gameObject.SetActive(true);
    }
    void DeactivateBoss()
    {
        Debug.Log("Boss deactivated");
        bossActivated = false;
        gameObject.SetActive(false);
    }
}
    

