using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Meatball : MonoBehaviour
{
    public int speed = 50;
    public float jump = 2.5f;
    public string MeatballName = "肉球";
    public bool pass = false;
    public bool isGround;


    [Header("血量"), Range(0, 200)]
    public float hp = 100;

    public Image hpBar;
    public GameObject final;

    private float hpMax;

    public UnityEvent onEat;

    private Rigidbody2D r2d;
    //private Transform tra;


    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        //tra = GetComponent<Transform>();
        


        hpMax = hp;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) TurnRight();
        if (Input.GetKeyDown(KeyCode.A)) TurnLeft();
  
    }

    private void FixedUpdate()
    {
        Walk();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "硬幣")
        {
            Destroy(collision.gameObject);
            onEat.Invoke();
        }
    }

    private void Walk()
    {
        r2d.AddForce(new Vector2(speed*Input.GetAxis("Horizontal"),0));
    }
    private void TurnRight()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
    private void TurnLeft()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump )); 
        }
            
    }

    public void Damage(float damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp / hpMax;
        if (hp <= 0) final.SetActive(true);
    }
}
