using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float fireRate;
    [SerializeField] GameObject bullet;
    Rigidbody2D myBody;
    Animator myAnimator;
    float nextFire, shootingDelay;
    int direcShooting;
    bool isGrounded = true;
    bool iJump = false;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 1.3f, LayerMask.GetMask("Ground"));
        Debug.DrawRay(transform.position, Vector2.down * 1.3f, Color.red);
        //Debug.Log("Colisionando con: " + ray.collider.gameObject.name);

        isGrounded = ray.collider !=  null;

        jump();
        falling();
        fire(); 

    }
    void fire()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            if (Time.time > nextFire)
            {
                myAnimator.SetLayerWeight(1, 1);
                shootingDelay = Time.time + 0.5f;
                nextFire = Time.time + fireRate;
                if(direcShooting == 1)
                    Instantiate(bullet, myBody.transform.position, Quaternion.Euler(0,0,0));
                if(direcShooting == -1)
                    Instantiate(bullet, myBody.transform.position, Quaternion.Euler(0,180,0));
            }
                
        }
        if (Time.time > shootingDelay)
            myAnimator.SetLayerWeight(1, 0);
    }

    void jump()
    {
        if (isGrounded)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                iJump = true;
            }
            
        }

        if (myBody.velocity.y != 0 && !isGrounded && iJump)
            myAnimator.SetBool("isJumping", true);
        else
            myAnimator.SetBool("isJumping", false);
            iJump = false;
    } 
    
    void falling()
    {
        if (myBody.velocity.y != 0 && !isGrounded && !iJump)
            myAnimator.SetBool("isFalling", true);
        else
            myAnimator.SetBool("isFalling", false);
    }

    private void FixedUpdate()
    {
        float dirH = Input.GetAxis("Horizontal");
        if (dirH > 0)
        {
            transform.localScale = new Vector2(1, 1);
            direcShooting = 1;
            myAnimator.SetBool("isRunning", true);
            myBody.velocity = new Vector2(dirH * speed, myBody.velocity.y);
        }
        if (dirH < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            direcShooting = -1;
            myAnimator.SetBool("isRunning", true);
            myBody.velocity = new Vector2(dirH * speed, myBody.velocity.y);
        }
        if (dirH == 0)
        {
            myAnimator.SetBool("isRunning", false);
        }

    }

    public void hit()
    {
        // Colocar gameover
        Destroy(gameObject);
    }
}
