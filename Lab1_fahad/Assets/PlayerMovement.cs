using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    //public float speed;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    //static int score;
    public Animator playerAnimator;
    bool midjump = false;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        rb = GetComponent<Rigidbody2D>();
        playerAnimator.SetBool("idle", true);
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth),
            Mathf.Clamp(transform.position.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight));

        if(Input.GetKeyDown("space") && midjump == false)
        {
            playerAnimator.SetBool("jump",true);
            rb.velocity = new Vector2(0f, 20f);
            midjump = true;
        } 
    }

    
    private void Die()
    {
        int hscore = PlayerPrefs.GetInt("HScore");
        if (CoinCalculator.coinAmount >= hscore)
        {
            PlayerPrefs.SetInt("HScore", CoinCalculator.coinAmount);
        }
        SceneManager.LoadScene("GameOver");
        Destroy(rb.gameObject);
    }

    IEnumerator dieWave()
    {
        while (true)
        {
            playerAnimator.SetBool("die", true);
            yield return new WaitForSeconds(1);
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("GoldCoin"))
        {
            CoinCalculator.coinAmount += 5;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("SilverCoin"))
        {
            CoinCalculator.coinAmount += 2;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("BronzeCoin"))
        {
            CoinCalculator.coinAmount += 1;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("Obstacle"))
        {
            Destroy(col.gameObject);
            StartCoroutine(dieWave());
        }
        else if (col.gameObject.CompareTag("Ground"))
        {
            playerAnimator.SetBool("jump", false);
            midjump = false;
        }
    }
}
