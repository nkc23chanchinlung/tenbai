using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum BossState
{
    Idle,
    Battle,
    Attack_Short,
    Attack_Long,
    Dead
}
public enum Skill
{
    FireBall,
    FireWall,
    FireRain,
    num,
}
public class FireBoss : MonoBehaviour
{
    
    [Header("Prefebs")]
    [SerializeField]Transform player;
    [SerializeField] GameObject range;
    [Header("State")]
    [SerializeField] private int Speed;
    [SerializeField] int Hp_Max;
    [SerializeField] float Hp;
    [SerializeField] int Cooldown_Max=3;
    
    Transform Target;
    BossState state;
    float Battletimer;
    float distance;
    float Cooldown;
    [SerializeField]GameObject[] Skilllist = { };
    // Start is called before the first frame update
    void Start()
    {
        state = BossState.Idle;
        Cooldown = Cooldown_Max;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);
       
       
       
        switch (state) //bossÇÃèÛë‘
        {
            case BossState.Idle:
                Idle();
                break;
            case BossState.Battle:
                Battle();
                break;
            case BossState.Attack_Short:
                Attack_Short();
                break;
            case BossState.Attack_Long:
                Attack_Long();
                break;
            case BossState.Dead:
                Dead();
                break;
        }

    }
  
    void Idle()
    {
        if (distance < 10) state= BossState.Battle;
        transform.position =Vector2.MoveTowards(transform.position, new Vector2(0,-3), Speed * Time.deltaTime);
    }
   private void Battle()
    {
        Cooldown -= Time.deltaTime;
        if (state==BossState.Attack_Long) return; 
        // Move to player
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * Time.deltaTime*Speed;
        if (distance > 5) Battletimer += Time.deltaTime;
        else Battletimer = 0;
        if (Battletimer > 5) state = BossState.Idle;
        if(distance>5&&Cooldown<=0)state=BossState.Attack_Long;
        



    }
    void Attack_Short()
    {

    }
    void Attack_Long()
    {

        if (Cooldown <= 0)
        {
            for(int i = 0; i < 3;i++)
            Instantiate(Skilllist[(int)Skill.FireBall], transform.position - (transform.up*(i*3)), transform.rotation);
            Cooldown = Cooldown_Max;
            state = BossState.Battle;
            
        }
        else state=BossState.Battle;
    }
    void Dead() 
    { 
    
    }
    
}
