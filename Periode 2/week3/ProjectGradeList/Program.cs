using System;
using System.Collections.Generic;

namespace ProjectGradeList
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            
            List<Course> gradeList = ReadGradeList(3);
            DisplayGradeList(gradeList);
        }

        int ReadInt(string question)
        {
            Console.Write(question);
            string val = Console.ReadLine();
            return Int32.Parse(val);

        }

        int ReadInt(string question, int min, int max)
        {
            Boolean ask = true;
            int val = -1;
            while (ask)
            {
                val = ReadInt(question);
                if (val >= min && val <= max)
                {
                    ask = false;
                }
                else
                {
                    continue;
                }
            }
            return val;
        }

        string ReadString(string question)
        {
            Console.Write(question);
            string val = Console.ReadLine();
            return val;
        }

        PracticalGrade ReadPracticalGrade(string question)
        {
            string str = "0. None  1. Absent  2. Insufficient  3. Sufficient  4. Good\nPractical grade for " + question + ":  ";
            return (PracticalGrade)ReadInt(str, 0, 4);
        }

        void DisplayPracticalGrade(PracticalGrade practical)
        {
            Console.WriteLine(practical.ToString());
        }
        Course ReadCourse(string question)
        {
            Console.WriteLine(question);
            Course mycourse = new Course();
            mycourse.Name = ReadString("Name of the course: ");
            string str = "Grade for " + mycourse.Name + ": ";
            mycourse.Grade = ReadInt(str, 0, 100);
            mycourse.Practical = ReadPracticalGrade(mycourse.Name);
            Console.WriteLine();
            return mycourse;
        }
        void DisplayCourse(Course course)
        {
            Console.WriteLine("{0, -20}  : {1, -3}     {2}", course.Name, course.Grade, course.Practical.ToString());
        }

        List<Course> ReadGradeList(int nrOfCourses)
        {
            List<Course> mylist= new List<Course>();
            for (int i = 0; i < nrOfCourses; i++)
            {
                mylist.Add(ReadCourse("Enter a course"));
            }
            return mylist;
        }

        void DisplayGradeList(List<Course> gradeList)
        {
            int passed = 0, camlaude = 0, failed = 0;
            foreach(Course course in gradeList)
            {
                DisplayCourse(course);
                if (course.Passed())
                    passed++;
                else
                    failed++;
                if (course.CamLaude())
                    camlaude++;
            }

            if (failed > 0)
            {
                Console.WriteLine("Too bad, you did not graduate, you got {0} retakes", failed);
            }
            else if (camlaude > 0)
            {
                Console.WriteLine("Congratulations, you passed Cam Laude!");
            }
            else
            {
                Console.WriteLine("Congratulations, you graduated!");
            }
        }


    }
}
