using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    public class Student
    {
        // Data Field Declarations
        private string firstName;
        private string lastName;
        private string email;
        private string major;
        private string graduationYear;
        private int studentId;
        private string grade;
        private string phoneNumber;
        
        // Property Declarations
        public string FirstName 
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName 
        {
            get { return lastName; }
            set { lastName = value; } 
        }

        public string Email
        {
            get { return email; }
            set { email = value; } 
        }
        public string Major 
        {
            get { return major; }
            set { major = value; } 
        }

        public string GraduationYear 
        {
            get { return graduationYear; }
            set { graduationYear = value; } 
        }
        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }
        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }


        // Overloaded Constructor
        public Student(int studentId, string firstName, string lastName, string graduationYear, 
            string grade, string email, string major, string phoneNumber)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            GraduationYear = graduationYear;
            Grade = grade;
            Email = email;
            Major = major;
            PhoneNumber = phoneNumber;
        }

        public Student()
        {
            StudentId = 0;
            FirstName = "";
            LastName = "";
            GraduationYear = "";
            Grade = "";
            Email = "";
            Major = "";

        }

        public override string ToString()
        {
            String description = "";
            description += this.firstName + "\t" + this.lastName + "\t" +
                this.graduationYear + "\t" + this.grade + "\t" + this.email + "\t" + Major + "\t" + Email;
            return description;
        }


    }

    

}