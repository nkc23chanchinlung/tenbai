using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyManager enemyManager;
    [SerializeField]int speed =3;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
      FindTarget(enemyManager.Target);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    GameObject FindTarget(GameObject target)
    {
        transform.position = Vector3.MoveTowards(transform.position,target.transform.position, speed * Time.deltaTime);
        return target;
    }
    
}
