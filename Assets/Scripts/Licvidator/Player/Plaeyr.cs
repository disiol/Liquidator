using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Debug = UnityEngine.Debug;

public class Plaeyr : MonoBehaviour
{
    public AudioSource bonbInPlaer;
    private int lastrBestScore;
    private int score;

    private float lastrBestSpeed;
    private float speed;
    private int lifes;

  

    private void Start()
    {
        lifes = GameControl.instance.lifes;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            if (lifes == 1)
            {
                GameControl.instance.LiicvidatorDied();
            }
            else
            {
                GameControl.instance.UpdatePointsTextLifes();
                
                GameControl.instance.lifes --;
                lifes = GameControl.instance.lifes;




                bonbInPlaer.Stop();
                bonbInPlaer.Play();
            }
        }
    }
}