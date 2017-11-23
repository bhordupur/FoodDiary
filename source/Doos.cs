***
///copyright @ Rahman Foyzur 2012
///coded for Windows Azure App
///venue ICT Talo
***


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Design
{
    
    public sealed partial class Page1 : Design.Common.LayoutAwarePage
    {
        public Page1()
        {
            this.InitializeComponent();
        }
		
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Update();

        }
	
        private void Records1_Click(object sender, RoutedEventArgs e)
        {
            if (BreakfastList.Visibility == Visibility.Visible)
            {
                BreakfastList.Visibility = Visibility.Collapsed;
                return;
            }
            BreakfastList.Visibility = Visibility.Visible;
        }

        private async void Save1_Click(object sender, RoutedEventArgs e)
        {
            await App.MobileService.GetTable<breakfast>().InsertAsync(new breakfast(txtItem.Text, txtDesc.Text, DateTime.Now));
            Update();
        }
		
        private async void Update()
        {
            BreakfastList.ItemsSource = await App.MobileService.GetTable<breakfast>().ToListAsync();
        }
    }
}