using System;
using System.ComponentModel.DataAnnotations;

namespace GettingStarted.Models
{
    public class Member : Person
    {
        private DateTime startDate;
        private DateTime endDate;
        public DateTime StartDate
        {
            set
            {
                this.startDate = value;
            }
            get
            {
                return this.startDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                this.endDate = value;
            }
            get
            {
                return this.endDate;
            }
        }
        public Member(int id, string firstName, string lastName, string gender, DateTime dateOfBirth, string phoneNumber, string birthPlace, bool isGraduated, DateTime startDate, DateTime endDate) 
                : base(id, firstName, lastName, gender, dateOfBirth, phoneNumber, birthPlace, isGraduated)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }

        // toString infomation of person about id, ...
        
        public String GetFullName() {
            return $"{this.FirstName} {this.LastName}";
        }
        public String GetDateOfBirth() {
            return this.DateOfBirth.ToString("yyyy/MM/dd");
        }
        public String GetStartDate() {
            return this.DateOfBirth.ToString("yyyy/MM/dd");
        }
        public String GetEndDate() {
            return this.DateOfBirth.ToString("yyyy/MM/dd");
        }

        public void Edit(Member edited) {
            FirstName = edited.FirstName;
            LastName = edited.LastName;
            Gender = edited.Gender;
            DateOfBirth = edited.DateOfBirth;
            PhoneNumber = edited.PhoneNumber;
            BirthPlace = edited.BirthPlace;
            IsGraduated = edited.IsGraduated;
            StartDate = edited.StartDate;
            EndDate = edited.EndDate;
        }
        public bool CheckEmptyFields() {
            return String.IsNullOrWhiteSpace(FirstName) ||
                String.IsNullOrWhiteSpace(LastName) ||
                String.IsNullOrWhiteSpace(Gender) ||
                String.IsNullOrWhiteSpace(PhoneNumber) ||
                String.IsNullOrWhiteSpace(BirthPlace) ||
                CheckDefaultDate(DateOfBirth) ||
                CheckDefaultDate(StartDate) ||
                CheckDefaultDate(EndDate);
        }

        private static bool CheckDefaultDate(DateTime date) {
            return date == new DateTime();
        }
    }
}