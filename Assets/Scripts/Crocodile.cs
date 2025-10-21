using UnityEngine;

// คลาส Crocodile สืบทอดมาจาก Enemy
public class Crocodile : Enemy
{
    [SerializeField]
    private float atkRange;             // ระยะการโจมตีของจระเข้

    public PlayerController player;     // ตัวละครเป้าหมายที่จะโจมตี

    // เรียกครั้งแรกเมื่อเกมเริ่ม (ก่อน Update)
    void Start()
    {
        // เรียกเมธอด Initialize ของคลาสแม่ พร้อมส่งพลังชีวิต 50
        base.Initialize(50);

        DamageHit = 30;  // ตั้งค่าความเสียหายที่จะทำ

        atkRange = 6.0f; // กำหนดระยะโจมตี

        // หาตัว PlayerController ตัวแรกในซีน
        player = GameObject.FindFirstObjectByType<PlayerController>();
    }

    // FixedUpdate ใช้สำหรับฟิสิกส์ อัปเดตในทุก ๆ เฟรมที่ฟิกซ์
    private void FixedUpdate()
    {
        Behavior();
    }

    // กำหนดพฤติกรรมของ Crocodile ในการตรวจสอบระยะและยิง
    public override void Behavior()
    {
        // หาค่าระยะห่างระหว่าง Crocodile กับ Player
        Vector2 distance = transform.position - player.transform.position;

        // ถ้า Player อยู่ในระยะโจมตี
        if (distance.magnitude <= atkRange)
        {
            Debug.Log($"{player.name} is in the {this.name}'s atk range!");
            Shoot();
        }
    }

    // ฟังก์ชันยิงหินใส่ Player
    public void Shoot()
    {
        Debug.Log($"{this.name} shoots rock to the {player.name}!");
    }

    // Update ถูกเรียกทุกเฟรม (ว่างไว้ในที่นี้)
    void Update()
    {

    }
}
