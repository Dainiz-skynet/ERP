using System;
using System.Collections.Generic;
using System.Text;

namespace ASSE.Models
{
    public class Producto
    {
        public string Pid { get; set; }
        public string Pnombre { get; set; }
        public string Provedor { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
        public string Pstockid { get; set; }
        public bool evaluado  { get; set; }
        public bool defectuoso { get; set; }
    }
}
