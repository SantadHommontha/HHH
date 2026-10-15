using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   //ความเร็วตัวะคร
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
         // ดึง component CharacterController มาเก็บไว่ในตัวแปร controller
        rb = GetComponent<Rigidbody2D>();
        
       
    }
   

    // void Update()
    // {
    //     //ถ้ากด A จะส่งค่า -1 ถ้ากด D จะส่งค่า 1 ถ้าไม่กดจะส่งค่า 0
    //     float moveX = Input.GetAxis("Horizontal"); 
    //      //ถ้ากด W จะส่งค่า 1 ถ้ากด S จะส่งค่า 0 ถ้าไม่กดจะส่งค่า 0
    //     float moveY = Input.GetAxis("Vertical");  

    //     // ทำให้ความเร็วเวลาเดินเฉียง (เช่น W+D) วิ่งเท่ากับเดินตรง
    //     movement = movement.normalized;

    //     rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
       
        
     

    //     // หาตำแหน่งที่เม้าส์ของเราชี้อยู่บนจอว่าอยู่ตำแหน่งไหนในแมพ
    //     Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //      // ค่าค่า Z เป็น 0 เพราะเป็นเกม 2D
    //     mousePos.z = 0f;

    //     //หาทิศทางจากตัวละคร ไปยังตำแหน่งของเม้าส์
    //     Vector3 direction = (mousePos - transform.position).normalized;
    //     //แปรงทิศทางจากให้เป็นเป็นมุน
    //     float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //     //สั่งให้หมุนตัวละครในแกน Z ไปที่มุนที่เราหามาได้
    //     transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

       
    
    // }
    void Update()
    {
        // 1. รับค่าปุ่มกดเดิน (W, A, S, D หรือปุ่มลูกศร)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        // ทำให้ความเร็วเวลาเดินเฉียง (เช่น W+D) วิ่งเท่ากับเดินตรง
        movement = movement.normalized;
 
        // 2. คำนวณให้ตัวละครหันหน้าตามตำแหน่งเมาส์
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void FixedUpdate()
    {
        // 3. ขยับตำแหน่งตัวละครด้วยฟิสิกส์ 2D (ทำให้เดินชนกำแพงและ Tilemap ได้ปกติ)
       rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
