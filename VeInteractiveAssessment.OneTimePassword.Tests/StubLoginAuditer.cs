using System;

namespace VeInteractiveAssessment.OneTimePassword.Tests
{
    internal class StubLoginAuditer : IAuditLoginFailures
    {
        private string _auditedUserId;
        private DateTime _auditedDateTime;

        public void Audit(string userId, DateTime dateTime)
        {
            _auditedDateTime = dateTime;
            _auditedUserId = userId;
        }

        public string AuditWasCalledWithUserId()
        {
            return _auditedUserId;
        }

        public DateTime AuditWasCalledWithDateTime()
        {
            return _auditedDateTime;
        }
    }
}