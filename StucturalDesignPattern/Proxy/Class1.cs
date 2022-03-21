using System;
using System.Threading;
/*
Also known as the surrogate pattern.its intent is to provide a surrogate or placeholder for another object to control access to it.the problem it solves in one of access control.
if you need to control acces to another object for sercurity reasons, performance reasoned or other reasons then the proxy pattern is good one to look into
Subject defines the common interface between  the RealSubject and the Proxy is't a contract both of these adhare to. Proxy provides an interface identical to the Subject. it maintains a reference to and 
control acces to the ReaslSubject.
*/
namespace Proxy
{
    public interface IDocument
    {
        void DisplayDocument();
    }



    /// <summary>
    /// Real Subject
    /// </summary>
    public class Document : IDocument
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public DateTimeOffset LastAccessed { get; set; }
        private string _fileName;

        public Document(string fileName)
        {
            _fileName = fileName;
            LoadDocument(fileName);
        }

        private void LoadDocument(string fileName)
        {
            Console.WriteLine("Executing exprensive action : loading a file from dick");
            Thread.Sleep(1000);
            Title = "An exprenisve document";
            Content = "Lots and lots of content";
            AuthorId = 1;
            LastAccessed = DateTimeOffset.Now;
        }
        public void DisplayDocument()
        {
            Console.WriteLine($"Title : {Title} content {Content}");
        }
    }

    public class DocumentProxy : IDocument
    {
        //  private Document _document;
        private Lazy<Document> _document;
        private string _fileName;
        public DocumentProxy(string fileName)
        {
            _fileName = fileName;
            _document = new Lazy<Document>(() => new Document(fileName));
        }
        public void DisplayDocument()
        {
            //if (_document == null)
            //{
            //    _document = new Document(_fileName);
            //}
            _document.Value.DisplayDocument();
        }
    }
    /// <summary>
    ///     Proxy
    /// </summary>
    public class ProtectedDocumentProxy : IDocument
    {
        private readonly string fileName;
        private readonly string userRole;
        private DocumentProxy _documentProxy;

        public ProtectedDocumentProxy(string fileName,string userRole)
        {
            this.fileName = fileName;
            this.userRole = userRole;
            _documentProxy  = new DocumentProxy(fileName);
        }
        public void DisplayDocument()
        {
            Console.WriteLine($"Entering DisplayDocument in {nameof(ProtectedDocumentProxy)}");
            if(userRole == "Viewer")
                throw new UnauthorizedAccessException();
            _documentProxy.DisplayDocument();
            Console.WriteLine($"Exiting DisplayDocument in {nameof(ProtectedDocumentProxy)}");

        }
    }
}
