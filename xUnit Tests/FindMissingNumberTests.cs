using DominosProject;
using Xunit;

namespace xUnit_Tests
{
    public class FindMissingNumberTests
    {
        /// <summary>
        /// Testing for an array missing the number 4, both with the numbers in order and not in order
        /// </summary>
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 5, 6 })] // Ordered
        [InlineData(new int[] { 5, 2, 3, 6, 1 })] // Unordered
        public void CorrectInput_Expecting4(int[] value)
        {
            // Act
            FindMissingNumberResult result = NumberFinder.FindMissingNumber(value);

            // Assert
            Assert.IsType<FindMissingNumberSuccessResult>(result);
            Assert.Equal(4, (result as FindMissingNumberSuccessResult).MissingNumber);
        }

        /// <summary>
        /// Testing for an array missing the number 11, both with the numbers in order and not in order
        /// </summary>
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 13 })] // Ordered
        [InlineData(new int[] { 5, 2, 4, 14, 6, 13, 1, 9, 10, 12, 3, 7, 8 })] // Unordered
        public void CorrectInput_Expecting11(int[] value)
        {
            // Act
            FindMissingNumberResult result = NumberFinder.FindMissingNumber(value);

            // Assert
            Assert.IsType<FindMissingNumberSuccessResult>(result);
            Assert.Equal(11, (result as FindMissingNumberSuccessResult).MissingNumber);
        }

        /// <summary>
        /// Testing a null array
        /// </summary>
        [Fact]
        public void IncorrectInput_NullArray()
        {
            // Arrange
            int[] arrayEmpty = null;

            // Act
            FindMissingNumberResult result = NumberFinder.FindMissingNumber(arrayEmpty);

            // Assert
            Assert.IsType<FindMissingNumberNullArrayResult>(result);
        }

        /// <summary>
        /// Testing an empty array
        /// </summary>
        [Fact]
        public void IncorrectInput_EmptyArray()
        {
            // Arrange
            int[] arrayEmpty = new int[] { };

            // Act
            FindMissingNumberResult result = NumberFinder.FindMissingNumber(arrayEmpty);

            // Assert
            Assert.IsType<FindMissingNumberEmptyArrayResult>(result);
        }

        /// <summary>
        /// Testing arrays with duplicates of numbers
        /// </summary>
        [Theory]
        [InlineData(new int[] { 2, 1, 3, 3, 5 })]
        [InlineData(new int[] { 1, 2, 3, 4, 6, 6, 6, 8 })]
        [InlineData(new int[] { 1, 1, 2, 2, 2, 6 })]
        public void IncorrectInput_DuplicateNumbers(int[] value)
        {
            // Act
            FindMissingNumberResult result = NumberFinder.FindMissingNumber(value);

            // Assert
            Assert.IsType<FindMissingNumberDuplicateNumbersResult>(result);
        }

        /// <summary>
        /// Testing an array which is not missing any numbers
        /// </summary>
        [Fact]
        public void IncorrectInput_NotMissingANumber()
        {
            // Arrange
            int[] arrayNoMissingNumber = new int[] { 1, 2, 3, 4, 5, 6 };

            // Act
            FindMissingNumberResult result = NumberFinder.FindMissingNumber(arrayNoMissingNumber);

            // Assert
            Assert.IsType<FindMissingNumberNotMissingANumberResult>(result);
        }

        /// <summary>
        /// Testing arrays which are missing multiple numbers
        /// </summary>
        [Theory]
        [InlineData(new int[] { 1, 3, 4, 6 })]
        [InlineData(new int[] { 5, 6 })]
        public void IncorrectInput_MissingMultipleNumbers(int[] value)
        {
            // Act
            FindMissingNumberResult result = NumberFinder.FindMissingNumber(value);

            // Assert
            Assert.IsType<FindMissingNumberMultipleNumbersMissingResult>(result);
        }
    }
}