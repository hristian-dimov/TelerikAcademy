using System;
using System.Collections.Generic;

namespace Exceptions_Homework
{
    public class ExceptionsHomework
    {
        static void Main()
        {

            var substr = MathUtils.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = MathUtils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = MathUtils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));

            var emptyarr = MathUtils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));

            try
            {
                Console.WriteLine(MathUtils.ExtractEnding("I love C#", 2));
                Console.WriteLine(MathUtils.ExtractEnding("Nakov", 4));
                Console.WriteLine(MathUtils.ExtractEnding("beer", 4));
                Console.WriteLine(MathUtils.ExtractEnding("Hi", 100));
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine(nre.Message);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine(aore.Message);
            }

            if (MathUtils.CheckPrime(23))
            {
                Console.WriteLine("23 is prime.");
            }
            else
            {
                Console.WriteLine("23 is not prime");
            }

            if (MathUtils.CheckPrime(33))
            {
                Console.WriteLine("33 is prime.");
            }
            else
            {
                Console.WriteLine("33 is not prime");
            }

            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };

            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}