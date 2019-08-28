using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Models;

namespace SnoopsAPI.SignalR
{
    public class snoopHub:Hub
    {
        public void SigTest(string message)
        {
            Clients.Caller.Announce(message);
        }

        public void getESMachineDetails()
        {
            // Use WebAPI
            //Scanner scanner = new Scanner();
            //scanner.GetESMachineDetails(Clients);

            //Use local Model
            LogScanner ls = new LogScanner();
            ls.SendToSignalRClient(Clients);

        }

    }
}