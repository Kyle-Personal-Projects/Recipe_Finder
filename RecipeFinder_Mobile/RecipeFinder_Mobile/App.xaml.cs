﻿namespace RecipeFinder_Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.SearchPage());
        }

    }
}
