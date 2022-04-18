using System;

namespace NotificationSamples
{
    //Struct containing notification content
    [Serializable]
    public struct CustomNotification
    {
        public string title;
        public string body;
        public int hours;
    }
}