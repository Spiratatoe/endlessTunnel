using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Points;
    public void easy()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
        SceneManager.LoadScene("Game");
    }

    public void medium()
    {
        PlayerPrefs.SetInt("Difficulty", 2);
        SceneManager.LoadScene("Game");
    }

    public void hard()
    {
        PlayerPrefs.SetInt("Difficulty", 3);
        SceneManager.LoadScene("Game");
    }
    
    void Update()
    {
        Score.text = "Score : " + PlayerPrefs.GetString("Score");
        Points.text = "Points : " + PlayerPrefs.GetString("Points");
    }
}
