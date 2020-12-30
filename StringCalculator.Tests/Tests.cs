using System;
using FluentAssertions;
using NUnit.Framework;

namespace StringCalculator.Tests {
    public class Tests {
        [Test]
        public void Sum_in_case_of_empty_string() {
            Business.StringCalculator.Add("").Should().Be(0);
        }

        [Test]
        public void Sum_in_case_of_one_number()
        {
            Business.StringCalculator.Add("1").Should().Be(1);
        }
        [Test]
        public void Sum_in_case_of_2_numbers()
        {
            Business.StringCalculator.Add("1,2").Should().Be(3);
        }
        [Test]
        public void Sum_in_case_of_more_than_2_numbers()
        {
            Business.StringCalculator.Add("1,2,3").Should().Be(6);
        }
        [Test]
        public void Sum_with_new_lines_between_numbers()
        {
            Business.StringCalculator.Add("1\n2,3").Should().Be(6);
        }
        [Test]
        public void Sum_in_case_of_different_delimiters()
        {
            Business.StringCalculator.Add("//;\n1;2").Should().Be(3);
        }
        [Test]
        public void Sum_negatives_numbers()
        {
            Action exception = () => Business.StringCalculator.Add("1,-1,-5");
            exception.Should().Throw<System.Exception>().WithMessage("negatives not allowed: -1,-5");
        }
        [Test]
        public void Sum_big_numbers()
        {
            Business.StringCalculator.Add("1001,2").Should().Be(2);
        }

        /* [Test]
         public void negative()
         {
             AnyClass.SaveNegativeNumbers(new string[] {"-1", "2", "-3"}).Should().Be("-1,-3");
         }*/
        /*[Test]
        public void check_get_delimiter()
        {
            AnyClass.get_custom_delimiter("//;\n1;2").Should().Be(";");
        }*/
        /* [Test]
         public void Check_numbers()
         {
             AnyClass.Return_Numbers_in_Array_format("//;\n1;2;3").Should().Equal("1", "2" ,"3");
         }*/

    }
}