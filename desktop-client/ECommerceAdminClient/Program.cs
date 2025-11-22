using System;
using System.Windows.Forms;
using ECommerceAdminClient.Forms; 

namespace ECommerceAdminClient
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}