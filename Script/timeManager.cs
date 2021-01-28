using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeManager : MonoBehaviour
{

    public bool started;
    public float valTimer = 0f;
    Text textTime;

    // Start is called before the first frame update
    void Start()
    {

        textTime = GetComponent<Text>();
        StartCoroutine(timer());
    }

    
    IEnumerator timer()
    {
        while (true)
        {
            if (started)
            {
                //GameManager.valTimer++;
                valTimer = GameData.Timer++;

                float minutes = valTimer / 60f;
                float seconds = valTimer % 60f;

                textTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);


                
                yield return new WaitForSeconds(1f);
            }
            else
            {
                
                valTimer = 0f;
                textTime.text = string.Format("{0:00}:{1:00}", 0f, 0f);
                yield return null;

            }

        }
    }


    
}
