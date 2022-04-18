using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] GameObject player;
    private Rigidbody2D myBulet;
    private Animator myAnimator;
    private float destroyTime;
    private bool destroy = false;

    // Start is called before the first frame update
    void Start()
    {
        myBulet = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myBulet.velocity = myBulet.transform.right * velocidad;
        if (destroy)
        {
            if (destroyTime < Time.time)
                Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            destroyTime = Time.time + 0.2f;
            myAnimator.SetBool("inCollision", true);
            velocidad = 0;
            destroy = true;
        }

    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FlyingEnemy"))
        {
            FlyingEnemy enemy = GetComponent<FlyingEnemy>();
            enemy.hit(damage);
        }


    }*/

}