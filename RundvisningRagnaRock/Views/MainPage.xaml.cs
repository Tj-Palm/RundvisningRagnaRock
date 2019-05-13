using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RundvisningRagnaRock.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RundvisningRagnaRock
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EditPage));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GUICreate));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Form));
        }

        private void HamburgerButton_Checked(object sender, RoutedEventArgs e)
        {
            this.mySplitView.IsPaneOpen = !this.mySplitView.IsPaneOpen;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
