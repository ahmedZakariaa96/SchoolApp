namespace School.Application.DTO
{
    public class JwtAuthResult
    {
        public string AcessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }


    }
    public class RefreshToken
    {
        public string UserName { get; set; }
        public string TokenString { get; set; }
        public DateTime ExpireAt { get; set; }


    }
    public class UserClaimModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string nameIdentifier { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }

}
