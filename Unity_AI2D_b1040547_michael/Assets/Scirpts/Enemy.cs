using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("傷害"), Range(0, 100)]
    public float damge = 20;
    public Transform checkPoint;

    private Rigidbody2D r2d;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="肉球")
        {
            collision.gameObject.GetComponent<Meatball>().Damage(damge);
        }
    }

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    

    private void Move()
    {
        r2d.AddForce(-transform.right*speed);

       RaycastHit2D hit = Physics2D.Raycast(checkPoint.position, -checkPoint.up, 3, 1 << 8);
        if (hit == false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }
}

