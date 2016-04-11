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
            var passwordGenerator = new OneTimePasswordGenerator();
            var userId = "User01";

            var password = passwordGenerator.GenerateFor(userId);

            Assert.That(passwordGenerator.Validate(userId, password), Is.True);
        }
    }
}
