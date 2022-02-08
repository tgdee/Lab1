using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private string academicYear;
        private string email;
        private string major;
        private int employerId;
        private int internshipNumber;
        private int graduationYear;
        private int studentId;
        
        public string FirstNameProperty 
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastNameProperty 
        {
            get { return lastName; }
            set { lastName = value; } 
        }
        public string AcademicYearProperty
        {
            get { return academicYear; }
            set { academicYear = value; }
        }
        public string EmailProperty
        {
            get { return email; }
            set { email = value; } 
        }
        public string MajorProperty 
        {
            get { return major; }
            set { major = value; } 
        }
        public int EmployerIdProperty
        {
            get { return employerId; }
            set { employerId = value; } 
        }
        public int InternshipNumberProperty 
        {
            get { return internshipNumber; }
            set { internshipNumber = value; } 
        }
        public int GraduationYearProperty 
        {
            get { return graduationYear; }
            set {graduationYear = value; } 
        }
        public int StudentIdProperty 
        {
            get { return studentId; }
            set {studentId = value; }
        }
        

        // Constructor
        public Student(int studentId, string firstName, string lastName, int graduationYear, 
            string academicYear, string email, int employerId, int internshipNumber, string major)
        {
            this.studentId = studentId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.graduationYear = graduationYear;
            this.academicYear = academicYear;
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