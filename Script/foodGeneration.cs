using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodGeneration : MonoBehaviour
{
    public bool notOnObst = true;
    private GameObject food;
    List<Vector2> foodSpawned = new List<Vector2>();
    Vector2 foodpositionrecs = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        food = Resources.Load<GameObject>("food");
        foodGenerator();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            Destroy(food);
            notOnObst = false;
        }
    }

    public void foodGenerator()
    {
        while (foodSpawned.Count < 6)
        {
            float randX = Mathf.Floor(Random.Range(-9f, 9f));
            float randY = Mathf.Floor(Random.Range(-9f, 9f));
            bool distant = false;

            foodpositionrecs = new Vector2(randX, randY);

            if (foodSpawned.Count == 0)
            {
                Instantiate(food, foodpositionrecs, Quaternion.identity);
                foodSpawned.Add(foodpositionrecs);
            }

            else
            {
                for (int i = 0; i < foodSpawned.Count; i++)
                {
                    if (Vector2.Distance(foodSpawned[i], foodpositionrecs) < 4)
                    {
                        distant = true;
                    }
                }

                if (distant == false)
                {
                    Instantiate(food, foodpositionrecs, Quaternion.identity);
                    foodSpawned.Add(foodpositionrecs);
                }
            }
        }
    }
}

   
