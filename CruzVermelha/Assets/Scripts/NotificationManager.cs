 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationManager : MonoBehaviour
{
    public int id;
    AndroidNotificationChannel defaultChannel;
    // Start is called before the first frame update
    void Start()
    {
        AndroidNotificationCenter.CancelAllNotifications();

        defaultChannel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Channel",
            Description = "Generic Notification",
            Importance = Importance.Default,
        };

        AndroidNotificationCenter.RegisterNotificationChannel(defaultChannel);

        AndroidNotification notification = new AndroidNotification()
        {
            Title = "Cruz Vermelha",
            Text = "Está na hora de prestar primeiros socorros novamente!",
            SmallIcon = "small",
            LargeIcon = "large",
            FireTime = System.DateTime.Now.AddMinutes(2),
        };

        id = AndroidNotificationCenter.SendNotification(notification, defaultChannel.Id);
    }

 
}
