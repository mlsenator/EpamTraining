using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHelper
{
    public class AuthorBookComparator : IComparer<Book>
    {
        public int Compare (Book x, Book y)
        {
            return string.Compare(x.Author, y.Author);
        }
    }

    public class TitleBookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return string.Compare(x.Title, y.Title);
        }
    }

    public class YearBookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }
}
