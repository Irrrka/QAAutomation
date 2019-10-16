namespace Homework
{
    public static class UserFactory
    {
        public static RegistrationUser CreateValidUser()
        {
            return new RegistrationUser
            {
                FirstName = "Irina",
                LastName = "Marina",
                Date = "7",
                Month = "9",
                Year = "1989",
                Address = "Centre",
                City = "Sofia",
                State = "Alabama",
                Password = "1q2w3e",
                PostCode = "00000",
                Phone = "0887004499",
                Alias = "First"
            };
        }
    }
}
