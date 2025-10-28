using UnityEngine;


public class Crocodile : Enemy
{
    [SerializeField]
    private float atkRange = 6.0f;     // ระยะโจมตี (เก็บไว้เผื่อใช้ต่อยอด เช่น ระยะพ่นน้ำ)
    private bool isPlayerEnter = false;  // ตรวจว่ากำลังชนผู้เล่นหรือไม่
    public PlayerController player;    // ตัวแปรอ้างอิงถึงผู้เล่น
    private bool hasAttacked = false;   // เช็คโจมตีหรือไม่

    void Start()
    {
        base.Initialize(50);           // พลังชีวิตเริ่มต้น
        DamageHit = 10;                // ความแรงโจมตี

   
    }

    // Crocodile ชนกับวัตถุอื่น
private void OnTriggerEnter2D(Collider2D playerDetection)
{
    if (playerDetection.gameObject.CompareTag("Player") && !hasAttacked)
    {
        isPlayerEnter = true;
        player = playerDetection.gameObject.GetComponent<PlayerController>();
        hasAttacked = true;
        Debug.Log($"{player.name} Has Entered Crocodile Attack Range {this.name}!");
        Shoot();
            return;
    }
}

private void OnTriggerExit2D(Collider2D playerDetection)
{
    if (playerDetection.gameObject.GetComponent<PlayerController>() != null)
    {
        isPlayerEnter = false;
        hasAttacked = false;
        Debug.Log($"{player.name} Has Escaped Crocodile Attack Range {this.name}!");
    }
}


    /// โจมตีผู้เล่นเมื่อชนกัน
    public void Shoot()
    {
        if (player == null) return;

        Debug.Log($"{this.name} Attack {player.name}!");
    }

    /// พฤติกรรมของ Crocodile (เรียกทุกเฟรมฟิสิกส์)
    public override void Behavior()
    {
        if (isPlayerEnter)
        {
            // เพิ่มระบบคูลดาวน์โจมตี
        }
    }

    private void FixedUpdate()
    {
        Behavior();
    }
}
