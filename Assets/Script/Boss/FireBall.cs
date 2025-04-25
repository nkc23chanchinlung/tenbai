using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] Transform Player;
    Vector3 rot;
    // Start is called before the first frame update
    void Start()
    {
       
        Player =GameObject.FindWithTag("Player").transform;
        rot = Player.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, rot);

        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {

       

        transform.position += transform.up * Time.deltaTime * 10f;
    }
}
