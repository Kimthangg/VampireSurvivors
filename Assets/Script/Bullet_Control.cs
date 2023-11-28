using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform DiemSinhDan;
    public GameObject bulletPrefab;
    public float buttetSpeed = 2.5f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            var bullet  = Instantiate(bulletPrefab,DiemSinhDan.position, DiemSinhDan.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = DiemSinhDan.up * buttetSpeed;
        }
    }
}
