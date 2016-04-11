using System;

namespace VeInteractiveAssessment.OneTimePassword
{
    public class RealDateTime : IDateTime
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}