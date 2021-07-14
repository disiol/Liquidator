using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideShowMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject startButton;

    // Start is called before the first frame update
    void Start()
    {
        
        bool  restart= PlayerPrefs.GetInt(Restart.IS_RESTART, 0) == 1;

        if (restart)
        {

            menu.SetActive(false);
            startButton.SetActive(false);
            PlayerPrefs.SetInt(Restart.IS_RESTART, 0); 

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
