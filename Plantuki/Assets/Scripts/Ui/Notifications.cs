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
        if (SharedInstance != null)
        {
            SharedInstance = this;
        }
    }

    private int id;
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
        
        var channel2 = new AndroidNotificationChannel()
        {
            Id = "channel_id2",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel2);
    }

    public void sendNotification()
    {
        var notification = new AndroidNotification();
        notification.Title = "PLANTUKI TIENE SED";
        notification.Text = "Hace mucho que no le das agua, vuelve pronto";
        notification.FireTime = DateTime.Now.AddMinutes(1);
        notification.SmallIcon = "plant";
        notification.LargeIcon = "plant";
        
        id = AndroidNotificationCenter.SendNotification(notification, "channel_id1");
    }

    public void cancelNotification()
    {
        AndroidNotificationCenter.CancelNotification(id);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
