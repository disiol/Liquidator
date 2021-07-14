using System;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameControl : MonoBehaviour
{
    public static GameControl instance; //A reference to our game control script so we can access it statically.

    public GameObject scoreText;
    public GameObject scorePanel;

    public GameObject gameOverText;
    public GameObject gameOverTextPanel;

    public GameObject ButtonMenu;

    public GameObject plaeyr;

    public int lifes;


    public int points = 0; //The player's score.
    public float fallSpead = 3f;
    public bool gameOver = false; //Is the game over?
    private float lastrBestScore = 0;

    private float lastrBestfallSpead;
    private static string SAVE_KEY = "liquidator safe data";
    private string scoreTextGet;

    public AudioSource bangSound;
    public AudioSource backgroundMusic;
    
    public int SureseVenGifeExtraLife; // 0lifese vem ekstra hard


    private void Start()
    {
        UpdatePointsTextLifes();
        
    }

    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
          //...destroy this one because it is a duplicate.
        Destroy(gameObject);


        scoreTextGet = scoreText.GetComponent<TextMeshProUGUI>().text;
        UpdatePointsTextLifes();
    }


    public void LiicvidatorScored(Boolean flag)
    {
        //The bird can't score if the game is over.
        if (!gameOver)
        {
            if (flag)
            {
                points++;
            }
            else if (!flag)
            {
                points--;
            }
            UpdatePointsTextLifes();
        }

        if ((points % SureseVenGifeExtraLife) == 0)
        {
            fallSpead = fallSpead + 0.1f;
            lifes++;
        }

        if (gameOver)
        {

        }
    }

    public void LiicvidatorDied()
    { 
        backgroundMusic.Stop();
        ButtonMenu.SetActive(false);
        SafeBestResult();

        GameOverTextShow();

        plaeyr.SetActive(false);
    }


    public void UpdatePointsTextLifes()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = String.Format(scoreTextGet, points, lifes);
    }

    #region Save

    private void SafeBestResult()
    {
        if (PlayerPrefs.HasKey(SAVE_KEY))
        {
            LoadDataFromJason();
            if (lastrBestScore < points)
            {
                lastrBestScore = points;
            }

            if (lastrBestfallSpead < fallSpead)
            {
                lastrBestfallSpead = fallSpead;
            }

            SaveDataToJason();
        }
        else
        {
            lastrBestScore = points;
            lastrBestfallSpead = fallSpead;
            SaveDataToJason();
        }
    }

    private void GameOverTextShow()
    {

        scorePanel.SetActive(false);
        gameOverTextPanel.SetActive(true);

        string textGamover = gameOverText.GetComponent<TextMeshProUGUI>().text;
        Debug.Log("textGamover = " + textGamover);
        gameOverText.GetComponent<TextMeshProUGUI>().text =
            String.Format(textGamover, points, fallSpead, lastrBestScore, lastrBestfallSpead);
        gameOver = true;
    }


    #region SaveData

    public class SaveData
    {
        public float bestScore;
        public float bestfallSpead;
    }

    private void SaveDataToJason()
    {
        string key = SAVE_KEY;
        SaveData data = new SaveData();
        data.bestScore = this.lastrBestScore;
        data.bestfallSpead = this.lastrBestfallSpead;

        string value = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }

    private void LoadDataFromJason()
    {
        string key = SAVE_KEY;
        string value = PlayerPrefs.GetString(key);
        SaveData data = JsonUtility.FromJson<SaveData>(value);

        SetBestScore(data.bestScore);
        SetbestfallSpead(data.bestfallSpead);
    }

    private void SetbestfallSpead(float dataBestfallSpead)
    {
        this.lastrBestfallSpead = dataBestfallSpead;
    }

    private void SetBestScore(float dataBestScore)
    {
        this.lastrBestScore = dataBestScore;
    }

    #endregion

    #endregion
}