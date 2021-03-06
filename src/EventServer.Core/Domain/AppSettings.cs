﻿using System;

namespace EventServer.Core.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Web.Hosting;

    public class AppSettings : Entity
    {
        public AppSettings()
        {
            Id = 1;
        }

        private string siteName;
        [DisplayName("Name")]
        public string SiteName
        {
            get
            {
                if (string.IsNullOrEmpty(siteName))
                    siteName = "Event Server";

                return siteName;
            }
            set { siteName = value; }
        }

        private string siteSlogan;
        [DisplayName("Slogan")]
        public string SiteSlogan
        {
            get
            {
                if (string.IsNullOrEmpty(siteSlogan))
                    siteSlogan = "Making events easy!";

                return siteSlogan;
            }
            set { siteSlogan = value; }
        }

        private string siteTheme;
        [DisplayName("Theme")]
        public string SiteTheme
        {
            get
            {
                if (string.IsNullOrEmpty(siteTheme))
                    siteTheme = "Solution";

                return siteTheme;
            }
            set { siteTheme = value; }
        }

        private string description;
        [DisplayName("Description")]
        public string Description
        {
            get
            {
                if (string.IsNullOrEmpty(description))
                    description = "Event Server was created to make setting up sites for conference easy.";

                return description;
            }
            set { description = value; }
        }

        private DateTime startDateTime;
        [DisplayName("Event Start Date")]
        public DateTime StartDateTime
        {
            get
            {
                if (startDateTime == DateTime.MinValue)
                    startDateTime = DateTime.Now.AddDays(60);

                return startDateTime;
            }
            set { startDateTime = value; }
        }

        private DateTime endDateTime;
        [DisplayName("Event End Date")]
        public DateTime EndDateTime
        {
            get
            {
                if (endDateTime == DateTime.MinValue)
                    DateTime.Now.AddDays(90);

                return endDateTime;
            }
            set { endDateTime = value; }
        }

        private DateTime registrationEndDateTime;
        [DisplayName("Registration End Date")]
        public DateTime RegistrationEndDateTime
        {
            get
            {
                if (registrationEndDateTime == DateTime.MinValue)
                    registrationEndDateTime = DateTime.Now.AddDays(89);

                return registrationEndDateTime;
            }
            set { registrationEndDateTime = value; }
        }

        private DateTime sessionSubmissionEndDateTime;
        [DisplayName("Session Submission End Date")]
        public DateTime SessionSubmissionEndDateTime
        {
            get
            {
                if (sessionSubmissionEndDateTime == DateTime.MinValue)
                    sessionSubmissionEndDateTime = DateTime.Now.AddDays(50);

                return sessionSubmissionEndDateTime;
            }
            set { sessionSubmissionEndDateTime = value; }
        }

        private string venueName;
        [DisplayName("Location")]
        public string VenueName
        {
            get
            {
                if (string.IsNullOrEmpty(venueName))
                    venueName = "Event Venue";

                return venueName;
            }
            set { venueName = value; }
        }

        private string venuePhone;
        [DisplayName("Location Phone")]
        public string VenuePhone
        {
            get
            {
                if (string.IsNullOrEmpty(venuePhone))
                    venuePhone = "555 555-5555";

                return venuePhone;
            }
            set { venuePhone = value; }
        }

        private string venueStreet;
        [DisplayName("Address")]
        public string VenueStreet
        {
            get
            {
                if (string.IsNullOrEmpty(venueStreet))
                    venueStreet = "Anywhere St.";

                return venueStreet;
            }
            set { venueStreet = value; }
        }

        private string venueCity;
        [DisplayName("City")]
        public string VenueCity
        {
            get
            {
                if (string.IsNullOrEmpty(venueCity))
                    venueCity = "Anytown";

                return venueCity;
            }
            set { venueCity = value; }
        }

        private string venueState;
        [DisplayName("State")]
        public string VenueState
        {
            get
            {
                if (string.IsNullOrEmpty(venueState))
                    venueState = "AR";

                return venueState;
            }
            set { venueState = value; }
        }

        private string venueZip;
        [DisplayName("Postal Code")]
        public string VenueZip
        {
            get
            {
                if (string.IsNullOrEmpty(venueZip))
                    venueZip = "12345";

                return venueZip;
            }
            set { venueZip = value; }
        }

        private string contactName;
        [DisplayName("Event Contact Name")]
        public string ContactName
        {
            get
            {
                if (string.IsNullOrEmpty(contactName))
                    contactName = "Event Contact";

                return contactName;
            }
            set { contactName = value; }
        }

        private string contactEmail;
        [DisplayName("Event Contact Email")]
        public string ContactEmail
        {
            get
            {
                if (string.IsNullOrEmpty(contactName))
                    contactEmail = "event@example.com";

                return contactEmail;
            }
            set { contactEmail = value; }
        }

        private string twitterId;
        [DisplayName("Event Twitter Account")]
        public string TwitterId
        {
            get
            {
                if (string.IsNullOrEmpty(twitterId))
                    twitterId = "EventServer";

                return twitterId;
            }
            set { twitterId = value; }
        }

        private DateTime twitterFilterDate;
        [DisplayName("Only show tweets since")]
        public DateTime TwitterFilterDate
        {
            get
            {
                if (twitterFilterDate == DateTime.MinValue)
                    return DateTime.Now.AddDays(-30);

                return twitterFilterDate;
            }
            set { twitterFilterDate = value; }
        }

        private int twitterDisplayCount;
        [DisplayName("Number of tweets to display")]
        public int TwitterDisplayCount
        {
            get
            {
                if (twitterDisplayCount == 0)
                    twitterDisplayCount = 5;

                return twitterDisplayCount;
            }
            set { twitterDisplayCount = value; }
        }

        private string siteLogoUri;
        [DisplayName("Url to site logo")]
        public string SiteLogoUri
        {
            get
            {
                if (string.IsNullOrEmpty(siteLogoUri))
                    siteLogoUri = "http://eventserver.codeplex.com/images/logo.png";

                return siteLogoUri;
            }
            set { siteLogoUri = value; }
        }

        private string dataStoreBasePath;
        [DisplayName("Path to data")]
        public string DataStorePath
        {
            get
            {
                if (string.IsNullOrEmpty(dataStoreBasePath)) dataStoreBasePath = "~/App_Data";

                return dataStoreBasePath;
            }
            set { dataStoreBasePath = value; }
        }
        
        [DisplayName("File Data Store Path")]
        public string FileDataStorePath
        {
            get { return DataStorePath + "/Files"; }
        }

        public string[] AvailableThemes
        {
            get
            {
                var themes = new List<string>();

                var directories = Directory.GetDirectories(HostingEnvironment.MapPath("~/Themes"));

                foreach (var directory in directories)
                {
                    var directoryInfo = new DirectoryInfo(directory);
                    themes.Add(directoryInfo.Name);
                }

                return themes.ToArray();
            }
        }

        private int? numberOfDaysForEvent;

        [DisplayName("Number of Days")]
        public int? NumberOfDaysForEvent
        {
            get
            {
                if (numberOfDaysForEvent == null) numberOfDaysForEvent = 1;

                return this.numberOfDaysForEvent;
            }
            set { this.numberOfDaysForEvent = value; }
        }
    
        // Email Server Settings

        private bool emailEnabled = false;

        public bool EmailEnabled
        {
            get
            {
                return this.emailEnabled;
            }
            set
            {
                this.emailEnabled = value;
            }
        }

        private string emailFromAddress;
        public string EmailFromAddress
        {
            get
            {
                if (string.IsNullOrEmpty(this.emailFromAddress)) this.emailFromAddress = "no-reply@example.com";
                return this.emailFromAddress;
            }
            set
            {
                this.emailFromAddress = value;
            }
        }

        private string emailHost;
        public string EmailHost
        {
            get
            {
                if (string.IsNullOrEmpty(this.emailHost)) this.emailHost = "smtp.example.com";

                return this.emailHost;
            }
            set
            {
                this.emailHost = value;
            }
        }

        private int emailHostPort = 25;
        public int EmailHostPort
        {
            get
            {
                // Change the port if SSL enabled???
                return this.emailHostPort;
            }
            set
            {
                this.emailHostPort = value;
            }
        }

        private string emailUsername;
        public string EmailUsername
        {
            get
            {
                if (string.IsNullOrEmpty(this.emailUsername)) this.emailUsername = "no-reply@example.com";

                return this.emailUsername;
            }
            set
            {
                this.emailUsername = value;
            }
        }

        public string EmailPassword { get; set; }
        private bool emailEnableSsl = false;
        public bool EmailEnableSsl
        {
            get
            {
                return this.emailEnableSsl;
            }
            set
            {
                this.emailEnableSsl = value;
            }
        }
        public string EmailSubjectPrefix { get; set; }
    }
}
