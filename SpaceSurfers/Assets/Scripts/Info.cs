using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Info : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Points;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score : " + Mathf.Round(player.GetComponent<spaceship>().distanceTravelled).ToString();
        Points.text = "Points : " + player.GetComponent<spaceship>().pts.ToString();
    }
}
