namespace MovieTicketBooking.Data.Models
{
    public class UserPasswordUpdate
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

    }

    public class PasswordUpdateResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
    }
}
