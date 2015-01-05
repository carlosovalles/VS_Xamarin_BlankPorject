using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using Kidozen;


namespace SampleKidozen
{
    public class LoginPage : ContentPage
    {
        public LoginPage ()
		{

            NavigationPage.SetHasNavigationBar(this, false);
            StackLayout loginLayout = new StackLayout()
            {
                Spacing = 20,
                Padding = new Thickness(10, 90, 10, 0),
            };
            //
            var companyLogo = new Image
            {
                WidthRequest = 100,
                Source = FileImageSource.FromFile("logo.png"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            loginLayout.Children.Add(companyLogo);

            var userID = new Entry()
            {
                Placeholder = "User",
                WidthRequest = 260,
                HeightRequest = 44,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            loginLayout.Children.Add(userID);
            //
            var userPassword = new Entry()
            {
                Placeholder = "Password",
                IsPassword = true,
                WidthRequest = 260,
                HeightRequest = 44,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            loginLayout.Children.Add(userPassword);
            //
            Button objButton1 = new Button()
            {
                Text = "Login",
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("5AC3B5"),
                WidthRequest = 180,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            loginLayout.Children.Add(objButton1);
            loginLayout.BackgroundColor = Color.White;
            Content = loginLayout;
            objButton1.Clicked += (sender, e) => {  
				KidoManager.Login(userID.Text, userPassword.Text).ContinueWith(
                     t =>
                     {
                         if (t.Result)
                         {
                             Xamarin.Forms.Device.BeginInvokeOnMainThread(() => Navigation.PushModalAsync(App.GetMainPage()));
                         }
                     }
                 );
            };
		}

		protected override void OnAppearing ()
		{
			Console.Write ("appearing");
		}

		protected override void OnDisappearing ()
		{
			Console.Write ("dis appearing");
		}
    }
}