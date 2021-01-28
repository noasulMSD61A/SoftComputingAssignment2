using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{
    public Text NameBox;
    public Text Score;
    // Start is called before the first frame update
    void Start()
    {
        NameBox.text = PlayerPrefs.GetString("name");

    }

    // Update is called once per frame
    void Update()
    {
        
        Score.text = PlayerPrefs.GetFloat("highscore").ToString();
    }
}
