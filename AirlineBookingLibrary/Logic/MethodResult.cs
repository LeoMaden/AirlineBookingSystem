using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Logic
{
    public class MethodResult
    {
        public bool Succeeded { get; private set; }
        public IEnumerable<string> Errors { get; private set; }


        public static MethodResult Success
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static MethodResult Failed(params string[] errors)
        {
            throw new NotImplementedException();
        }

    }
}
