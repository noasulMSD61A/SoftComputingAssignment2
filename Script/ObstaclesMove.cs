using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMove : MonoBehaviour
{
    public Transform[] waypoints;
    public int currentWP;
    public float speed;
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position != waypoints[currentWP].position)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, waypoints[currentWP].position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }
        else currentWP = (currentWP + 1) % waypoints.Length;

    }

}
