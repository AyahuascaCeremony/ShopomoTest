using System;

namespace VeInteractiveAssessment.OneTimePassword
{
    public interface IAuditLoginFailures
    {
        void Audit(string userId, DateTime dateTime);
    }
}
