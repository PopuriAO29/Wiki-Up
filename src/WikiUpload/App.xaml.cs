﻿using System;
using System.Net;
using System.Reflection;
using System.Windows;

namespace WikiUpload
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            GetCommandLineArguments(e.Args, out int timeout);
            UploadService.Uploader = new FileUploader(UserAgent, timeout);
        }

        private void GetCommandLineArguments(string[] args, out int timeout)
        {
            timeout = 0;
            foreach (var arg in args)
            {
                if (int.TryParse(arg, out int value))
                    timeout = value;
            }
        }

        private string UserAgent
        {
            get
            {
                Assembly assembly = Assembly.GetEntryAssembly();
                AssemblyTitleAttribute title = (AssemblyTitleAttribute)Attribute.GetCustomAttribute(
                    assembly, typeof(AssemblyTitleAttribute));
                string userAgent = $"{title.Title}/{Utils.GetApplicationVersion(assembly)}";
                return userAgent;
            }
        }
    }
}
