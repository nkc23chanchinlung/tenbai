using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    public int maxEnemies = 5;
    int size = 10;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < maxEnemies; i++)
        {
           float posx=Mathf.Sin(Mathf.PI * i/maxEnemies)*size;
           float posy=Mathf.Cos(Mathf.PI * i/ maxEnemies)*size;
            Instantiate(enemyPrefab, new Vector3(posx, posy, 0), quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
