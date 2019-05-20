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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RundvisningRagnaRock.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        // Login button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Check RequestLogin/toLoginCommand if Textbox + PasswordBox == Dictionary.Value
            //this.Frame.Navigate(typeof(EditPage));

           
        }
        // Cancel button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        //Username textbox
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        // PasswordBox
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
        }
    }
}
