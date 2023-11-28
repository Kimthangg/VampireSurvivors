using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public Vector3 direction;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Lấy giá trị đầu vào từ trục ngang và trục dọc
        float ngang_input = Input.GetAxis("Horizontal");
        float doc_input = Input.GetAxis("Vertical");

        // Tính toán hướng dựa trên giá trị đầu vào
        direction = new Vector3(ngang_input, doc_input, 0);
        //Chuẩn hoá nó thành vector
        direction.Normalize();

        // Di chuyển theo hướng đã tính toán
        transform.Translate(direction * speed * Time.deltaTime);
        //Đảo ngược player khi nó đi về bên trái
        if (ngang_input < 0)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
        else if(ngang_input > 0)
        {
            transform.localScale = new Vector3(-2, 2, 1);
       }

       //Hiệu ứng chuyển khi di chuyển
        if (direction.magnitude > 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
    //Xử lí khi chạm vào enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
    public void Die()
    {
        animator.SetBool("Moving",true);
        // Thêm các hành động khi player chết, ví dụ: hiển thị game over, tắt collider, v.v.
        Debug.Log("Game Over!");
    }
}