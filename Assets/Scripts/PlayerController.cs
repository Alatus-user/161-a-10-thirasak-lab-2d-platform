using UnityEngine;
using System.Collections;

public class PlayerController : Character
{
    // --- Public variables ---
    public float maxSpeed = 10f;           // ความเร็วสูงสุดของตัวละคร
    public bool grounded = false;          // เช็คว่าตัวละครอยู่บนพื้นหรือไม่
    public Transform groundCheck;          // ตำแหน่งสำหรับตรวจสอบพื้น
    public LayerMask whatIsGround;         // เลเยอร์ของพื้นที่สามารถยืนได้
    public float jumpForce = 700.0f;       // แรงกระโดด

    // --- Private variables ---
    bool facingRight = true;                // เช็คว่าหันไปทางขวาหรือไม่
    Rigidbody2D r2d;                       // เก็บ Rigidbody2D ของตัวละคร
    Animator anim;                         // เก็บ Animator ของตัวละคร
    float groundRadius = 0.2f;             // รัศมีตรวจจับพื้น

    // --- Unity methods ---

    void Start()
    {
        // ดึงคอมโพเนนต์ Rigidbody2D และ Animator
        r2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // เรียกฟังก์ชัน Initialize จาก class พ่อแม่ (Character)
       
    }

    void Update()
    {
        // ตรวจสอบการกดปุ่มกระโดด (Space) และตัวละครต้องอยู่บนพื้นเท่านั้น
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            r2d.AddForce(new Vector2(0, jumpForce));
        }
    }

    void FixedUpdate()
    {
        // ตรวจสอบว่าตัวละครอยู่บนพื้นหรือไม่ โดยใช้ Physics2D.OverlapCircle
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        // อัพเดตค่าแนวตั้งของความเร็วสำหรับอนิเมชัน (กระโดดหรือตก)
        anim.SetFloat("vSpeed", r2d.velocity.y);

        // รับค่าการเคลื่อนที่แนวนอน (ซ้าย-ขวา)
        float move = Input.GetAxis("Horizontal");

        // อัพเดตอนิเมชันความเร็ว
        anim.SetFloat("Speed", Mathf.Abs(move));

        // กำหนดความเร็วการเคลื่อนที่ตัวละคร
        r2d.velocity = new Vector2(move * maxSpeed, r2d.velocity.y);

        // พลิกตัวละครเมื่อเปลี่ยนทิศทาง
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    // --- Custom methods ---

    // พลิกตัวละครโดยสลับค่าทิศทาง และปรับ localScale เพื่อกลับด้าน sprite
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

 
    
}
