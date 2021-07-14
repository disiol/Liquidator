using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    public static string IS_RESTART = "is restart";

    void Start()
    {

    }
    void OnMouseUp()
    {
        PlayerPrefs.SetInt(Restart.IS_RESTART, 1);
        SceneManager.LoadScene("Reclama");
    }
}