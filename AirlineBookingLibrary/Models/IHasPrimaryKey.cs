using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Models
{
    public interface IHasPrimaryKey<TKey>
    {
        TKey Id { get; }
    }
}
