using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.youlost = true;
        }
        if (collision.gameObject.tag == "obstacle")
        {
            GameManager.youlost = true;
        }
        if (collision.gameObject.tag == "enemy")
        {
            GameManager.youlost = true;
        }
        

        if (collision.gameObject.tag == "finishline")
        {
            if (GameManager.snakeLenghtdraw >= 6)
            {
                GameManager.lvl1done = true;
            }
        }
        if (collision.gameObject.tag == "finishlinelvl2")
        {
            if (GameManager.snakeLenghtdraw >= 9)
            {
                GameManager.lvl2done = true;
            }
        }

        if (collision.gameObject.tag == "finishlinelvl3")
        {
            if (GameManager.snakeLenghtdraw >= 12)
            {
                GameManager.lvl3done = true;
            }
        }
    }
}
