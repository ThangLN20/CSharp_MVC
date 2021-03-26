using GettingStarted.Models;
using System.Collections.Generic;

namespace GettingStarted.Repository
{
    public interface IMemberRepository
    {
        List<Member> GetMembers();
        Member GetMemberByIndex(int index);
        void AddMember(Member member);
        void DeleteMember(int index);
        Member UpdateMember(int index, Member member);
    }
}