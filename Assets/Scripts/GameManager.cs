using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text loseText;
    public int ScoreToWin;

    void Start()
    {
        loseText.text = "";
        
    }

    public void Win()
    {
        loseText.text = "You Win!";
    }

    public void die()
    {
        loseText.text = "You Lose!";
    }
}
