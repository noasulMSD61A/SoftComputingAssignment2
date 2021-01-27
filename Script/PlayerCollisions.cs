using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    // Start is called before the first frame update
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
            print("you lost");
        }
        if (collision.gameObject.tag == "obstacle")
        {
            print("you lost");
        }
        if (collision.gameObject.tag == "finishline")
        {
            if (GameManager.snakeLenghtdraw >= 1)
            {
                GameManager.lvl1done = true;
            }
        }
        if (collision.gameObject.tag == "finishlinelvl2")
        {
            if (GameManager.snakeLenghtdraw >= 1)
            {
                GameManager.lvl2done = true;
            }
        }
    }
}
