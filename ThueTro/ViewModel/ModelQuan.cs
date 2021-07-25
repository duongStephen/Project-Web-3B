using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThueTro.Models;

namespace ThueTro.ViewModel
{
    public class ModelQuan
    {
        public string ID { get; set; }
        public string DiaDiem { get; set; }
        public IEnumerable<DiaDiem> DiaDiems { get; set; }
        public IEnumerable<NhaTro> Listnhatro { get; set; }
        public IList<NhaTro> ListHomePage { get; set; }
    }
}