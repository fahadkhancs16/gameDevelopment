using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    
    Rigidbody2D rb;
    bool isFacingRight;
    public float Speed;
    public Text score;
    public Animator PlayerAnimator;

    int scoreCount;
    void Start()
    {
        
        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        PlayerAnimator.SetFloat("Speedparam", Mathf.Abs(horizontal));
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);

        rb.velocity = movement*Speed;

        if (isFacingRight == true && horizontal < 0)
        {
            FlipFace();
        }
        else if(isFacingRight == false && horizontal > 0) {
            FlipFace();
        }
    }

    void FlipFace() {
    
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;


    }

   void OnCollisionEnter2D(Collision2D col) {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Coin")) {
           Destroy(col.gameObject);
            scoreCount++;
            score.text = "Score:" + scoreCount.ToString();
        }
        
    }

}
