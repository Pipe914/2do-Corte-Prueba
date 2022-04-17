using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : MonoBehaviour
{
    public GameObject Player;
    public GameObject BulletEnemStaPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Player.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector2(-1f, 1f);
        else transform.localScale = new Vector2(1f, 1f);

        float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);

        if (distance < 2.0f)
        {
            Disparar();

        }

        void Disparar()
        {
            Vector2 Direction;
            if (transform.localScale.x == 1f) direction = Vector2.right;
            else direction = Vector2.left;


            //GameObject bullet = Instantiate(BulletEnemStaPrefab, transform.position + direction * .1f, Quaternion.identify);
            //bullet.GetComponent<BulletScript>().SetDirection(Direction); 
        }
    }
}
