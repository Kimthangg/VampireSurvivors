using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class Bullet : MonoBehaviour
// {
//     public float life = 3;
//     void Awake(){
//         Destroy(gameObject, life);
//     }

//     void OnCollisionEnter2D(Collision2D collision){
//         Destroy(collision.gameObject);
//         Destroy(gameObject);
//     }


public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public Transform target; // Enemy's transform

    void Update()
    {
        // Kiểm tra xem target đã được đặt chưa
        if (target != null)
        {
            // Calculate the direction to the player
            Vector3 direction = target.position - transform.position;

            // Normalize the direction to get a unit vector
            direction.Normalize();

            // Move towards the player
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            // Nếu target không tồn tại, hủy bỏ đạn
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem đạn va chạm vào enemy không
        if (other.CompareTag("Enemy"))
        {
            // Xử lý khi đạn va chạm vào enemy
            Destroy(other.gameObject); // Hoặc thực hiện hành động khác
            Destroy(gameObject);
        }
    }
}


