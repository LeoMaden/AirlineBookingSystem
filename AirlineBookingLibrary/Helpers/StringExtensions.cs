namespace AirlineBookingLibrary.Helpers
{
    /// <summary>
    /// Provides static extension methods for manipulating strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Return null if the string is empty.
        /// </summary>
        /// <param name="s">The string to apply the method to.</param>
        /// <returns>Null if the string is empty, the value of s otherwise.</returns>
        public static string NullIfEmpty(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }
            else
            {
                return s;
            }
        }
    }
}
