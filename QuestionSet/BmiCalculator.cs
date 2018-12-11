using System;

namespace QuestionSet
{
    public class BmiCalculator
    {
        public static double Calculate(double heightInMeter, double weightInKg)
            => weightInKg / Math.Pow(heightInMeter, 2);
    }
}
