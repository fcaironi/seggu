﻿using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace Seggu.Service
{
    partial class SegguService : ServiceBase
    {
        private ParseClient client;
        private Timer myTimer;

        public SegguService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Event Log configuration.
            if (!EventLog.SourceExists(Properties.Settings.Default.EventLogSourceName))
            {
                EventLog.CreateEventSource(Properties.Settings.Default.EventLogSourceName, Properties.Settings.Default.EventLogName);
            }
            this.eventLog.Source = Properties.Settings.Default.EventLogSourceName;
            this.eventLog.Log = Properties.Settings.Default.EventLogName;

            this.eventLog.WriteEntry("The service has started.");

            // ApiClient configuration.
            this.client = new ParseClient();

            this.myTimer = new Timer(10000);
            this.myTimer.Elapsed += Process;
            this.myTimer.Start();
        }

        protected override void OnStop()
        {
            this.eventLog.WriteEntry("The service has stopped.");
        }

        private void Process(object sender, System.EventArgs e)
        {
            this.eventLog.WriteEntry("Begin process.");
            try
            {
                this.eventLog.WriteEntry("Initialize context.");
                using (var context = new SegguDataModelContext())
                {
                    this.eventLog.WriteEntry("Retrieve Fees.");
                    var feesVm = this.client.GetFees();
                    if (feesVm != null)
                    {
                        this.eventLog.WriteEntry("Fees retrieved = " + feesVm.Count());
                        if (feesVm.Any())
                        {
                            var fees = feesVm.Select(x => new Fee { Value = x.Amount });
                            context.Fees.AddRange(fees);
                        }
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void HandleException(Exception ex)
        {
            this.eventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            if (ex.InnerException != null)
            {
                HandleException(ex.InnerException);
            }
        }
    }
}