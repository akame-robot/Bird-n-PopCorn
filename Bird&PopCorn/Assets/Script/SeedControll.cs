using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedControll : MonoBehaviour
{

    public float seedVelocity;

    private Vector2 seedFollow;

    // Start is called before the first frame update
    void Start()
    {
        seedFollow = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, seedFollow, seedVelocity * Time.deltaTime);
        Destroy(gameObject, 1.1f);
    }
}
