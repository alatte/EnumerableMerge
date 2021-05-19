using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class Book: IComparable<Book>
    {
        public string Title { get; set; }
        public int Pages { get; set; }

        public Book(string title, int pages)
        {
            Title = title;
            Pages = pages;
        }

        public int CompareTo(Book other)
        {
            if (other != null)
                return this.Title.CompareTo(other.Title);
            else
                return 1;
        }
    }
}
