using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeDestroyer : MonoBehaviour
{
    public float Time;
    public int damage = 10;
    
    // Start is called before the first frame update
    void Start() 
    {
        Destroy(this.gameObject, Time);
    }
    //xử lí khi quái vật và đạn va chạm
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
