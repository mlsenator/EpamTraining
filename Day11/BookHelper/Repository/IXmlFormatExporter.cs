using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHelper.Entity;

namespace BookHelper.Repository
{
    public interface IXmlFormatExporter
    {
        void Export(IEnumerable<Book> books, string fileName);
    }

}
