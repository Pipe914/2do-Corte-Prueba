using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] int healt;
    [SerializeField] float alcance;
    [SerializeField] float fireRate;
    private float nextFire, shootingDelay;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D shooting =  Physics2D.Raycast(transform.position, transform.right, alcance,LayerMask.GetMask("Player"));
        Debug.DrawRay(transform.position, transform.right * alcance, Color.blue);

        if (shooting.collider != null)
        {
            shoot();
        }
    }

    void shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Bullet, transform.position, transform.rotation);
        }

    }
}
