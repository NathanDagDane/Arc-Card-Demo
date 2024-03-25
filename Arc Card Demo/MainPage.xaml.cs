using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media.Animation;
using System.Numerics;
using Windows.UI.Composition;

namespace Arc_Card_Demo
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;

            ApplicationView appView = ApplicationView.GetForCurrentView();
            appView.TitleBar.BackgroundColor = Colors.Transparent;
            appView.TitleBar.ButtonBackgroundColor = Colors.Transparent;
            appView.TitleBar.InactiveBackgroundColor = Colors.Transparent;

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(200, 310));
            ApplicationView.PreferredLaunchViewSize = new Size(280, 420);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        private void Card_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = ((Image)sender).Resources["EnterStoryboard"] as Storyboard;
            sb.Begin();
        }
        private void Card_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = ((Image)sender).Resources["ExitStoryboard"] as Storyboard;
            sb.Begin();
        }

        private void Page_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Input.PointerPoint p = e.GetCurrentPoint(Card);
            CardRotation.RotationX = ((p.Position.Y / Card.ActualHeight)-0.5)*-12;
            CardRotation.RotationY = ((p.Position.X / Card.ActualWidth)-0.5)*11;
        }
    }
}
