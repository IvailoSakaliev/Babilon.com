namespace DataAcsess.Models
{
    public class SingIn :Persone
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public bool isRegisted { get; set; }
    }
}