using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{
    public GameObject winText;
    public GameObject notwinText;
    public Text NameBox;
    public Text Score;
    public Text ScoreCurrent;
    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        beaten();
        NameBox.text = PlayerPrefs.GetString("name");
        ScoreCurrent.text = GameData.Timer.ToString();
        
        Score.text = PlayerPrefs.GetFloat("highscore").ToString();
    }

    public void beaten()
    {
        if (GameManager.sethighscore == true)
        {
            
            winText.gameObject.SetActive(true);
        }
        else
        {
            notwinText.gameObject.SetActive(true);
        }
    }
}
