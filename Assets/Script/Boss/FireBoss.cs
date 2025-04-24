using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    Idle,
    Move,
    Attack,
    Dead
}
public enum Sill
{
    FireBall,
    FireWall,
    FireRain
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
    BossState state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        state = GetState();
        Debug.Log(state);
       
        switch (state) //bossÇÃèÛë‘
        {
            case BossState.Idle:
                Idle();
                break;
            case BossState.Move:
                Move();
                break;
            case BossState.Attack:
                Attack();
                break;
            case BossState.Dead:
                Dead();
                break;
        }

    }
    BossState GetState()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < 10) return BossState.Move;
        return BossState.Idle;
    }
    void Idle()
    {

    }
   private void Move()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (state == BossState.Move)
        {
           
            // Move to player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * Time.deltaTime*Speed;
        }
    }
    void Attack() { }
    void Dead() { }
    
}
