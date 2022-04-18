using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeReference] int healt;
    AIPath myPath;
    
    // Start is called before the first frame update
    void Start()
    {
        myPath = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        chasingPlayer();
    }
    void chasingPlayer()
    {
        // Alternativa 1: Vector2.Distance
        /*float distancia = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log("La distancia es: " + distancia);
        if(distancia < 8)
        {

        }
        Debug.DrawLine(transform.position, player.transform.position, Color.red);
        */

        // Alternativa 2: OverlapCircle
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, 5f, LayerMask.GetMask("Player"));

        if (playerCollider != null)
            myPath.isStopped = false;
        else
            myPath.isStopped = true;
    }

    public void hit(int damage)
    {
        healt -= damage;
        if (healt <= 0)
            Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("Choque con player");
            Player p = collision.gameObject.GetComponent<Player>();
            p.hit();
        }
    }
}
