namespace GettingStarted.Models
{
    public class User 
    {
        public int UserId {get;set;}

        public string UserName{get;set;}

        public string PassWord {get;set;}
        public int RoleId{get;set;}
    }
    public class Role
    {
        public int RoleId {get;set;}
        public string RoleName{get;set;}
    }

}