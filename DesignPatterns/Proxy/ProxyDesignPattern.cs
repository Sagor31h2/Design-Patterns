using System;
using ProtectionProxyExample;
using RemoteProxyExample;
using VirtualProxyExample;

namespace DesignPatterns.Proxy;

public class ProxyDesignPattern
{
    public void Test()
    {
        // Virtual Proxy Example
        Console.WriteLine("Virtual Proxy Example:");
        IImage image = new ProxyImage("design-pattern.png");
        Console.WriteLine("First time:");
        image.Display(); // Loads and displays
        Console.WriteLine("\nSecond time:");
        image.Display(); // Just displays

        // Protection Proxy Example
        Console.WriteLine("\nProtection Proxy Example:");
        IDocument adminDoc = new DocumentProxy("AdminReport", "admin");
        adminDoc.Display();
        IDocument userDoc = new DocumentProxy("AdminReport", "guest");
        userDoc.Display();

        // Remote Proxy Example
        Console.WriteLine("\nRemote Proxy Example:");
        IRemoteService service = new RemoteProxy();
        service.Request();
    }
}
