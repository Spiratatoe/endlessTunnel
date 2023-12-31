using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Info : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Points;
    public TextMeshProUGUI Bullet;
    public TextMeshProUGUI Boost;
    public TextMeshProUGUI Health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score : " + Math.Round(player.GetComponent<spaceship>().distanceTravelled);
        Points.text = "Points : " + player.GetComponent<spaceship>().pts;
        Bullet.text = "Bullet : " + player.GetComponent<spaceship>().nbBullets;
        Boost.text = "Boost : " + player.GetComponent<spaceship>().currentBoostAmount;
        Health.text = "Health : " + player.GetComponent<spaceship>().hp + " / " + player.GetComponent<spaceship>().maxHp;
    }
}
