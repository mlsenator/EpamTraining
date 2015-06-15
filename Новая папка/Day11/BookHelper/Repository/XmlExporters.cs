using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using BookHelper.Entity;

namespace BookHelper.Repository
{
    public class LinqToXmlExporter : IXmlFormatExporter
    {
        public void Export(IEnumerable<Book> books, string fileName)
        {
            XElement booksElement = new XElement("books");
            foreach (Book book in books)
            {
                XElement bookElement = new XElement("book");
                bookElement.Add(new XElement("author", book.Author));
                bookElement.Add(new XElement("title", book.Title));
                bookElement.Add(new XElement("year", book.Year));
                bookElement.Add(new XElement("pages", book.Pages));
                booksElement.Add(bookElement);
            }
            XDocument document = new XDocument(booksElement);
            document.Save(fileName);
        }
    }

    public class XmlWriterExporter : IXmlFormatExporter
    {
        public void Export(IEnumerable<Book> books, string fileName)
        {
            using (var writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("books");
                foreach (Book book in books)
                {
                    writer.WriteStartElement("book");
                    writer.WriteElementString("author", book.Author);
                    writer.WriteElementString("title", book.Title);
                    writer.WriteElementString("year", book.Year.ToString());
                    writer.WriteElementString("pages", book.Pages.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
