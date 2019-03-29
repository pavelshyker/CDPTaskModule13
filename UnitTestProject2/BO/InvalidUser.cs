namespace TestWebProject.BO
{
    public class InvalidUser
    {
        public static User CreateTestUser()
        {
            User user = new User("invalid112233qqaa", "666666666");
            return user;
        }
    }
}
