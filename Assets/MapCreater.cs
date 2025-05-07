using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreater : MonoBehaviour
{
    [SerializeField] int amout;
    [SerializeField] int x, y;
    [SerializeField] GameObject treeprebeb;
    
    [SerializeField] Transform Map;
    // Start is called before the first frame update
    void Start()
    {
        
        

        for (int x = -this.x; x < this.x; x++)
        {
            for (int y = -this.y; y < this.y; y++)
            {
                Instantiate(treeprebeb, new Vector3(x * Random.Range(1,10), y * Random.Range(1, 10), 0), Quaternion.identity,Map.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
