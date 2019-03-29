namespace TestWebProject.BO
{
    public class ValidUser
    {
        public static User CreateTestUser()
        {
            User user = new User("testuser.19", "testCDP123");
            return user;
        }
    }
}
