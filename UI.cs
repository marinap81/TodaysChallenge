using System;
using System.Collections.Generic;
using System.Linq;
using CivSem1Challenge2_RegistrationSystem.helpers;
using CivSem1Challenge2_RegistrationSystem.models;

namespace CivSem1Challenge2_RegistrationSystem
{
    public class UI
    {
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }
        public UI() {
            DataHandler dh = new DataHandler();
            this.Courses = dh.GetCourses();
            this.Students = dh.GetStudents();
            TopMenu();
        }

        public void TopMenu() {
            Console.WriteLine("Welcome to Dod&Gy Student Reg system - Alpha ver");

            Console.WriteLine("1. Print the names and courseNo of the courses");
            Console.WriteLine("2. Get the number of students from course given CourseNo");
            Console.WriteLine("3. Print the name of a student");
            Console.WriteLine("4. Print amount of students in the system");
            Console.WriteLine("5. Print number of students enrolled into valid courses");
            Console.WriteLine("6. Print Add a student");
            Console.WriteLine("7. Print all students who first registered on a given year and a doing a given course");
            Console.WriteLine("8. (optional) Print a list of students NOT enrolled into valid courses");
            Console.WriteLine("9. (optional) Print the oldest student - StudentNo");
            Console.WriteLine("10. (optional) Write the current state of the system back to csv files (save)");
            System.Console.WriteLine("x. Exit");

            var input = Console.ReadLine();
            DataHandler dh = new DataHandler();

            switch(input) {

                case "1":                    
                    this.GetCourseDetails();
                    break;
                
                case "2":
                    System.Console.WriteLine("Please enter the course number");
                    int num;
                    while(!int.TryParse(Console.ReadLine(), out num)) {
                        System.Console.WriteLine("Invalid, enter again");
                    }

                    int numStudents = this.CourseGetNumStudents(num);
                    if(numStudents == -1) {
                        System.Console.WriteLine($"Course {num} doesn't exist");
                        break;
                    }
                    System.Console.WriteLine($"Course {num} has {numStudents} students");
                    break;

                case "3":
                    System.Console.WriteLine("Please enter a student number");
                    while(!int.TryParse(Console.ReadLine(), out num)) {
                        System.Console.WriteLine("Invalid, enter again");
                    }

                    string studentName = this.GetStudentName(num);
                    if(studentName == null) {
                        System.Console.WriteLine($"Student {num} doesn't exist");
                        break;
                    }
                    System.Console.WriteLine($"StudentNo: {num} Name: {studentName}");
                    break;

                case "4":
                    this.GetNumStudents();
                    break;

                case "5":
                    this.GetStudentsEnrolledInCourses();
                    break;

                case "6":
                   this.AddStudent();
                   break;

                case "7":
                    System.Console.WriteLine("Please enter a year");
                    while(!int.TryParse(Console.ReadLine(), out num)) {
                        System.Console.WriteLine("Invalid, enter again");
                    }

                    int courseNum;
                    System.Console.WriteLine("Please enter the course number");
                    while(!int.TryParse(Console.ReadLine(), out courseNum)) {
                        System.Console.WriteLine("Invalid, enter again");
                    }

                    for ( int i = 0 ; i < this.Courses.Count ; ++i )
                    {
                        if ( this.Courses[i].CourseNo == courseNum )
                        {
                            for ( int k = 0 ; k < this.Courses[i].Enrolments.Count ; ++k )
                            {
                                Student myStudent = this.Courses[i].Enrolments[k];

                                if ( myStudent.FirstRegistrationYear == num )
                                {
                                    Console.WriteLine(myStudent.GetFullName());
                                }
                            }
                        }
                    }
                    break;

                case "8":
                    this.GetUnenrolledStudents();
                    break;

                case "9":
                    //TODO: (optional DISTINCTION TASK) - Print the oldest student's studentno
                    break;

                case "10":
                    //TODO: (optional HIGH DISTINCTION TASK) - Write the current state of the system back to the csv files.
                    // add a method to the DataHandler class to do this
                    break;

                case "x":
                    System.Console.WriteLine("Bye bye");
                    return;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }

            this.TopMenu();



            
        }

