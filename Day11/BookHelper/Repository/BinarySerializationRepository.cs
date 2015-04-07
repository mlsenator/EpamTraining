using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using BookHelper.Entity;
using NLog;
using System;

namespace BookHelper.Repository
{
    public class BinarySerializationRepository : IBookRepository
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public string FileName { get; private set; }
        public BinarySerializationRepository(string fileName)
        {
            FileName = fileName;
        }
        public IEnumerable<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();

            try
            {
                var formatter = new BinaryFormatter();
                using (Stream s = File.Open(FileName, FileMode.Open))
                {
                    books = (List<Book>)formatter.Deserialize(s);
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
            var formatter = new BinaryFormatter();
            try
            {
                using (Stream s = File.Open(FileName, FileMode.Create))
                {
                    formatter.Serialize(s, books);
                }
                return true;
            }
            catch (Exception e)
            {
                logger.Error("********************************************");
                logger.Error("Error in method SaveBooks.");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                return false;
            }
            
        }
    }
}
