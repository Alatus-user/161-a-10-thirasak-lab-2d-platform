using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Weapons : MonoBehaviour
{


    [SerializeField] public int damage;
    public IShootable Shooter;
    public abstract void Move();
    public abstract void OnHitWith(Character character);

    public void InitWeapons(int newDamage, IShootable newShooter)
    {
        damage = newDamage;
        Shooter = newShooter;
    }

    public int GetShootDirection()
    {
        float value = Shooter.ShootPoint.position.x - Shooter.ShootPoint.parent.position.x;
        if (value > 0)
            return 1;  //face right
        else return -1; //face left
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null)
        { 
            OnHitWith(character);
            Destroy(this.gameObject, 1f);
        }

    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
