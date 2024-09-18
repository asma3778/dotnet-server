namespace ecommer
{
    public class User
    {
        public int UserId { get; set; }
        public required string FristName { get; set; }
        public required string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
     
    }
}