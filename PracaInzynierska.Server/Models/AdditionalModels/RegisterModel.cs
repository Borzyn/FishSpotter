namespace FishSpotter.Server.Models.AdditionalModels
{
    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmed { get; set; }
        public ErrorCode ErrorCode { get; set; } = ErrorCode.Ok;
        public bool TermsAccept { get; set; } = false;

    }
    public enum ErrorCode
    {
        Ok = 0,
        EmptySpace = 1,
        UsernameWrong = 2,
        UsernameUsed = 3,
        PasswordWrong = 4,
        PasswordsDifference = 5,
        TermsNotAccepted = 6
            
    }
}
