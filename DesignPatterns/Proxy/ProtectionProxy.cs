using System;

namespace ProtectionProxyExample
{
    public interface IDocument
    {
        void Display();
    }

    public class RealDocument : IDocument
    {
        private readonly string _title;

        public RealDocument(string title)
        {
            _title = title;
        }

        public void Display()
        {
            Console.WriteLine($"Showing document: {_title}");
        }
    }

    public class DocumentProxy : IDocument
    {
        private readonly string _userRole;
        private readonly RealDocument _document;

        public DocumentProxy(string title, string userRole)
        {
            _document = new RealDocument(title);
            _userRole = userRole;
        }

        public void Display()
        {
            if (_userRole == "admin")
            {
                _document.Display();
            }
            else
            {
                Console.WriteLine("Access denied: You are not authorized to view this document.");
            }
        }
    }

    public class ProtectionProxyExample
    {
        public void Test()
        {
            IDocument adminDoc = new DocumentProxy("AdminReport", "admin");
            adminDoc.Display();

            IDocument userDoc = new DocumentProxy("AdminReport", "guest");
            userDoc.Display();
        }
    }
}
