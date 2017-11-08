using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataAccessLayer;
namespace Client
{
    public class Program
    {
        static BusinessLayer.BusinessLayer b1 = new BusinessLayer.BusinessLayer();
        public static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            string options = "1. Table Teacher" +
                "\n2. Table Courses" +
                "\n3. Table Standard" +
                "\n4. Table Student" +
                "\n5. Exit Program";
            int entry;
            Console.WriteLine(options);
            Console.Write("\nSelect an option: ");
            entry = ValidInt();
            while (entry != 5)
            {
                switch (entry)
                {
                    case 1: TeacherMenu();
                        break;
                    case 2: CoursesMenu();
                        break;
                    case 3: StandardMenu();
                        break;
                    case 4: StudentMenu();
                        break;
                    case 5:
                        break;
                    default: Console.WriteLine("Invalid entry. Must be between 1 and 5");
                        break;
                }
                Console.WriteLine(options);
                Console.Write("\nSelect an option: ");
                entry = ValidInt();
            }

        }

        static void TeacherMenu()
        {
            string options = "1. Create teacher" +
                "\n2. Delete Teacher" +
                "\n3. Update teacher by searching id" +
                "\n4. Update teacher by searching by name" +
                "\n5. Show all teachers" +
                "\n6. Display courses that have a teacher ID" +
                "\n7. Exit Teacher Table";
            Console.WriteLine(options);
            Console.Write("\nSelect an option: ");
            int entry;
            entry = ValidInt();
            while (entry != 7)
            {
                switch (entry)
                {
                    case 1: ClientCreatesTeacher();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5: ShowAllTeachers();
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    default:
                        break;
                }
                Console.WriteLine(options);
                Console.Write("\nSelect an option: ");
                entry = ValidInt();
            }
        }

