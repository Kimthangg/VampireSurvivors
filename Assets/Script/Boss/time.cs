using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    public float Time;

    // Start is called before the first frame update
    void Start() 
    {
        Destroy(this.gameObject, Time);
    }
    // xóa quái vật và đạn
    // private void OnTriggerEnter2D(Collider2D collision)
    // {

    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         Destroy(collision.gameObject);
    //         collision.GetComponent<PlayerMovement>().Die();
    //     }
    // }
}