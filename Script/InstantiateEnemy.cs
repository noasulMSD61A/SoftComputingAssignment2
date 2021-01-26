using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour
{
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = Resources.Load<GameObject>("Enemy");
        Instantiate(enemy, new Vector2(-8f,8f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
