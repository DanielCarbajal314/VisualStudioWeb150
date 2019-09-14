using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personal.Presentacion.WebMVC.Hubs
{
    public class NotificationHub : Hub
    {
        public void SendNewNotifacionToAllClients(string message)
        {
            Clients.All.NewNotificationPushed(message);
        }
    }
}