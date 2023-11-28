using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;  // Adjust the speed as needed
    public Transform target;  // Drag and drop the player GameObject here
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem đối tượng va chạm có phải là player không
        if (other.CompareTag("Player"))
        {
            // Xử lý khi quái chạm vào player
            Destroy(other.gameObject);
            other.GetComponent<PlayerMovement>().Die();

        }
    }

}

