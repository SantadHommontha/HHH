using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   //ความเร็วตัวะคร
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
   public  float angle;

    void Start()
    {
         // ดึง component CharacterController มาเก็บไว่ในตัวแปร controller
        rb = GetComponent<Rigidbody2D>();
        
       
    }
   

   
       
    
    // }
    void Update()
    {
       
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        
        movement = movement.normalized;
 
       
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position);
         angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
      //  transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void FixedUpdate()
    {
      //  rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;
      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(angle);
    }
}
