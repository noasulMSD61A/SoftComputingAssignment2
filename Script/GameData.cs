using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameData : MonoBehaviour
{
    private static float _timer1;
    private static float _currentScore;
    private static float _highestScore;
    private static InputField _username;
    


    // Start is called before the first frame update
    public static float Timer
    {
        get { return _timer1; }
        set { _timer1 = value; }
    }


    public static InputField Username
    {
        get { return _username; }
        set { _username = value; }
    }

    public static float CurrentScore
    {
        get { return _currentScore; }
        set { _currentScore = value; }
    }

    public static float HighestScore
    {
        get { return _highestScore; }
        set { _highestScore = value; }
    }



}
