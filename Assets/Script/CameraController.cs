using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position =Vector3.MoveTowards(transform.position, player.position + new Vector3(0, 0, -10), Time.deltaTime * 5);
    }
}