        static void CoursesMenu()
        {
            string options = "1. Create a new course" +
                "\n2. Update a course by searching id" +
                "\n3. Update a course by searching course name" +
                "\n4. Delete a course" +
                "\n5. Display all courses" +
                "\n6. Exit Courses Table";
            int entry;
            Console.WriteLine(options);
            Console.Write("\nSelect an option: ");
            entry = ValidInt();
            while (entry != 6)
            {
                switch (entry)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default: Console.WriteLine("Invalid option. Entry must be between 1 and 6.");
                        break;
                }
                Console.WriteLine(options);
                Console.Write("\nSelect an option: ");
                entry = ValidInt();
            }
        }

        static void StandardMenu()
        {
            string options = "1. Create Standard" +
                "\n2. Delete Standard" +
                "\n3. Update standard by searching id" +
                "\n4. Update standard by searching by name" +
                "\n5. Show all standard" +
                "\n6. Display students that have a standard ID" +
                "\n7. Exit Standard Table";
            Console.WriteLine(options);
            Console.Write("\nSelect an option: ");
            int entry;
            entry = ValidInt();
            while (entry != 7)
            {
                switch (entry)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    default:
                        break;
                }
                Console.WriteLine(options);
                Console.Write("\nSelect an option: ");
                entry = ValidInt();
            }
        }

        static void StudentMenu()
        {
            string options = "1. Create a new student" +
                "\n2. Update a student by searching id" +
                "\n3. Update a student by searching course name" +
                "\n4. Delete a student" +
                "\n5. Display all students" +
                "\n6. Exit Students Table";
            int entry;
            Console.WriteLine(options);
            Console.Write("\nSelect an option: ");
            entry = ValidInt();
            while (entry != 6)
            {
                switch (entry)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Invalid option. Entry must be between 1 and 6.");
                        break;
                }
                Console.WriteLine(options);
                Console.Write("\nSelect an option: ");
                entry = ValidInt();
            }
        }

        static void ShowAllTeachers()
        {
            List<Teacher> teacherList = b1.getAllTeachers().ToList();
            foreach(Teacher t in teacherList)
            {
                DisplayTeacher(t);
            }
        }

        static void ClientCreatesTeacher()
        {
            List<Teacher> tList = b1.getAllTeachers().ToList();
            int maxID = tList.Max(x => x.TeacherId);
            //Console.WriteLine("last id: " + maxID);
            int newTeacherID = maxID + 1;
            Console.Write("\nEnter the new teacher name: ");
            string newTeacherName = Console.ReadLine();
            Console.Write("\nEnter a standard ID for this teacher: ");
            int standardIDEntry = ValidInt();
            Standard selectedStandard = b1.GetStandardByID(standardIDEntry);
            if (selectedStandard != null)
            {
                Teacher teacher = new Teacher()
                {
                    TeacherId = newTeacherID,
                    TeacherName = newTeacherName,
                    StandardId = standardIDEntry,
                    Standard = selectedStandard
                };
                b1.AddTeacher(teacher);
                selectedStandard.Teachers.Add(teacher);
                b1.UpdateStandard(selectedStandard);
                DisplayTeacher(teacher);
            }
            else
            {
                Teacher teacher = new Teacher()
                {
                    TeacherId = newTeacherID,
                    TeacherName = newTeacherName,
                    StandardId = standardIDEntry,
                    Standard = null
                };
                DisplayTeacher(teacher);
            }
        }

        static void UpdateTeacherClient(Teacher teacher)
        {
            int entry;
            string options = " 1. Update name " +
                "\n 2. Change standard by id" +
                "\n 3. Add course by id" +
                "\n 4. Remove course by id" +
                "\n 5. Done";
            Console.WriteLine(options);
            Console.Write("\n Enter an option: ");
            entry = Convert.ToInt32(Console.ReadLine());
            int courseIDEntry, standardIDEntry;
            Course changedCourse;
            while (entry != 5)
            {
                switch (entry)
                {
                    case 1:
                        Console.WriteLine("Enter a new name for the teacher");
                        teacher.TeacherName = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter the new standard id you would like this teacher to have");
                        standardIDEntry = Convert.ToInt32(Console.ReadLine());
                        Standard changedStandard = b1.GetStandardByID(standardIDEntry);
                        if (changedStandard != null)
                        {
                            teacher.StandardId = standardIDEntry;
                            teacher.Standard = changedStandard;
                        }
                        else
                        {
                            Console.WriteLine("A standard with that ID does not exist.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Current courses attached to this teacher: ");
                        foreach (Course c in teacher.Courses)
                        {
                            DisplayCourse(c);
                        }
                        Console.WriteLine("Enter the course ID of the course you would like to attach to this teacher");
                        courseIDEntry = Convert.ToInt32(Console.ReadLine());
                        changedCourse = b1.GetCourseByID(courseIDEntry);
                        if (changedCourse != null)
                        {
                            teacher.Courses.Add(changedCourse);
                        }
                        else
                        {
                            Console.WriteLine("A course with that ID does not exist.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Current courses attached to this teacher: ");
                        foreach (Course c in teacher.Courses)
                        {
                            DisplayCourse(c);
                        }
                        Console.WriteLine("Enter the ID of the course you would like to remove from this teacher");
                        courseIDEntry = Convert.ToInt32(Console.ReadLine());
                        changedCourse = b1.GetCourseByID(courseIDEntry);
                        bool containsCourseID = false;
                        foreach (Course c in teacher.Courses)
                        {
                            if (c.CourseId == courseIDEntry)
                            {
                                containsCourseID = true;
                            }
                        }
                        if (changedCourse != null && containsCourseID == true)
                        {
                            teacher.Courses.Remove(changedCourse);
                        }
                        else
                        {
                            Console.WriteLine("A course with that ID does not exist or is not attached to this teacher");
                        }
                        break;
                    case 5: 
                        break;
                    default: Console.WriteLine("Invalid option. Make sure your entry is between 1 and 5");
                        break;
                }
                b1.UpdateTeacher(teacher);
                DisplayTeacher(teacher);
                Console.WriteLine(options);
                Console.Write("\n Enter an option: ");
                entry = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void UpdateCourseClient(Course course)
        {
            int entry;
            string options = " 1. Update course name" +
                "\n 2. Change teacher by ID" +
                "\n 3. Done";
            Console.WriteLine(options);
            Console.Write("\n Enter an option: ");
            entry = Convert.ToInt32(Console.ReadLine());
            string strEntry;
            int idEntry;
            Teacher changedTeacher;
            while (entry != 3)
            {
                switch (entry)
                {
                    case 1:
                        Console.WriteLine("Enter the new course name");
                        strEntry = Console.ReadLine();
                        course.CourseName = strEntry;
                        break;
                    case 2:
                        Console.WriteLine("Enter the new teacher id to associate with this course");
                        idEntry = Convert.ToInt32(Console.ReadLine());
                        changedTeacher = b1.GetTeacherByID(idEntry);
                        if (changedTeacher != null)
                        {
                            course.TeacherId = idEntry;
                            course.Teacher = changedTeacher;
                        }
                        else
                        {
                            Console.WriteLine("A teacher with that ID does not exist.");
                        }
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Invalid input. Must be between 1 and 4");
                        break;
                }
                b1.UpdateCourse(course);
                DisplayCourse(course);
                Console.WriteLine(options);
                Console.Write("\n Enter an option: ");
                entry = Convert.ToInt32(Console.ReadLine());
            }
        }

        public static void DisplayCourse(Course course)
        {
            string blankSpace = " ";
            if (course.Location == null && course.Teacher == null)
            {
                Console.WriteLine("Course ID: {0} \t| Course Name: {1} \t| Location: {2} \t| Teacher ID: {3} \t| Teacher: {4}",
                    course.CourseId,
                    course.CourseName,
                    blankSpace,
                    course.TeacherId,
                    blankSpace
                    );
            }
            else if (course.Teacher == null)
            {
                Console.WriteLine("Course ID: {0} \t| Course Name: {1} \t| Location: {2} \t| Teacher ID: {3} \t| Teacher: {4}",
                    course.CourseId,
                    course.CourseName,
                    course.Location,
                    course.TeacherId,
                    blankSpace
                    );
            }
            else if (course.Location == null)
            {
                Console.WriteLine("Course ID: {0} \t| Course Name: {1} \t| Location: {2} \t| Teacher ID: {3} \t| Teacher: {4}",
                    course.CourseId,
                    course.CourseName,
                    blankSpace,
                    course.TeacherId,
                    course.Teacher.TeacherName
                    );
            }
            else
            {
                Console.WriteLine("Course ID: {0} \t| Course Name: {1} \t| Location: {2} \t| Teacher ID: {3} \t| Teacher: {4}",
                    course.CourseId,
                    course.CourseName,
                    course.Location,
                    course.TeacherId,
                    course.Teacher.TeacherName
                    );
            }
        }

        public static void DisplayTeacher(Teacher teacher)
        {
            if (teacher.Standard != null)
            {
                Console.WriteLine("Teacher ID: {0} \t| Name: {1} \t| Standard ID: {2} \t| Standard: {3}",
                    teacher.TeacherId,
                    teacher.TeacherName,
                    teacher.StandardId,
                    teacher.Standard.StandardName
                 );
            }
            else
            {
                Console.WriteLine("Teacher ID: {0} \t| Name: {1} \t| Standard ID: {2} \t| Standard: {3}",
                    teacher.TeacherId,
                    teacher.TeacherName,
                    teacher.StandardId,
                    " "
                 );
            }
        }

        public static int ValidInt()
        {
            int input;
            while (int.TryParse(Console.ReadLine(), out input) == false)
            {
                Console.WriteLine("Invalid input. Must be an integer.");
            }
            return input;
        }
    }
}
