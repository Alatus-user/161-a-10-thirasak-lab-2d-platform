using UnityEngine;

public class Rocks : Weapons
{
    public Rigidbody2D rb;
    [SerializeField ] public Vector2 force;

    public override void Move()
    {
        rb.AddForce(force);
    }

    public override void OnHitWith(Character character)
    {
        if (character is Player)
        {
            character.TakeDamage(this.damage);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damage = 40;
        force = new Vector2(GetShootDirection() * 90, 400);
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
