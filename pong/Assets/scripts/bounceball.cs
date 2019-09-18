using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceball : MonoBehaviour
{
    public float speed;
    float sx, sy;
    // Start is called before the first frame update
    void Start()
    {
        sx = Random.Range(0, 2) == 0 ? -1 : 1;
        sy = Random.Range(0, 2) == 0 ? -1 : 1;
        GetComponent<Rigidbody>().velocity = new Vector3(sx * speed, sy * speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
