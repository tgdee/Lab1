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
        private string academicYear;
        private string email;
        private string major;
        private int employerId;
        private int internshipNumber;
        private string graduationYear;
        private int studentId;
        private string grade;
        
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
        public string AcademicYear
        {
            get { return academicYear; }
            set { academicYear = value; }
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
        public string EmployerId
        {
            get { return employerId; }
            set { employerId = value; } 
        }
        public string InternshipNumber
        {
            get { return internshipNumber; }
            set { internshipNumber = value; } 
        }
        public string GraduationYear 
        {
            get { return graduationYear; }
            set { graduationYear = value; } 
        }
        public string StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }
        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }


        // Overloaded Constructor
        public Student(string studentId, string firstName, string lastName, string graduationYear, 
            string grade, string email, string employerId, string internshipNumber, string major)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            GraduationYear = graduationYear;
            Grade = grade;
            Email = email;
            EmployerId = employerId;
            InternshipNumber = internshipNumber;
            Major = major;
        }

        public override string ToString()
        {
            String description = "";
            description += this.firstName + "\t" + this.lastName + "\t" +
                this.graduationYear + "\t" + this.academicYear + "\t" + this.email + "\t" + this.employerId
                + "\t" + this.internshipNumber;
            return description;
        }


    }

    

}