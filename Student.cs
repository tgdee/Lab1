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
        private int graduationYear;
        private int studentId;
        
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
        public int EmployerId
        {
            get { return employerId; }
            set { employerId = value; } 
        }
        public int InternshipNumber
        {
            get { return internshipNumber; }
            set { internshipNumber = value; } 
        }
        public int GraduationYear 
        {
            get { return graduationYear; }
            set { graduationYear = value; } 
        }
        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }
        public string grade
        {
            get { return grade; }
            set { grade = value; }
        }


        // Overloaded Constructor
        public Student(int studentId, string firstName, string lastName, int graduationYear, 
            string grade, string email, int employerId, int internshipNumber, string major)
        {
            this.studentId = studentId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.graduationYear = graduationYear;
            this.grade = grade;
            this.email = email;
            this.employerId = employerId;
            this.internshipNumber = internshipNumber;
            this.major = major;
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