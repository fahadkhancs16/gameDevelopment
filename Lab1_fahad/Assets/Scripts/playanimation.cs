using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playanimation : MonoBehaviour
{
    // Start is called before the first frame update


    Rigidbody2D rb;
    bool isFacingRight;
    public float Speed;
    public Animator playerAnimator;
    void Start()
    {

        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        playerAnimator.SetFloat("speed",Mathf.Abs(horizontal));
        Vector2 movement = new Vector2(horizontal, 0f);

        rb.velocity = movement;

        if (isFacingRight == true && horizontal < 0)
        {
            FlipFace();
        }
        else if (isFacingRight == false && horizontal > 0)
        {
            FlipFace();
        }
    }

    void FlipFace()
    {

        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
        }

    }
}
