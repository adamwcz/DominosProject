using System.Linq;

namespace DominosProject
{
    public static class NumberFinder
    {
        /// <summary>
        /// Find the missing number in an array of size N-1 which contains numbers 1 to N with one number missing.
        /// </summary>
        /// <param name="array">Integer array</param>
        /// <returns>Returns a FindMissingNumberResult with completion information</returns>
        public static FindMissingNumberResult FindMissingNumber(int[] array)
        {
            // Check for null array
            if (array == null)
                return new FindMissingNumberNullArrayResult();

            // Check for empty array
            if (array.Length == 0)
                return new FindMissingNumberEmptyArrayResult(array);

            // Check for duplicates
            if (array.Length != array.Distinct().Count())
                return new FindMissingNumberDuplicateNumbersResult(array);

            // Find the maximum number in the array, which by definition of the problem, is N (using array.Max instead of array[N-1] in case of unordered array)
            int N = array.Max();

            // Check to see if the array is not missing any numbers (there are N numbers in the array)
            if (N == array.Length)
                return new FindMissingNumberNotMissingANumberResult(array);

            // Check to see if there are more than one missing numbers in the array (there are less than N-1 numbers in the array)
            if (N - 1 != array.Length)
                return new FindMissingNumberMultipleNumbersMissingResult(array);

            // Find the sum of 1 to N
            int sum1toN = 0;
            for (int i = 1; i <= N; i++)
                sum1toN += i;

            // The missing number is equal to the difference between sum of 1 to N, and the sum of the input array (when given correct input)
            int missingNumber = sum1toN - array.Sum();

            // Return the missing number
            return new FindMissingNumberSuccessResult(array, missingNumber);
        }
    }

    /// <summary>
    /// Base class for results of a FindMissingNumber search
    /// </summary>
    public abstract class FindMissingNumberResult
    {
        /// <summary>
        /// True if a missing number was successfully found
        /// </summary>
        public abstract bool Success { get; }
        /// <summary>
        /// The array which was searched for a missing number
        /// </summary>
        public int[] Array { get; private set; }
        /// <summary>
        /// A message describing the result
        /// </summary>
        public virtual string Message => MessageString + " " + InputArrayString;
        protected abstract string MessageString { get; }
        protected string InputArrayString => "input={" + string.Join(", ", Array) + "}";
        public FindMissingNumberResult(int[] array)
        {
            Array = array;
        }
    }
    /// <summary>
    /// Result of a successful FindMissingNumber call
    /// </summary>
    public class FindMissingNumberSuccessResult : FindMissingNumberResult
    {
        public override bool Success => true;
        protected override string MessageString => "Missing number: " + MissingNumber;
        /// <summary>
        /// The number which is missing from the array
        /// </summary>
        public int MissingNumber { get; private set; }
        public FindMissingNumberSuccessResult(int[] array, int missingNumber) : base(array)
        {
            MissingNumber = missingNumber;
        }
    }
    /// <summary>
    /// Result of an unsuccessful FindMissingNumber call
    /// </summary>
    public abstract class FindMissingNumberFailureResult : FindMissingNumberResult
    {
        public override bool Success => false;
        protected override string MessageString => ErrorString;
        protected abstract string ErrorString { get; }
        public FindMissingNumberFailureResult(int[] array) : base(array) { }
    }
    /// <summary>
    /// Result of a FindMissingNumber call when given an empty array as input
    /// </summary>
    public class FindMissingNumberNullArrayResult : FindMissingNumberFailureResult
    {
        public override string Message => ErrorString;
        protected override string ErrorString => "Invalid input! Array must not be null.";
        public FindMissingNumberNullArrayResult() : base(null) { }
    }
    /// <summary>
    /// Result of a FindMissingNumber call when given an empty array as input
    /// </summary>
    public class FindMissingNumberEmptyArrayResult : FindMissingNumberFailureResult
    {
        protected override string ErrorString => "Invalid input! Array must not be empty.";
        public FindMissingNumberEmptyArrayResult(int[] array) : base(array) { }
    }
    /// <summary>
    /// Result of a FindMissingNumber call when given an array with some duplicate numbers
    /// </summary>
    public class FindMissingNumberDuplicateNumbersResult : FindMissingNumberFailureResult
    {
        protected override string ErrorString => "Invalid input! Array must not contain duplicates.";
        public FindMissingNumberDuplicateNumbersResult(int[] array) : base(array) { }
    }
    /// <summary>
    /// Result of a FindMissingNumber call when given an array which is not missing a number (there are N numbers in the array)
    /// </summary>
    public class FindMissingNumberNotMissingANumberResult : FindMissingNumberFailureResult
    {
        protected override string ErrorString => "Invalid input! Array is not missing any numbers.";
        public FindMissingNumberNotMissingANumberResult(int[] array) : base(array) { }
    }
    /// <summary>
    /// Result of a FindMissingNumber call when given an array which is missing multiple numbers (there are less than N-1 numbers in the array)
    /// </summary>
    public class FindMissingNumberMultipleNumbersMissingResult : FindMissingNumberFailureResult
    {
        protected override string ErrorString => "Invalid input! Array must be missing no more than one number.";
        public FindMissingNumberMultipleNumbersMissingResult(int[] array) : base(array) { }
    }
}