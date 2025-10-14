using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //absrtact
    private int health;
    public int Health { get => health; set => health= (value< 0 )? 0: value; }

    protected Animator anim;
    protected Rigidbody2D rb;

    //method

    public void TakeDamage(int damage)
    {
        Health =- damage;
        Debug.Log($"{this.name}Took Damage{damage}  Current Health{Health}");
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
