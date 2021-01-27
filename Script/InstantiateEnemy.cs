using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour
{
    private GameObject enemy;
    private GameObject food;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {

        food = GameObject.FindWithTag("food");
        
        enemy = Resources.Load<GameObject>("Enemy");
        if (GameManager.isloaded == true)
        {
            StartCoroutine(enemySnake());
        }
        if(GameManager.isloaded2 == true)
        {
            StartCoroutine(enemySnake2());
        }
        
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    IEnumerator enemySnake()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(enemy, food.transform.position, Quaternion.identity);
        
    }

    IEnumerator enemySnake2()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(enemy, new Vector2(-8f,8f), Quaternion.identity);

    }

}
