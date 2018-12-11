using System;

namespace QuestionSet
{
    internal class BmiCalculator
    {
        public static double Calculate(double heightInMeter, double weightInKg)
            => weightInKg / Math.Pow(heightInMeter, 2);
    }
}
