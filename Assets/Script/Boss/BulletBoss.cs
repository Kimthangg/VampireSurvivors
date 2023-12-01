using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    public float speed = 5f; // Adjust the bullet speed as needed
    private Vector3 direction;

    void Update()
    {
        // Move the bullet in its current direction
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Set the direction of the bullet
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }

    // Destroy the bullet when it collides with something
    void OnTriggerEnter(Collider other)
    {
        // Add any specific logic for bullet collision, if needed
        Destroy(gameObject);
    }
}
