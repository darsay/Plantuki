using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class Notifications : MonoBehaviour
{

    public static Notifications SharedInstance;


    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
    }

    private int ThirstId = 1000;

    private int HungerId = 100;

    private int LightId = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id1",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
        
    }

    public void sendNotification(String title, String textNot, int type, float time)
    {
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = textNot;
        notification.FireTime = DateTime.Now.AddMinutes(time);
        notification.SmallIcon = "plant";
        notification.LargeIcon = "plant";
        switch (type)
        {
            case 0:
                AndroidNotificationCenter.SendNotificationWithExplicitID(notification, "channel_id1", ThirstId);
                break;
            case 1: 
                AndroidNotificationCenter.SendNotificationWithExplicitID(notification, "channel_id1", HungerId);
                break;
            case 2: 
                AndroidNotificationCenter.SendNotificationWithExplicitID(notification, "channel_id1", LightId);
                break;

        }
        
    }

    public void cancelNotification(int type)
    {
        switch (type)
        {
            case 0:
                AndroidNotificationCenter.CancelScheduledNotification(ThirstId);
                break;
            case 1: 
                AndroidNotificationCenter.CancelScheduledNotification(HungerId);
                break;
            case 2: AndroidNotificationCenter.CancelScheduledNotification(LightId);
                break;
                
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
