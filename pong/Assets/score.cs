using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    public Text left;
    public Text right;
    int scoreCounterLeft;
    int scoreCounterRight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        {
            if (col.gameObject.CompareTag("leftBarrior"))
            {
                scoreCounterRight++;
                right.text = scoreCounterRight.ToString();
            }
            if (col.gameObject.CompareTag("rightBarrior"))
            {
                scoreCounterLeft++;
                left.text = scoreCounterLeft.ToString();
            }
        }
    }
}