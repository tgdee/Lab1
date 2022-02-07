using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    public class Student
    {
        public int studentId { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public int graduationYear { get; private set; }
        public string academicYear { get; private set; }
        public string email { get; private set; }
        public int employerId { get; private set; }
        public int internshipNumber { get; private set; }

        // Constructor
        public Student(int studentId, string firstName, string lastName, int graduationYear, 
            string academicYear, string email, int employerId, int internshipNumber)
        {
            this.studentId = studentId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.graduationYear = graduationYear;
            this.academicYear = academicYear;
            this.email = email;
            this.employerId = employerId;
            this.internshipNumber = internshipNumber;
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