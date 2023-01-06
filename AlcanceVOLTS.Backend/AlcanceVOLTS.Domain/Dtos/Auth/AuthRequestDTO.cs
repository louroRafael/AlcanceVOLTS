namespace AlcanceVOLTS.Domain.Dtos.Auth
{
    public class AuthRequestDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string RefreshToken { get; set; }
    }
}
