using NUnit.Framework;

namespace Homework.Pages
{
    public partial class RegistrationPage
    {
        public void AssertErrorMessage(string expected)
        {
            Assert.AreEqual(expected, ErrotMessage.Text);
        }
    }
}
