using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    public int maxEnemies = 5;
    public int size = 10;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < maxEnemies; i++)
        {
           float posx=Mathf.Sin(Mathf.PI * 2*i/maxEnemies)*size;
           float posy=Mathf.Cos(Mathf.PI * 2*i/ maxEnemies)*size;
            Instantiate(enemyPrefab, new Vector3(posx, posy, 0), quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
