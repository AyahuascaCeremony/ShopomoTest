using System;
using NUnit.Framework;

namespace VeInteractiveAssessment.OneTimePassword.Tests
{
    public class AuditingFailedLoginAttempts
    {
        private StubLoginAuditer _loginAuditor;
        private string _incorrectUserId = "INCORRECT_USER_ID";
        private readonly DateTime _stubAuditDateTime = new DateTime(2016, 1, 1, 12, 00, 29);

        [SetUp]
        public void SetUp()
        {
            var dateTime = new StubDateTime();
            _loginAuditor = new StubLoginAuditer();
            var passwordGenerator = new OneTimePasswordGenerator(dateTime, _loginAuditor);

            const string userId = "User01";

            passwordGenerator.GenerateFor(userId);

            dateTime.SetNextDateTime(_stubAuditDateTime);
            passwordGenerator.Validate(_incorrectUserId, "INCORRECT_PASSWORD");
        }

        [Test]
        public void UsernameIsLogged()
        {
            Assert.That(_loginAuditor.AuditWasCalledWithUserId(), Is.EqualTo(_incorrectUserId));
        }

        [Test]
        public void DateTimeIsLogged()
        {
            Assert.That(_loginAuditor.AuditWasCalledWithDateTime(), Is.EqualTo(_stubAuditDateTime));
        }

    }
}
