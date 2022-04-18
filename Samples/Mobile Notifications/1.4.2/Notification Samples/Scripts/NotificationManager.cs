using System;
using Unity.Notifications.iOS;
using UnityEngine;


namespace NotificationSamples
{
    public class NotificationManager : MonoBehaviour
    {
        [SerializeField] protected GameNotificationsManager manager;
        [Space(5),Header("Notification list"),SerializeField] private CustomNotification[] customNotifications;

        private readonly string _notificationEvent = "Notification";
        private readonly string _clickEvent = "Click";
        private readonly string _sendEvent = "Send";
        private readonly string _impressionEvent = "Impression";
        
        //Initiates the Manager and checks if the app was open using a notification
        private void Start()
        {
            InitManager();
            GetIntent();
        }
        //On return from background we check to see if the user returned by using a notification
        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus) return;
            if(!manager.Initialized)
                InitManager();
            GetIntent();
            if(manager.PendingNotifications.Count == 0)
                ScheduleNotifications();
        }

        //Creates a channel for Android, initialized manager and subscribes to an event related to impressions
        //Each time the user launches the app, the Notifications are canceled and rescheduled 
        private void InitManager()
        {
            if (manager.Initialized) return;
            #if UNITY_IOS
            var settings = iOSNotificationCenter.GetNotificationSettings();
            if (settings.AuthorizationStatus == AuthorizationStatus.Denied)
            {
                Destroy(gameObject);
            }
            #endif
            var defaultChannel = new GameNotificationChannel("game_channel0", "Default Game Channel", "Generic notification");
            manager.Initialize(defaultChannel);
            manager.Platform.NotificationReceived += OnNotificationReceived;
            manager.LocalNotificationExpired += OnNotificationExpired;
            ScheduleNotifications();
        }

        //Impression event
        private void OnNotificationReceived(IGameNotification notification) => Debug.Log("Notification received");
        

        //If notification is supposed to be displayed while the game is in the foreground, reschedule the notification 
        private void OnNotificationExpired(PendingNotification pendingNotification) => ScheduleNotifications();
        

        //Creates a notification queue based on the customNotification array
        private void CreateNotifications()
        {
            foreach (var element in customNotifications)
            {
                var notification = manager.CreateNotification();
                notification.Title = element.title;
                notification.Body = element.body;
                notification.DeliveryTime = DateTime.Now.AddHours(element.hours);
                notification.SmallIcon = null;
                notification.LargeIcon = null;
                manager.ScheduleNotification(notification);
                Debug.Log("Created a notification");
            }
        }

        //Initiates queue if there are no pending notifications
        private void ScheduleNotifications()
        {
            manager.CancelAllNotifications(); 
            CreateNotifications();
        }

        //When user clicks on the notification, a click event is sent
        private void GetIntent()
        {
            var last = manager.GetLastNotification();
            if (last == null) return;
            manager.DismissAllNotifications(); 
            Debug.Log("Click registered from notification");
        }

    }

}