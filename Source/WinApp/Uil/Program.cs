using BioBooker.WinApp.Uil.Views;
using System;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil;

internal static class Program
{
    [STAThread]
    internal static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new HomeView());
    }
}
