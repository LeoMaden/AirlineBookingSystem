using System.Collections;
using System.Collections.Generic;

namespace AirlineBookingLibrary.Models
{
    public class Basket : ICollection<BasketItem>
    {
        public List<BasketItem> Items { get; set; }
        
        public int Count => ((ICollection<BasketItem>)Items).Count;

        public bool IsReadOnly => ((ICollection<BasketItem>)Items).IsReadOnly;



        public void Add(BasketItem item)
        {
            ((ICollection<BasketItem>)Items).Add(item);
        }

        public void Clear()
        {
            ((ICollection<BasketItem>)Items).Clear();
        }

        public bool Contains(BasketItem item)
        {
            return ((ICollection<BasketItem>)Items).Contains(item);
        }

        public void CopyTo(BasketItem[] array, int arrayIndex)
        {
            ((ICollection<BasketItem>)Items).CopyTo(array, arrayIndex);
        }

        public IEnumerator<BasketItem> GetEnumerator()
        {
            return ((ICollection<BasketItem>)Items).GetEnumerator();
        }

        public bool Remove(BasketItem item)
        {
            return ((ICollection<BasketItem>)Items).Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<BasketItem>)Items).GetEnumerator();
        }
    }
}
