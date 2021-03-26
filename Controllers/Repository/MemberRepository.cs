using System;
using System.Collections.Generic;
using GettingStarted.Models;

namespace GettingStarted.Repository
{
    public class EmployeeRepository 
    {

         private static List<Member> members = new List<Member>()
         {
            new Member(1,"Le Ngoc","Thang","Male",DateTime.Parse("1998-09-20"),"0987698696","Thanh Hoa",true,DateTime.Parse("1998-01-22"),DateTime.Parse("2021-01-22"))
            ,new Member(2,"Le Ngoc","Nam","Male",DateTime.Parse("1998-09-20"),"0987698696","Thanh Hoa",true,DateTime.Parse("1998-01-22"),DateTime.Parse("2021-01-22"))
            ,new Member(3,"Le Ngoc","Hai","Male",DateTime.Parse("1998-09-20"),"0987698696","Thanh Hoa",true,DateTime.Parse("1998-01-22"),DateTime.Parse("2021-01-22"))
         };

    }

} 