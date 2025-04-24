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
public class FireBoss : MonoBehaviour
{
    
    [Header("Prefebs")]
    [SerializeField]Transform player;
    [SerializeField] GameObject area;
    [Header("State")]
    [SerializeField] private int Speed;
    [SerializeField] int Hp_Max;
    [SerializeField] float Hp;
    BossState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BossState.Move;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Debug.Log(state);
    }
   private void Move()
    { 
    if(state == BossState.Move)
        {
           
            // Move to player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * Time.deltaTime*Speed;
        }
    }
    
}
