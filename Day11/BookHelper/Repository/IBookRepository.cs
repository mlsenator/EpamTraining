using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHelper.Entity;

namespace BookHelper.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> LoadBooks();
        bool SaveBooks(IEnumerable<Book> books);
    }
}
