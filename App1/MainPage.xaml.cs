using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
      var Primes = new List<int>();

      int testvalue = 0;
      int number = 700000;
      int count = 0;

      await Task.Run(async () =>
      {
        while (count < number)
        {
          bool isprime = IsPrime(testvalue);
          if (isprime)
          {
            Primes.Add(testvalue);
            count++;
          }
          testvalue++;
        }

        // Crach app com UI Thread
        //  Result.Text = "Done.";

        // Corrige crach UI Thread com background threads
        await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
          Result.Text = "Done.";
        });

      });

    }

    private bool IsPrime(int n)
    {
      if (n <= 1)
        return false;
      if (n <= 3)
        return false;
      if (n % 2 == 0 || n % 3 == 0)
        return false;
      int i = 5;
      while (i * i <= n)
      {
        if (n % i == 0 || n % (i + 2) == 0)
          return false;
        i += 6;
      }
      return true;
    }
  }
}
