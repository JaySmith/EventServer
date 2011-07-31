﻿namespace EventServer.Core
{
    using System.Web.Mvc;

    using EventServer.Core.Domain;
    using EventServer.Models;

    public static class Settings
    {
        private const int DefaultId = 1;

        static Settings()
        {
            Instance = LoadSettings();
        }

        public static AppSettings Instance { get; private set; }

        public static void SaveSettings(AppSettings settings)
        {
            Instance = settings;

            DependencyResolver.Current.GetService<IRepository>().Save(settings);
        }

        private static AppSettings LoadSettings()
        {
            var repository = DependencyResolver.Current.GetService<IRepository>();

            return repository.Get<AppSettings>(DefaultId) ?? repository.Save(new AppSettings());
        }
    }
}