using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Models
{
    public class Basket
    {
        public List<BasketItem> Items { get; set; }


        public void AddItem(BasketItem item)
        {
            Items.Add(item);
        }
    }
}
