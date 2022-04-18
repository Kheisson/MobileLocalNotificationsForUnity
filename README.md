# Mobile Local Notifications For Unity
This repo is based on the mobile notification sample given by Unity to integrate local notifications for both iOS and Android.
I made the CustomNotificaion struct and the NotificationManager class in the Scripts folder, all of the code is 
documented and can be extended to match your preferences. 
## How to use :eyes:

- Have the ```NotificationManager.cs``` script in scene
- Add a ```GameNotificationsManager.cs``` script to the scene and assign it in the ```Manager``` SerializedField slot
- Create and fill the data for each Custom Notification in the Custom Notifications array

## Notification Structure :mailbox:
- Title - The title of the notification - “Come have a cupcake”
- Body - The body of the notification - “They have sprinkles”
- Hours - The hours added to the notification delivery time - for example if Hours = 2 and the notification was scheduled at 1:00, it will be delivered at 3:00.

[![Notification Sample Example](https://i.postimg.cc/pVCH0Nx9/Screen-Shot-2022-04-18-at-15-31-25.png)](https://postimg.cc/RqWyFDW9)
[![Sample In the Inspector](https://i.postimg.cc/WpdMbV3r/Screen-Shot-2022-04-18-at-15-41-41.png)](https://postimg.cc/23fq2Pn8)

## Notes :page_facing_up:
- iOS requires permission to display notifications, either [ask for it](https://docs.unity3d.com/Packages/com.unity.mobile.notifications@1.4/api/Unity.Notifications.iOS.AuthorizationRequest.html) or mark the ```Request Authorization on App Launch``` flag in the Project Settings -> Mobile Notifications tab
- The `GameNotificationsManager` and any other code except from `NotificationManager` and `CustomNotificaion` are not mine and detailed info regarding them can be found [here](https://docs.unity3d.com/Packages/com.unity.mobile.notifications@1.4/manual/index.html#requirements)
