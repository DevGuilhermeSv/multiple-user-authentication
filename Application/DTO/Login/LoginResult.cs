namespace Application.DTO.Login
{
    public class LoginResult
    {
        public string? Token { get; set; }
        public DateTime? ValidTo { get; set; }
    }

}
