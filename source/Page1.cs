/*
CopyRight @Foyzur Rahman
@ICT-Talo
2012 Summer
*/

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
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Page1 : Design.Common.LayoutAwarePage
    {
        public Page1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
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
