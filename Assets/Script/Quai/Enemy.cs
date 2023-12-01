using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public Transform target;
    public float mau;
    
    void Update()
    {
        if (target != null)
        {
            // Di chuyển enemy theo hướng của player
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
    public void TakeDamage(int damageAmount)
    {
        mau -= damageAmount;

        if (mau <= 0)
        {
            Destroy(gameObject);
        }
    }
}