using System;
using System.Collections.Generic;

namespace AirlineBookingLibrary.Logic
{
    /// <summary>
    /// Contains information about the result of an operation.
    /// </summary>
    public class MethodResult
    {
        /// <summary>
        /// Whether the operation was successful.
        /// </summary>
        public bool Succeeded { get; private set; }

        /// <summary>
        /// The errors from the operation.
        /// </summary>
        public IEnumerable<string> Errors { get; private set; }


        /// <summary>
        /// Get an instance of MethodResult that is a success.
        /// </summary>
        public static MethodResult Success
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Get an instance of MethodResult that has the specified errors.
        /// </summary>
        /// <param name="errors">The errors that occured.</param>
        /// <returns>A failure MethodResult containg the given errors.</returns>
        public static MethodResult Failed(params string[] errors)
        {
            throw new NotImplementedException();
        }

    }
}
