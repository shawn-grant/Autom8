using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Autom8
{
    partial class Autom8_Launcher : ServiceBase
    {
        EventLog eventLog1;
        private int eventId = 1;

        public Autom8_Launcher()
        {
            InitializeComponent();

            eventLog1 = new EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("Autom8"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "Autom8", "Initializing");
            }
            eventLog1.Source = "Autom8";
            eventLog1.Log = "MyNewLog";
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            eventLog1.WriteEntry("In OnStart.");

            // Set up a timer that triggers every minute.
            Timer timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
            eventLog1.WriteEntry("In OnStop.");
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            eventLog1.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId++);
            //check for shortcut

        }
    }
}
