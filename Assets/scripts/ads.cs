using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Monetization;

// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public class ads : MonoBehaviour
{
    string gameId = "3156155";
    bool testMode = true;
    public string placementId = "rewardedVideo";

    void Start()
    {
        Monetization.Initialize(gameId, testMode);
    }
   
    public void ShowAd()
    {
        StartCoroutine(WaitForAd());
    }
    IEnumerator WaitForAd()
    {
        while (!Monetization.IsReady(placementId))
        {
            yield return null;
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;

        if (ad != null)
        {
            ad.Show(AdFinished);
        }
    }

    void AdFinished(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            globalMoney.setMoney(20);
        }
    }
}