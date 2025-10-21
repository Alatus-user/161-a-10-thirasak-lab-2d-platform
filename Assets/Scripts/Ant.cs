using UnityEngine;

// คลาส Ant สืบทอดมาจาก Enemy
public class Ant : Enemy
{
    [SerializeField]
    private Vector2 velocity;         // ความเร็วและทิศทางการเคลื่อนที่ของมด

    public Transform[] MovePoint;     // จุดที่มดจะเคลื่อนที่ไป-กลับ (0 = ซ้าย, 1 = ขวา)

    // เรียกครั้งแรกเมื่อเกมเริ่ม (ก่อน Update)
    void Start()
    {
        base.Initialize(20);          // เริ่มต้นพลังชีวิตมด 20
        DamageHit = 100;               // ตั้งค่าความเสียหาย

        velocity = new Vector2(-2.0f, 0.0f); // เคลื่อนที่ไปทางซ้ายเริ่มต้น
    }

    // กำหนดพฤติกรรมการเคลื่อนที่ของมด
    public override void Behavior()
    {
        // เคลื่อนที่ตาม velocity โดยใช้ Rigidbody2D.MovePosition (ควบคุมฟิสิกส์)
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        // ถ้ามดวิ่งไปทางซ้าย และถึงจุดซ้ายสุด
        if (velocity.x < 0 && rb.position.x <= MovePoint[0].position.x)
        {
            Flip(); // กลับทิศทาง
        }

        // ถ้ามดวิ่งไปทางขวา และถึงจุดขวาสุด
        if (velocity.x > 0 && rb.position.x >= MovePoint[1].position.x)
        {
            Flip(); // กลับทิศทาง
        }
    }

    // ฟังก์ชันเปลี่ยนทิศทางการเคลื่อนที่และพลิกภาพมด
    public void Flip()
    {
        velocity.x *= -1; // เปลี่ยนทิศทางของความเร็ว

        // พลิกภาพมดโดยการกลับค่า localScale ในแกน x
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // FixedUpdate ใช้สำหรับอัปเดตฟิสิกส์ 
    public void FixedUpdate()
    {
        Behavior();
    }

    // Update ถูกเรียกทุกเฟรม (เว้นว่างไว้)
    void Update()
    {

    }
}
