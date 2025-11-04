using UnityEngine;

public class Player : Character, IShootable
{
   [field:SerializeField] public GameObject Bullet { get; set ; }
  [field: SerializeField]  public Transform ShootPoint { get; set; }
    [field: SerializeField]public float ReloadTime { get; set; }
   [field: SerializeField] public float WaitTime { get; set; }

    public HealthBar healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         base.Initialize(100);
        ReloadTime = 1.0f;
        WaitTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void FixedUpdate()
    {
        WaitTime += Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            OnHitWithEnemy(enemy);
            Debug.Log($"{this.name} Collide with  {enemy.name}");

        }
    }

    public void OnHitWithEnemy(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime)
        { 
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null)
                banana.InitWeapons(20, this);
            WaitTime = 0f;
        }
    }
}
