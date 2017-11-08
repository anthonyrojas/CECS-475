using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public interface IBusinessLayer
    {
        IList<Standard> getAllStandards();
        Standard GetStandardByID(int id);
        void AddStandard(Standard standard);
        void UpdateStandard(Standard standard);
        void RemoveStandard(Standard standard);

        IList<Student> getAllStudents();
        Student GetStudentByID(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);

        IList<Teacher> getAllTeachers();
        Teacher GetTeacherByID(int id);
        Teacher GetTeacherByName(string name);
        void AddTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        void RemoveTeacher(Teacher teacher);

        IList<Course> getAllCourses();
        Course GetCourseByID(int id);
        Course GetCourseByName(string name);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void RemoveCourse(Course course);

        IList<Course> GetCoursesByTeacherID(int id);
        IList<Course> GetCoursesByTeacherName(string name);
    }
}
