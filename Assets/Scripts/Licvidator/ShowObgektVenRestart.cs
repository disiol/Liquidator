using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObgektVenRestart : MonoBehaviour
{
        public GameObject mufeCube;

    // Start is called before the first frame update
    void Start()
    {
        bool restart = PlayerPrefs.GetInt(Restart.IS_RESTART, 0) == 1;

        if (restart)
        {
            mufeCube.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}