using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MercaditoRecargado.Models
{
    public class Item
    {
        public Producto Producto
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

    }
}