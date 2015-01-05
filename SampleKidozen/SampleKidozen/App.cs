using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SampleKidozen
{
	public class App
	{
        public static Page GetLoginPage()
        {
            return new LoginPage();
        }

        public static Page GetMainPage()
        {
            return new ContentPage
            {
                Content = new Label
                {
                    Text = "Hello, You are connected to Kidozen and logged in with your user credentials!",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                },
                Padding = new Thickness(40, 10, 40, 20),
                BackgroundColor=Color.White,
                
            };
        }

    }
	
}
