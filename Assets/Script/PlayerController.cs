using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] bool unrivaled;
    [Header("Weapon")]
    [SerializeField]WeaponManager weaponManager;
    
    [SerializeField]GameObject[] Weapon;
    [Header("Player Stats")]
    [SerializeField] int speed;
    [SerializeField] int maxhp;
    [SerializeField] int hp;
    [SerializeField] float MaxWpCooldown;
    public float weaponCooldown { get; set; }
    public int _speed { get { return speed; } set { speed = value; } }
    CircleCollider2D circleCollider2d;
    
    // Start is called before the first frame update
    void Start()
    {
        weaponCooldown = 2;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Controller(speed);
        Attack();

    }
    private void Controller(int speed)
    {
        float Vec = Input.GetAxis("Vertical");
        float Hor = Input.GetAxis("Horizontal");
        transform.position += new Vector3(Hor, Vec, 0).normalized * Time.deltaTime * speed;
        if (Vec != 0 || Hor != 0)
        {
            if (Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
    }
    private void Attack()
    {
        weaponCooldown -= Time.deltaTime;
        if (weaponCooldown < 0)
        {
            Instantiate(Weapon[0], transform.position-transform.up, transform.rotation);
            weaponCooldown = MaxWpCooldown;

        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Damage")
        {
            hp -= 1;
            Destroy(collision.gameObject);
        }
        
    }
}
