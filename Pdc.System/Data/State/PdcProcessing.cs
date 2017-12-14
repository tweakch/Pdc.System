namespace Pdc.System.Data.State
{
    /// <summary>
    /// Helper class to work with EProcessing flags.
    /// </summary>
    public abstract class PdcProcessing
    {
        /// <summary>
        /// Converts an EProcessing mask to its integer representation
        /// </summary>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static int Convert(EProcessing mask)
        {
            return (int)mask;
        }

        /// <summary>
        /// Converts an integer mask to its EProcessing representation
        /// </summary>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static EProcessing Convert(int mask)
        {
            return (EProcessing)mask;
        }

        /// <summary>
        /// Sets the flag on the mask to 1
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="flag"></param>
        /// <returns>Returns the modified mask</returns>
        public static EProcessing Set(EProcessing mask, EProcessing flag)
        {
            mask |= flag;
            return mask;
        }

        /// <summary>
        /// Sets the flag on the mask to 1
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="flag"></param>
        /// <returns>Returns the modified mask</returns>
        public static int Set(int mask, EProcessing flag)
        {
            // perform a bitwise logical OR operation with the flag
            // to SET the flag on a mask

            //Example:
            //set flag 100000 on mask 000101 to get mask* = 100101
            //         mask: 000101
            //         flag: 100000
            // mask |  flag: 100101 = mask*
            mask |= Convert(flag);
            return mask;
        }

        /// <summary>
        /// Sets the flag on the mask to 0
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="flag"></param>
        /// <returns>Returns the modified mask</returns>
        public static EProcessing Unset(EProcessing mask, EProcessing flag)
        {
            mask &= ~flag;
            return mask;
        }

        /// <summary>
        /// Sets the flag on the mask to 0
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="flag"></param>
        /// <returns>Returns the modified mask</returns>
        public static int Unset(int mask, EProcessing flag)
        {
            //perform a bitwise logical AND operation with the inverse of the flag
            //to UNSET the flag on a mask

            //Example:
            //turn off flag 100000 on mask 100101 to get mask* = 000101
            //         mask: 100101
            //        ~flag: 011111
            // mask & ~flag: 000101 = mask*
            mask &= Convert(~flag);
            return mask;
        }
    }
}