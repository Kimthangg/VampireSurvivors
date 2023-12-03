using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    public float Time;
    private GameObject gameController;  
    // Start is called before the first frame update
    void Start() 
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        Destroy(this.gameObject, Time);
    }
    // xóa quái vật và đạn
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            gameController.GetComponent<GameController>().EndGame();
            //collision.GetComponent<PlayerMovement>().Die();
        }
    }
}