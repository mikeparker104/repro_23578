#if IOS || MACOS || MACCATALYST
using PlatformView = UIKit.UIView;
#elif ANDROID
using PlatformView = Android.Views.View;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.FrameworkElement;
#elif TIZEN
using PlatformView = Tizen.NUI.BaseComponents.View;
#elif NET6_0_OR_GREATER || (NETSTANDARD || !PLATFORM)
using PlatformView = System.Object;
#endif

using System.Diagnostics;

namespace Repro23578;

public class ReproBehavior : PlatformBehavior<View, PlatformView>
{
    public static readonly BindableProperty MyColorProperty =
        BindableProperty.Create(
            nameof(MyColor),
            typeof(Color),
            typeof(ReproBehavior),
            default,
            propertyChanged: MyColorPropertyChanged);

    public Color MyColor
    {
        get => (Color)GetValue(MyColorProperty);
        set => SetValue(MyColorProperty, value);
    }

    static void MyColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        => Trace.TraceInformation($"{nameof(MyColorPropertyChanged)}: {newValue}");
}