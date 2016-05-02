using System;

namespace VeInteractiveAssessment.OneTimePassword
{
    class ConsoleAuditer : IAuditLoginFailures
    {
        public void Audit(string userId, DateTime dateTime)
        {
            Console.WriteLine("Failed login attempt for UserId: {0} at: {1}", userId, dateTime);
        }
    }
}
