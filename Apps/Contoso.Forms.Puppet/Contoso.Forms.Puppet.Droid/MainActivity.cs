﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Azure.Mobile;
using Com.Microsoft.Azure.Mobile.Analytics;
using Com.Microsoft.Azure.Mobile.Analytics.Ingestion.Models;
using Com.Microsoft.Azure.Mobile.Analytics.Channel;
using Com.Microsoft.Azure.Mobile.Ingestion.Models;

namespace Contoso.Forms.Puppet.Droid
{
    [Activity(Label = "MCFPuppet", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);

            AndroidAnalytics.SetListener(new AndroidAnalyticsListener());

            MobileCenter.SetServerUrl("https://in-integration.dev.avalanch.es");
            MobileCenter.Configure("7f222d3c-0f5e-421b-93e7-f862c462e07e");

            LoadApplication(new App());
        }
    }

    public class AndroidAnalyticsListener : Java.Lang.Object, IAnalyticsListener
    {
        public void OnSendingFailed(ILog log, Java.Lang.Exception e)
        {
            System.Console.WriteLine("OnSendingFailed*****");
        }

        public void OnSendingSucceeded(ILog log)
        {
            System.Console.WriteLine("OnSendingSucceeded*****");
        }

        public void OnBeforeSending(ILog log)
        {
            EventLog eventLog = log as EventLog;
            if (eventLog != null) {
                System.Console.WriteLine("OnBeforeSendingEventLog*****");
            }
        }
    }
}
