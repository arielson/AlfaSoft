using AlfaSoft.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AlfaSoft.Test
{
    [TestClass]
    public class ContactTest
    {

        [TestMethod]
        public void ContactAddWithAllCorrectFields()
        {
            Contact contact = new()
            {
                Name = "AlfaSoft",
                ContactValue = "999999999",
                Email = "alfasoft@alfasoft.pt"
            };

            var validationResultList = ValidateModel(contact);

            Assert.IsFalse(validationResultList.Any());
        }

        [TestMethod]
        public void ContactAddWithNameLessThanFiveCharacters()
        {
            Contact contact = new()
            {
                Name = "Alfa",
                ContactValue = "999999999",
                Email = "alfasoft@alfasoft.pt"
            };

            var validationResultList = ValidateModel(contact);

            Assert.IsTrue(validationResultList.Any());
            Assert.IsTrue(validationResultList.Where(x => x.MemberNames.Any(y => y == "Name")).Any());
        }

        [TestMethod]
        public void ContactAddWithContactValueDifferenceNineCharacters()
        {
            Contact contact = new()
            {
                Name = "AlfaSoft",
                ContactValue = "9999",
                Email = "alfasoft@alfasoft.pt"
            };

            var validationResultList = ValidateModel(contact);

            Assert.IsTrue(validationResultList.Any());
            Assert.IsTrue(validationResultList.Where(x => x.MemberNames.Any(y => y == "ContactValue")).Any());
        }

        [TestMethod]
        public void ContactAddWithInvalidEmail()
        {
            Contact contact = new()
            {
                Name = "AlfaSoft",
                ContactValue = "999999999",
                Email = "alfasoft@"
            };

            var validationResultList = ValidateModel(contact);

            Assert.IsTrue(validationResultList.Any());
            Assert.IsTrue(validationResultList.Where(x => x.MemberNames.Any(y => y == "Email")).Any());
        }


        private static IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
