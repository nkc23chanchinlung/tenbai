using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]GameObject[] Weapon;
    public float weaponCooldown { get; set; }
    public int speed { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        weaponCooldown = 2;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Move(speed);
        Attack();

    }
    private void Move(int speed)
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
            weaponCooldown = 2;

        }
    }
}
