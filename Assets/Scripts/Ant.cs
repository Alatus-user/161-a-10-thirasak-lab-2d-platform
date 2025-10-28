using UnityEngine;

public class Ant : Enemy
{
    [SerializeField]
    private Vector2 velocity;          // ความเร็วของมด (ทิศทางและขนาด)

    public Transform[] movePoints;     // จุดที่มดจะเดินไปถึง (0 = ซ้าย, 1 = ขวา)

    /// เกมเริ่ม 
    void Start()
    {
        base.Initialize(20);           // กำหนดพลังชีวิตเริ่มต้นของมด = 20
        DamageHit = 10;               // ความแรงของการโจมตี = 100

        velocity = new Vector2(-2.0f, 0.0f);  // ตั้งค่าให้มดเริ่มเดินไปทางซ้าย
    }

    /// พฤติกรรมหลักของมด — เดินไปมาระหว่างสองจุด
    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        // ถ้ามดเดินไปทางซ้าย (x < 0) แล้วถึงจุดซ้ายสุด → พลิกกลับ
        if (velocity.x < 0 && rb.position.x <= movePoints[0].position.x)
        {
            Flip();
        }

        // ถ้ามดเดินไปทางขวา (x > 0) แล้วถึงจุดขวาสุด → พลิกกลับ
        if (velocity.x > 0 && rb.position.x >= movePoints[1].position.x)
        {
            Flip();
        }
    }

    public void Flip()
    {
        // กลับทิศทางความเร็วในแกน X
        velocity.x *= -1;

        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    /// FixedUpdate — เรียกทุกเฟรมฟิสิกส์ ใช้สำหรับการเคลื่อนที่
    private void FixedUpdate()
    {
        Behavior();
    }

    /// Update — เฟรมต่อเฟรม
    void Update()
    {
    }
}
