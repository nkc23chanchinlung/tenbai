using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
   ParticleSystem particle_fire;
    bool fire;
    float firetimer;
    // Start is called before the first frame update
    void Start()
    {
        particle_fire=GetComponentInChildren<ParticleSystem>();
        particle_fire.Pause();
        fire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fire)
        {
            particle_fire.Play();
            firetimer += Time.deltaTime;
            if(firetimer >= 3.5f)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            Debug.Log("Hit");
            fire = true;    
        }
    }
}
