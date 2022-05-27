using CPF.Linux;//如果需要支持Linux才需要
using CPF.Mac;//如果需要支持Mac才需要
using CPF.Platform;
using CPF.Skia;
using CPF.Windows;
using System;

namespace My.QQ
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.Initialize(
                (OperatingSystemType.Windows, new WindowsPlatform(), new SkiaDrawingFactory())
                , (OperatingSystemType.OSX, new MacPlatform(), new SkiaDrawingFactory())//如果需要支持Mac才需要
                , (OperatingSystemType.Linux, new LinuxPlatform(), new SkiaDrawingFactory())//如果需要支持Linux才需要
            );
            Application.Run(new QQLogin());
        }
    }
}
