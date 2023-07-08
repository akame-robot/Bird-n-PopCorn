using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdControll : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    public GameObject mouth;
    public GameObject seed;

    private bool canFlip;
    [SerializeField] private bool isJumpWalk;
    private Vector2 originalScale;

    int gravity = -50;



    //11.77f


    void Start()
    {
        originalScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement();
        DontGoOffcamera();

    }

    public void movement()
    {
        float horiMove = Input.GetAxisRaw("Horizontal");
        Vector2 moveSide = new Vector2(horiMove, 0);
        rb.velocity = moveSide * moveSpeed;

        if (isJumpWalk && moveSide != Vector2.zero)
        {
            Vector2 walkIdle = transform.position;
            walkIdle.y = -3.43f;
            transform.position = walkIdle;
        }
        if (transform.position.y >= -3.53f)
        {
            isJumpWalk = false;
        }
        else if (transform.position.y < -3.53f)
        {
            isJumpWalk = true;
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootSeed();
        }

        if (horiMove < 0)
        {
            canFlip = true;
            if (canFlip)
            {
                FlipObject();
            }
        }
        else if (horiMove > 0)
        {
            canFlip = false;
            if (!canFlip)
            {
                FlipObject();
            }
        }
    }

    public void ShootSeed()
    {
        Instantiate(seed, mouth.transform.position, Quaternion.identity);
    }

    public void FlipObject()
    {
        if (canFlip)
        {
            Vector2 flip = transform.localScale;
            flip.x = -1f;
            transform.localScale = flip;
        }

        if (!canFlip)
        {
            Vector2 flip = transform.localScale;
            flip.x = 1f;
            transform.localScale = flip;
        }
    }

    public void DontGoOffcamera()
    {
        if (transform.position.x < -8.48f)
        {
            transform.position = new Vector2(-8.47f, transform.position.y);
        }
        if (transform.position.x > 8.48f)
        {
            transform.position = new Vector2(8.47f, transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("popcorn"))
        {
            Debug.Log("collided");
            PopCornScript.score = 0;
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
