using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberPages { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Language { get; set; }
        public string Brand { get; set; }
    }
}
