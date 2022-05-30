using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIDocument ContadorEnemigos;
    private int flyingEnemys, staticEnemys;


    // Start is called before the first frame update
    void Start()
    {
        flyingEnemys = GameObject.FindGameObjectsWithTag("FlyingEnemy").Length;
        staticEnemys = GameObject.FindGameObjectsWithTag("StaticEnemy").Length;
        StartCoroutine(startingCounters());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator startingCounters()
    {
        yield return new WaitForSeconds(.5f);
        FindObjectOfType<UIControllerContadorEnemigos>().ChangeContadorFlying(flyingEnemys);
        FindObjectOfType<UIControllerContadorEnemigos>().ChangeContadorStatic(staticEnemys);
        yield return null;
    }

    public IEnumerator countFlyingEnemys()
    {

        flyingEnemys--; 
        
        FindObjectOfType<UIControllerContadorEnemigos>().ChangeContadorFlying(flyingEnemys);

        yield return null;
    }

    public IEnumerator countStaticEnemys()
    {
        staticEnemys--;

        FindObjectOfType<UIControllerContadorEnemigos>().ChangeContadorStatic(staticEnemys);

        yield return null;
    }
}
