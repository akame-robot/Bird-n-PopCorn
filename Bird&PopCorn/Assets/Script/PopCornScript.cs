using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCornScript : MonoBehaviour
{

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
            Destroy(this.gameObject);
        }
    }
}