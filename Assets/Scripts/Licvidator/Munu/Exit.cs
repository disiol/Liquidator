using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Button buttonExit;
    public GameObject panelMenu;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        buttonExit.GetComponent<Button>().onClick.AddListener((() =>
        {
            Application.Quit();
        }));
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelMenu.SetActive(true);
        }
    }
    
}
