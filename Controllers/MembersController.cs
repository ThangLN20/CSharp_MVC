using System;
using GettingStarted.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GettingStarted.Filters;

namespace GettingStarted.Controllers
{
    public class MembersController:Controller
    {
        public static List<Member> memberList = new();
        public MembersController() {
            if (memberList.Count == 0)
            {
                memberList.Add(new Member(1, "Thang", "Le", "Male", new DateTime(1998, 09, 20), "0987698696", "Ha Noi", false, new DateTime(2021, 3, 15), new DateTime(2021, 6, 15)));
                memberList.Add(new Member(2, "Vinh", "Truong", "Male", new DateTime(2001, 12, 1), "0931252314", "Ha Noi", false, new DateTime(2021, 3, 15), new DateTime(2021, 6, 15)));
                memberList.Add(new Member(3, "Trang", "Bui", "Female", new DateTime(2000, 4, 9), "0934251234", "Ha Noi", false, new DateTime(2021, 3, 15), new DateTime(2021, 6, 15)));
                memberList.Add(new Member(4, "Thang", "Le", "Male", new DateTime(1995, 5, 2), "0934251234", "Ha Noi", false, new DateTime(2021, 3, 15), new DateTime(2021, 6, 15)));
                memberList.Add(new Member(5, "Hanh", "Vu", "Female", new DateTime(1994, 9, 1), "0937582931", "Hai Phong", false, new DateTime(2021, 3, 15), new DateTime(2021, 6, 15)));
                memberList.Add(new Member(6, "Anh", "Tran", "Male", new DateTime(2002, 8, 4), "0931751231", "Can Tho", false, new DateTime(2021, 3, 23), new DateTime(2021, 6, 15)));
            }

        }
        [AuthorizeAttribute("Members")]
        [HttpGet("/admin/listmember")]
        public IActionResult ListMember()
        {
            return View("ListMember", memberList);
        }
        [AuthorizeAttribute("Members")]
        [HttpGet("/admin/create")]
        public IActionResult Create()
        {
            return View("Create");
        }
        [AuthorizeAttribute("Home")]
        [HttpPost("/admin/create")]
        public IActionResult CreatePost(Member member)
        {
            if (memberList.Find(m => m.GetFullName() == member.GetFullName()) != null)
            {
                Console.WriteLine("Member already existed.");
                return RedirectToAction("Create", "Members");
            }
            else if(member.CheckEmptyFields())
            {
                Console.WriteLine("Please fill out every field!");
                return RedirectToAction("Create", "Members");
            }
            else
            {
                member.Id = memberList[^1].Id + 1;
                memberList.Add(member);
                return RedirectToAction("Details", "Members", new {id = member.Id});
            }
        }
        [AuthorizeAttribute("Members")]
        [HttpGet("/members/details/{id}")]
        public IActionResult Details(int id)
        {
            return View("Details", memberList.Find(m => m.Id == id));
        }
        [AuthorizeAttribute("Members")]
        [HttpGet("/members/editmember/{id}")]
        public IActionResult EditMember(int id)
        {
            return View("EditMember", memberList.Find(m => m.Id == id));
        }
        [AuthorizeAttribute("Members")]
        [HttpPost("/members/editmember/{id}")]
        public IActionResult MemberEditPost(int id, Member edited)
        {
            Member member = memberList.Find(m => m.Id == id);
            if (member == null)
            {
                Console.WriteLine("Cannot find member.");
                return RedirectToAction("MemberEdit", "Admin", new { id });
            }
            else if (edited?.CheckEmptyFields() == true)
            {
                Console.WriteLine("Please fill out every field!");
                return RedirectToAction("MemberEdit", "Admin", new { id });
            }
            else
            {
                member.Edit(edited);
                return RedirectToAction("MemberDetails", "Admin", new {id = member.Id});
            }
        }
        [HttpGet("/admin/memberdelete/{id}")]
        public IActionResult MemberDelete(int id)
        {
            Member member = memberList.Find(m => m.Id == id);
            if (member != null)
            {
                memberList.Remove(member);
            }
            return RedirectToAction("ListMember", "Members");
        }
    }

}
