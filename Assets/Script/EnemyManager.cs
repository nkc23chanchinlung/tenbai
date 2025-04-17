using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Target { get; private set; }
    
    [SerializeField] GameObject[] enemyPrefab;
    public int maxEnemies = 5;
    public int size = 10;
    [SerializeField] float responTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindWithTag("Player");
        Respon(enemyPrefab[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Respon(GameObject obj)
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            float posx = Mathf.Sin(Mathf.PI * 2 * i / maxEnemies) * size;
            float posy = Mathf.Cos(Mathf.PI * 2 * i / maxEnemies) * size;
            Instantiate(obj, new Vector3(posx, posy, 0)+Target.transform.position, quaternion.identity);
        }
    }
}
