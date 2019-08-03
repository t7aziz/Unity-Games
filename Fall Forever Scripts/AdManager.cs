using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    //public string bannerID = "ca-app-pub-1189205913959749/5650759302";
    //public string interstitialID = "ca-app-pub-1189205913959749/3556801207";

    public string appID = "ca-app-pub-1189205913959749~2421960736";
    private BannerView bannerAD;
    private InterstitialAd interstitialAd;

    void Start()
    {
        //FOR REAL APP
        MobileAds.Initialize(appID);

        RequestBanner();
        RequestInterstitial();

    }

    void RequestBanner()
    {
        string banner_ID = "ca-app-pub-1189205913959749/5650759302";
        bannerAD = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Top);

        //FOR REAL APP
        AdRequest adRequest = new AdRequest.Builder().Build();

        // FOR TESTING
        //AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        // REAL APP
        bannerAD.LoadAd(adRequest);
    }
    void RequestInterstitial()
    {
        string interstitial_ID = "ca-app-pub-1189205913959749/3556801207";
        interstitialAd = new InterstitialAd(interstitial_ID);

        //FOR REAL APP
        AdRequest adRequest = new AdRequest.Builder().Build();

        // FOR TESTING
        //AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        // REAL APP
        interstitialAd.LoadAd(adRequest);
    }

    public void Display_Banner()
    {
        bannerAD.Show();
    }
    public void Display_InterstitialAD()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
    }

    // HANDLE EVENTS
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Display_Banner();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    void HandleBannerADEvents(bool subscribe)
    {
        if (subscribe)
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded += HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening += HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed += HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded -= HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening -= HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed -= HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
        }
    }

    void OnEnable()
    {
        HandleBannerADEvents(true);
    }

    void OnDisable()
    {
        HandleBannerADEvents(false);
    }
}

