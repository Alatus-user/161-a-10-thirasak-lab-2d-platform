using UnityEngine;


public class Crocodile : Enemy
{
    [SerializeField]
    private float atkRange = 6.0f;     // ระยะโจมตี (เก็บไว้เผื่อใช้ต่อยอด เช่น ระยะพ่นน้ำ)

    private bool isPlayerEnter = false;  // ตรวจว่ากำลังชนผู้เล่นหรือไม่

    public PlayerController player;    // ตัวแปรอ้างอิงถึงผู้เล่น

    void Start()
    {
        base.Initialize(50);           // พลังชีวิตเริ่มต้น
        DamageHit = 10;                // ความแรงโจมตี

   
    }

    /// เรียกอัตโนมัติเมื่อ Crocodile ชนกับวัตถุอื่น
  private void OnTriggerEnter2D(Collider2D playerDetection)
{
    if (playerDetection.gameObject.CompareTag("Player"))
    {
        isPlayerEnter = true;
        player = playerDetection.gameObject.GetComponent<PlayerController>();
        Debug.Log($"{player.name} เข้ามาในระยะของ {this.name}!");
        Shoot();
    }
}

private void OnTriggerExit2D(Collider2D playerDetection)
{
    if (playerDetection.gameObject.GetComponent<PlayerController>() != null)
    {
        isPlayerEnter = false;
        Debug.Log($"{player.name} หนีออกจากระยะของ {this.name} แล้ว!");
    }
}


    /// โจมตีผู้เล่นเมื่อชนกัน
    public void Shoot()
    {
        if (player == null) return;

        Debug.Log($"{this.name} โจมตี {player.name}!");
    }

    /// พฤติกรรมของ Crocodile (เรียกทุกเฟรมฟิสิกส์)
    public override void Behavior()
    {
        if (isPlayerEnter)
        {
            // สามารถเพิ่มระบบคูลดาวน์โจมตี หรือ Damage over time ได้ที่นี่
        }
    }

    private void FixedUpdate()
    {
        Behavior();
    }
}
