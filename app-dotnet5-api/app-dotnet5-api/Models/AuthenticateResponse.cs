namespace DotNetJwtAuth.Models
{
    public class AuthenticateResponse
    {
            public User User { get; set; }
             public string Token { get; set; }
    }

    public class AuthenticateResponse2
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

    }
}
