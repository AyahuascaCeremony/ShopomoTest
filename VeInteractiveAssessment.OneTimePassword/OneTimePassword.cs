using System;

namespace VeInteractiveAssessment.OneTimePassword
{
    public class OneTimePassword
    {
        public string Value { get; }
        public DateTime CreatedDateDateTime { get; }

        public OneTimePassword(string password, DateTime createdDateTime)
        {
            Value = password;
            CreatedDateDateTime = createdDateTime;
        }
    }
}