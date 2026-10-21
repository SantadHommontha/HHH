using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   //ความเร็วตัวะคร
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    public Transform item;
    public SpriteRenderer flashlight;

    public GameObject playerBody;
    
    public bool turnRight = true;

   //public  Vector2 direction;

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
        Vector2 direction = (mousePos - item.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        item.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        //ถ้าเม้าส์อยู่ทางขวา
        if(direction.x > 0 && !turnRight)
        {
          Flip();
          ChangeOrderLayer();
        }
        //ถ้าเม้าส์อยู่ทางซ้าย     
        if(direction.x < 0 && turnRight)
        {
          Flip();
          ChangeOrderLayer();
        }
         

    }

    void FixedUpdate()
    {
      //  rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;
      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
       // rb.MoveRotation(angle);
    }


  void Flip()
  {
    //เอาค่า scale มาเก็บไว่้ก่อรน
    Vector3 currnetScale = playerBody.transform.localScale;
    //เปลี่ยนค่า scale x เป็นค่าตรงข้ามด้วยการคูณด้วย -1
    currnetScale.x *=-1;
    //เอาค่าที่เปลี่ยนไปใช่
    playerBody.transform.localScale = currnetScale;
    //เปลี่ยนค่า turnRight เป็นค่าตรงข้าม
    turnRight = !turnRight;
  }

  void ChangeOrderLayer()
  {
  
    if(flashlight != null)
    {
      if(turnRight)
      {
        flashlight.sortingOrder = 1;
      }
      else
      {
        flashlight.sortingOrder = -1;
      }
    }
  }

}
