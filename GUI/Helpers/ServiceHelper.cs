using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Helpers;

public static class ServiceHelper
{

    public static TService GetService<TService>() => Current.GetService<TService>();

    public static IServiceProvider Current =>
#if WINDOWS10_0_17763_0_OR_GREATER
            MauiWinUIApplication.Current.Services;
#elif __ANDROID__
        MauiApplication.Current.Services;
#elif __IOS__ || __MACCATALYST__
        MauiUIApplicationDelegate.Current.Services;
    #else
    null;
#endif
