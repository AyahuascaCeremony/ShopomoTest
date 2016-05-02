using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace VeInteractiveAssessment.OneTimePassword.Tests
{
    public class GeneratingAndValidatingPasswords
    {
        [Test]
        public void GeneratedPasswordIsValidForTheCorrectUserId()
        {
            var passwordGenerator = new OneTimePasswordGenerator(new RealDateTime(), new StubLoginAuditer());
            const string userId = "User01";

            var password = passwordGenerator.GenerateFor(userId);

            Assert.That(passwordGenerator.Validate(userId, password), Is.True);
        }

        [Test]
        public void GeneratedPasswordIsNotValidForAnIncorrectUserId()
        {
            var passwordGenerator = new OneTimePasswordGenerator(new RealDateTime(), new StubLoginAuditer());

            var password = passwordGenerator.GenerateFor("User01");

            Assert.That(passwordGenerator.Validate("IncorrectUser01", password), Is.False);
        }

        [Test]
        public void PasswordStillValidAfterTwentyNineSeconds()
        {
            var dateTime = new StubDateTime();
            var passwordGenerator = new OneTimePasswordGenerator(dateTime, new StubLoginAuditer());

            const string userId = "User01";

            dateTime.SetNextDateTime(new DateTime(2016, 1, 1, 12, 00, 00));
            var password = passwordGenerator.GenerateFor(userId);

            dateTime.SetNextDateTime(new DateTime(2016, 1, 1, 12, 00, 29));
            Assert.That(passwordGenerator.Validate(userId, password), Is.True);
        }

        [Test]
        public void PasswordIsInvalidAfterThirtyOneSeconds()
        {
            var dateTime = new StubDateTime();
            var passwordGenerator = new OneTimePasswordGenerator(dateTime, new StubLoginAuditer());

            const string userId = "User01";

            dateTime.SetNextDateTime(new DateTime(2016, 1, 1, 12, 00, 00));
            var password = passwordGenerator.GenerateFor(userId);

            dateTime.SetNextDateTime(new DateTime(2016, 1, 1, 12, 00, 31));
            Assert.That(passwordGenerator.Validate(userId, password), Is.False);
        }

        [Test]
        public void PasswordIsInvalidAfterOneMinuteAndOneSecond()
        {
            var dateTime = new StubDateTime();
            var passwordGenerator = new OneTimePasswordGenerator(dateTime, new StubLoginAuditer());

            const string userId = "User01";

            dateTime.SetNextDateTime(new DateTime(2016, 1, 1, 12, 00, 00));
            var password = passwordGenerator.GenerateFor(userId);

            dateTime.SetNextDateTime(new DateTime(2016, 1, 1, 12, 01, 01));
            Assert.That(passwordGenerator.Validate(userId, password), Is.False);
        }
    }

    public class StubDateTime : IDateTime
    {
        private DateTime _dateTime;

        public DateTime Now()
        {
            return _dateTime;
        }

        public void SetNextDateTime(DateTime dateTime)
        {
            _dateTime = dateTime;
        }
    }
}
