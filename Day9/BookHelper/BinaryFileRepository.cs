using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;

namespace BookHelper
{
    public class BinaryFileRepository : IBookRepository
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static string FileName { get; private set; }
        public BinaryFileRepository(string fileName)
        {
            FileName = fileName;
        }
        public BinaryFileRepository() : this(Properties.Resources.FilePath) { }
 
        public IEnumerable<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();
            try
            {
                using (FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        long position = br.BaseStream.Position;
                        while (position < br.BaseStream.Length)
                        {
                            Book book = new Book(br.ReadString(), br.ReadString(), br.ReadInt32(), br.ReadInt32());
                            books.Add(book);
                            position = br.BaseStream.Position;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("********************************************");
                logger.Error("Error in method LoadBooks.");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                books.Clear();
                return books;
            }
            return books;
        }
        public bool SaveBooks(IEnumerable<Book> books)
        {
            try
            {
                FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    foreach (Book book in books)
                    {
                        bw.Write(book.Title);
                        bw.Write(book.Author);
                        bw.Write(book.Year);
                        bw.Write(book.Pages);
                    }
                    bw.Flush();
                }
            }
            catch (Exception e)
            {
                logger.Error("********************************************");
                logger.Error("Error in method SaveBooks.");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                return false;
            }
            return true;
        }
    }
}
