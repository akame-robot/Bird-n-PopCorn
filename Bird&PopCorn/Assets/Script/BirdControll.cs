using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControll : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    public GameObject mouth;
    public GameObject seed;

    private bool canFlip;
    private Vector2 originalScale;

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
        flip.x = -0.6f;
        transform.localScale = flip;
        }

        if (!canFlip)
        {
            Vector2 flip = transform.localScale;
            flip.x = 0.6f;
            transform.localScale = flip;
        }
    }

    public void DontGoOffcamera()
    {
        if (transform.position.x < -11.77f)
        {
            transform.position = new Vector2(-11.76f, transform.position.y);
        }
        if (transform.position.x > 11.77f)
        {
            transform.position = new Vector2(11.76f, transform.position.y);
        }
    }
}
