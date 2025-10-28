using System.Data;
using UnityEngine;


public class Crocodile : Enemy , IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    [field: SerializeField] public float ReloadTime { get; set; }
    [field: SerializeField] public float WaitTime { get; set; }
    [SerializeField]
    private float atkRange = 6.0f;     // ระยะโจมตี (เก็บไว้เผื่อใช้ต่อยอด เช่น ระยะพ่นน้ำ)
    private bool isPlayerEnter = false;  // ตรวจว่ากำลังชนผู้เล่นหรือไม่
    public Player player;    // ตัวแปรอ้างอิงถึงผู้เล่น

    void Start()
    {
        base.Initialize(50);           // พลังชีวิตเริ่มต้น
        DamageHit = 10;                // ความแรงโจมตี

        //set timer variable for thoring rock
        WaitTime = 10.0f;
        ReloadTime = 5.0f;

   
    }

    // Crocodile ชนกับวัตถุอื่น
private void OnTriggerStay2D(Collider2D playerDetection)
{
    if (playerDetection.gameObject.CompareTag("Player"))
    {
        isPlayerEnter = true;
        player = playerDetection.gameObject.GetComponent<Player>();
        Debug.Log($"{player.name} Has Entered Crocodile Attack Range {this.name}!");
        Shoot();
    }
}

private void OnTriggerExit2D(Collider2D playerDetection)
{
    if (playerDetection.gameObject.GetComponent<PlayerController>() != null)
    {
        isPlayerEnter = false;
        Debug.Log($"{player.name} Has Escaped Crocodile Attack Range {this.name}!");
    }
}


    /// โจมตีผู้เล่นเมื่อชนกัน
    public void Shoot()
    {
        if (WaitTime >= ReloadTime)
        {
            anim.SetTrigger("Shoot");
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Rocks rocks = bullet.GetComponent<Rocks>();
            rocks.InitWeapons(30,this);
            WaitTime = 0.0f;
        }
    }

    /// พฤติกรรมของ Crocodile (เรียกทุกเฟรมฟิสิกส์)
    public override void Behavior()
    {
        /*Vector2 distance = transform.position - player.transform.position;
        if (distance.magnitude <= atkRange)
        {
            Debug.Log($"{player.name} is in the {this.name}'s atk range!");
            Shoot();
        }*/
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }
}
