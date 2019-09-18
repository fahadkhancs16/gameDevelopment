using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 6f;
   public bool isPlayer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer) {
            transform.Translate(0f, Input.GetAxis("Vertical") * speed*Time.deltaTime, 0f);
        }

        else
        {
            transform.Translate(0f, Input.GetAxis("Vertical2") * speed*Time.deltaTime, 0f);
        }

    }
}
