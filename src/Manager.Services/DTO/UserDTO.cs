namespace Manager.Services.DTO
{
    public class UserDTO
    {
        public long Id {get; set;}
        public string Name {get; set;}

        public string Email {get; set;}

        public string PassWord{get; set;}

        public UserDTO()
        {}
        public UserDTO(long id, string name, string email, string passWord)
        {
            Id = id;
            Name = name;
            Email = email;
            PassWord = passWord;
        }

    }
}