﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHelper
{
    public interface IBookRepository
    {
        IEnumerable<Book> LoadBooks();
        bool SaveBooks(IEnumerable<Book> books);
    }
}
