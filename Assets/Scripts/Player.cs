using UnityEngine;

public class Player : Character
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            OnHitWithEnemy(enemy);
            Debug.Log($"{this.name} hit {enemy.name}");

        }
    }

    // ฟังก์ชันเมื่อโดนศัตรูโจมตี ลดพลังชีวิตตามความเสียหายที่ศัตรูทำได้
    public void OnHitWithEnemy(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }
}
