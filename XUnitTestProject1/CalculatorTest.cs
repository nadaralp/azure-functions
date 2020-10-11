using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class CalculatorTest
    {
        private readonly Calculator _sut;
        public CalculatorTest()
        {
            _sut = new Calculator();
        }


        [Fact]
        public void Add_ShouldReturnAddition()
        {
            // Arrange
            int num1 = 3;
            int num2 = 5;

            // Act
            int sum = _sut.Add(num1, num2);

            // Assert
            Assert.Equal(8, sum);
        }


        [Theory]
        [InlineData(5, 5, 10)]
        [InlineData(0, 0, 0)]
        public void Add_ShouldReturnAdditionVariations(int num1, int num2, int result)
        {
            // Arrange

            // Act
            int sum = _sut.Add(num1, num2);

            // Assert
            Assert.Equal(sum, result);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Add_ShouldReturnAdditionVariationsOnTheory(DivisionData data)
        {
            //foreach (var d in data)
            //{
            //    Console.WriteLine(d);
            //}
            // Arrange
            double res = _sut.Divide(data.Num1, data.Num2);


            // Act
            Assert.Equal(res, data.Res);
            // Assert
        }



        public static IEnumerable<object[]> TestData()
        {
            var divData = new DivisionData { Num1 = 10, Num2 = 2, Res = 5 };
            var divData2 = new DivisionData { Num1 = 12, Num2 = 4, Res = 3 };


            yield return new object[] { divData };
            yield return new object[] { divData2 };
            //yield return new object[] { -2, -2, -4 };
        }
    }

    public class DivisionData
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Res { get; set; }

    }
}
