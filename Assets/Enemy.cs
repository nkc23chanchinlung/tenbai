using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        Target=GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    GameObject FIndTarget(GameObject target)
    {
        return target;
    }
}
