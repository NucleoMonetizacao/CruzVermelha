using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class AdMobManager : MonoBehaviour
{
    private RewardBasedVideoAd rewardedAd;
    private string rewardedAdID = "ca-app-pub-3940256099942544~3347511713";
    // Start is called before the first frame update
    void Start()
    {
        rewardedAd = RewardBasedVideoAd.Instance;
        RequestRewardedAd();
    }

    public void RequestRewardedAd()
    {
        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request, rewardedAdID);
    }

    public void ShowRewardedAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
        else
        {
            Debug.Log("Rewarded ad not loaded");
        }
    }
}
