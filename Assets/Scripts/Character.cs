using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //parameter
    private int health;
    public int currentHealth;
    public HealthBar healthBar;
    public int Health { get => health; set => health= (value< 0 )? 0: value; }

    protected Animator anim;
    protected Rigidbody2D rb;

    //method


    public void Initialize(int startHealth)
    {
        health = startHealth;
        Debug.Log($"{this.name} initial Health: {this.health}");

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        healthBar.SetHealth(health);
        Debug.Log($"{this.name} Took Damage: {damage}  Current Health: {Health}");
        if (IsDead()) return;
    }


    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log($"{this.name} is dead and vanished ");
            return true;
        }
        else return false;
    }
    void Start()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(Health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