        private void GetStudentsEnrolledInCourses()
        {
            int total = 0;
            for ( int i = 0 ; i < this.Courses.Count ; ++i )
            {
                Course c = this.Courses[i];
                total += c.Enrolments.Count;
            }

            Console.WriteLine($"Total Students Enrolled: {total}");
        }

        private void GetNumStudents()
        {
            Console.WriteLine($"Number of Students: {this.Students.Count}");
        }

        private void GetCourseDetails()
        {
            for ( int i = 0 ; i < this.Courses.Count ; ++i )
            {
                Course c = this.Courses[i];

                Console.WriteLine($"{c.CourseNo} {c.Name}");
            }
        }

        private string GetStudentName(int num)
        {
            string studentName = null;

            for ( int i = 0 ; i < this.Students.Count ; ++i )
            {
                if ( this.Students[i].StudentNo == num )
                {
                    studentName = this.Students[i].GetFullName();
                }
            }

            return studentName;
        }

        private int CourseGetNumStudents(int num)
        {
            int total = -1;

            for ( int i = 0 ; i < this.Courses.Count ; ++i )
            {
                if ( this.Courses[i].CourseNo == num )
                {
                    total = this.Courses[i].Enrolments.Count;
                }
            }

            return total;
        }

        private void AddStudent()
        {
            string fname;
            string sname;
            int yob;
            int mob;
            int dob;
            int sno;
            int fyor;

            int courseno;

            System.Console.Write("Please enter student's first name: ");
            fname = Console.ReadLine();
            System.Console.Write("Please enter student's surname: ");
            sname = Console.ReadLine();

            System.Console.Write("Please enter student's year of birth: ");
            while(!int.TryParse(Console.ReadLine(), out yob)) {
                System.Console.WriteLine("Invalid, enter again");
            }

            System.Console.Write("Please enter student's month of birth: ");
            while(!int.TryParse(Console.ReadLine(), out mob)) {
                System.Console.WriteLine("Invalid, enter again");
            }

            System.Console.Write("Please enter student's date of birth: ");
            while(!int.TryParse(Console.ReadLine(), out dob)) {
                System.Console.WriteLine("Invalid, enter again");
            }

            System.Console.Write("Please enter student's id/number: ");
            while(!int.TryParse(Console.ReadLine(), out sno)) {
                System.Console.WriteLine("Invalid, enter again");
            }

            System.Console.Write("Please enter student's first year of registration: ");
            while(!int.TryParse(Console.ReadLine(), out fyor)) {
                System.Console.WriteLine("Invalid, enter again");
            }

            Student s = new Student(fname,sname,yob,mob,dob,sno,fyor);
            this.Students.Add(s);


            System.Console.Write("Enter course number to add the student to: ");

            while(!int.TryParse(Console.ReadLine(), out courseno)) 
            {
                System.Console.WriteLine("Invalid, enter again");
            }

            if ( courseno != 0000 )
            {
                int isValid = 0;

                for ( int i = 0 ; i < this.Courses.Count ; ++i )
                {
                    if ( courseno == this.Courses[i].CourseNo )
                    {
                        this.Courses[i].Enrolments.Add(s);
                        isValid = 1;
                    }
                }

                if ( isValid == 0 )
                {
                    Console.WriteLine("Course Number Invalid, Check Course ID");
                }
            }
        }

        private void GetUnenrolledStudents()
        {
            List<int> list = new List<int>();

            for ( int i = 0 ; i < this.Courses.Count ; ++i )
            {
                for ( int k = 0 ; k < this.Courses[i].Enrolments.Count ; ++k )
                {
                    Student s = this.Courses[i].Enrolments[k];
                    list.Add(s.StudentNo);
                }
            }

            for ( int i = 0 ; i < this.Students.Count ; ++i )
            {
                int isFound = 0;

                for ( int k = 0 ; k < list.Count ; ++k )
                {
                    if ( list[k] == this.Students[i].StudentNo )
                    {
                        isFound = 1;
                        break;
                    }
                }

                if ( isFound == 0 )
                {
                    Console.WriteLine("Not Enrolled: " + this.Students[i].GetFullName());
                }
            }
        }
    }
}