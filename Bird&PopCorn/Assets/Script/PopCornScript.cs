using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCornScript : MonoBehaviour
{

    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "seed")
        {
            score += 100;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("seed"))
        {
            score += 100;
            Destroy(this.gameObject);

        }

        if (collision.gameObject.CompareTag("floor"))
        {
            score -= 50;
            Destroy(this.gameObject);
        }

        if (score <= 0)
        {
            score = 0;
        }
    }
}
