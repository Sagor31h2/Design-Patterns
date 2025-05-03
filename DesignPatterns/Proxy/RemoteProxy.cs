using System;

namespace RemoteProxyExample
{
    public interface IRemoteService
    {
        void Request();
    }

    public class RealRemoteService : IRemoteService
    {
        public void Request()
        {
            Console.WriteLine("Connecting to the remote server...");
            Console.WriteLine("Performing operation on server.");
        }
    }

    public class RemoteProxy : IRemoteService
    {
        private RealRemoteService _realService;

        public void Request()
        {
            Console.WriteLine("Proxy: Checking network...");
            if (_realService == null)
            {
                _realService = new RealRemoteService();
            }
            _realService.Request();
        }
    }

    public class RemoteProxyExample
    {
        public void Test()
        {
            IRemoteService service = new RemoteProxy();
            service.Request();
        }
    }
}
