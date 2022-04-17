using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] GameObject player;
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }
}
