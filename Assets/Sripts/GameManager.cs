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
       StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator startingCounters()
    {
        flyingEnemys = GameObject.FindGameObjectsWithTag("FlyingEnemy").Length;
        staticEnemys = GameObject.FindGameObjectsWithTag("StaticEnemy").Length;
        yield return new WaitForSeconds(.5f);
        FindObjectOfType<UIControllerContadorEnemigos>().ChangeContadorFlying(flyingEnemys);
        FindObjectOfType<UIControllerContadorEnemigos>().ChangeContadorStatic(staticEnemys);
        ContadorEnemigos.GetComponent<UIDocument>().rootVisualElement.Q("Cont-Enemys").style.display = DisplayStyle.Flex;
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

    IEnumerator StartGame()
    {
        StartCoroutine(startingCounters());
        Time.timeScale = 0;
        yield return null;
    }
}
