using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyKilled : MonoBehaviour
{
    public int killed = 0;
    public Text points;
    public GameOverScreen GameOverScreen;
    public YouWinScript YouWinScript;
    public PlayerHealth PlayerHealth;

    public void Win()
    {
        YouWinScript.Setup(killed);
        PlayerHealth.Clear();
    }
    public void Failed()
    {
        GameOverScreen.Setup(killed);
    }
    public void Count()
    {
        killed++;
        points.text = "POINTS: " + killed;
    }
}
