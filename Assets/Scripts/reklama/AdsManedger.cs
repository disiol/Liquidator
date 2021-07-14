using System;
using System.Collections;
using System.Collections.Generic;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
  

public class AdsManedger : MonoBehaviour, IInterstitialAdListener, INonSkippableVideoAdListener,
    IRewardedVideoAdListener
{
    public bool isTesting;
    private const string APP_KEY = "bdc24c94a54f2c10d2504f3ad8103f0dd0ff6fb418cc8811";
    public static AdsManedger instance;
    private bool videoFinished;
   
    public int caunteForShows = 5;
    private int caunteShowsReklams;
    private bool showAdsFalse;
    private bool showAdsTrue;

    // Start is called before the first frame update
    void Start()
    {
        bool restart = PlayerPrefs.GetInt(Restart.IS_RESTART, 0) == 1;

        Initialized(isTesting);

        StartCoroutine(checkInternetConnection((isConnected) =>
        {
            showAdsFalse = caunteShowsReklams <= caunteForShows;
            if (!isConnected || (showAdsFalse && restart))
            {
                
                SceneManager.LoadScene("Scenes/likvidator/licvidator");
            }
            else
            {
                showAdsTrue = caunteShowsReklams > caunteForShows;
                if (showAdsTrue)
                {
                    caunteShowsReklams = 0;
                }
                if (restart)
                {
                    caunteShowsReklams++;
                    ShowNonSkippable();

                }
                else if (!restart)
                {
                   ShowNonSkippable();

                }
            }
        }));
    }

    IEnumerator checkInternetConnection(Action<bool> action)
    {
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
            action(false);
        }
        else
        {
            action(true);
        }
    }

    public void ReclamaStart()
    {
        Debug.Log("AdsManedger ReclamaStart = ");

        SceneManager.LoadScene("Reclama");
    }
    // Update is called once per frame


    private void Initialized(bool isTesting)
    {
        Debug.Log("AdsManedger isTesting = " + isTesting);

        //TODO tae user data contract
        Appodeal.setTesting(isTesting);
        Appodeal.muteVideosIfCallsMuted(true);
        Appodeal.initialize(APP_KEY, Appodeal.INTERSTITIAL | Appodeal.NON_SKIPPABLE_VIDEO);
        Appodeal.setInterstitialCallbacks(this);
        Appodeal.setRewardedVideoCallbacks(this);
        Appodeal.setNonSkippableVideoCallbacks(this);
    }

    public void ShowInterstitial()
    {
        StartCoroutine(IEShowNonInterstitial());
    }

    public void ShowNonSkippable()
    {
        StartCoroutine(IEShowNonSkippable());
    }

    public IEnumerator IEShowNonInterstitial()
    {
        yield return new WaitUntil(() => Appodeal.canShow(Appodeal.INTERSTITIAL));
        Appodeal.show(Appodeal.INTERSTITIAL);
    }

    private static void StartGame()
    {
        SceneManager.LoadScene("Scenes/likvidator/licvidator");
    }

    private IEnumerator IEShowNonSkippable()
    {
        yield return new WaitUntil(() => Appodeal.canShow(Appodeal.NON_SKIPPABLE_VIDEO));
        Appodeal.show(Appodeal.NON_SKIPPABLE_VIDEO);
        
    }


    public void onRewardedVideoLoaded(bool precache)
    {
    }

    public void onRewardedVideoFailedToLoad()
    {
    }

    public void onRewardedVideoShowFailed()
    {
    }

    public void onRewardedVideoShown()
    {
    }

    public void onRewardedVideoFinished(double amount, string name)
    {
        StartGame();
        videoFinished = true; //it's important to set flag to true only  after all required parameters
    }

    public void onRewardedVideoClosed(bool finished)
    {
        //TODO mesedge ymast se video for end if yvont get it
    }

    public void onRewardedVideoExpired()
    {
    }

    public void onRewardedVideoClicked()
    {
    }

    #region InterstitialLogs

    public void onInterstitialLoaded(bool isPrecache)
    {
        Debug.Log("AdsManedger onInterstitialLoaded = " + isPrecache);
    }


    public void onInterstitialFailedToLoad()
    {
        Debug.Log("AdsManedger onInterstitialFailedToLoad FailedToLoad");
    }

    public void onInterstitialShowFailed()
    {
        Debug.Log("AdsManedger nterstitialShowFailed");
    }

    public void onInterstitialShown()
    {
    }

    public void onInterstitialClosed()
    {
        videoFinished = true;
        StartGame();
    }

    public void onInterstitialClicked()
    {
    }

    public void onInterstitialExpired()
    {
    }

    #endregion


    #region SkippableVideoLogs

    public void onNonSkippableVideoLoaded(bool isPrecache)
    {
        Debug.Log("AdsManedger onNonSkippableVideoLoaded = " + isPrecache);
    }

    public void onNonSkippableVideoFailedToLoad()
    {
        Debug.Log("AdsManedger onNonSkippableVideoFailedToLoad ");
    }

    public void onNonSkippableVideoShowFailed()
    {
        Debug.Log("AdsManedger onNonSkippableVideoShowFailed ");
        
    }

    public void onNonSkippableVideoShown()
    {
    }

    public void onNonSkippableVideoFinished()
    {
        Debug.Log("AdsManedger onNonSkippableVideoFinished ");
        StartGame();
    }

    public void onNonSkippableVideoClosed(bool finished)
    {
        
    }

    public void onNonSkippableVideoExpired()
    {
    }

    #endregion
}