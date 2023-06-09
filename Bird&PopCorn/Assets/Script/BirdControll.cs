using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControll : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement();
    }

    public void movement()
    {
        float horiMove = Input.GetAxisRaw("Horizontal");
        Vector2 moveSide = new Vector2 (horiMove, 0);
        rb.velocity = moveSide * moveSpeed;
    }
    
}
