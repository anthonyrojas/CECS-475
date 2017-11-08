using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IStandardRepository standardRepository;
        private readonly IStudentRepository studentRepository;
        private readonly ITeacherRepository teacherRepository;
        private readonly ICourseRepository courseRepository;

        public BusinessLayer()
        {
            standardRepository = new StandardRepository();
            studentRepository = new StudentRepository();
            courseRepository = new CourseRepository();
            teacherRepository = new TeacherRepository();
        }

        public void AddStandard(Standard standard)
        {
            standardRepository.Insert(standard);
            //throw new NotImplementedException();
        }

        public void AddStudent(Student student)
        {
            studentRepository.Insert(student);
            //throw new NotImplementedException();
        }

        public IList<Standard> getAllStandards()
        {
            return standardRepository.GetAll().ToList();
        }

        public IList<Student> getAllStudents()
        {
            return studentRepository.GetAll().ToList();
            //throw new NotImplementedException();
        }

        public Standard GetStandardByID(int id)
        {
            return standardRepository.GetById(id);
            //throw new NotImplementedException();
        }

        public Student GetStudentByID(int id)
        {
            return studentRepository.GetById(id);
            //throw new NotImplementedException();
        }

        public void RemoveStandard(Standard standard)
        {
            standardRepository.Delete(standard);
            //throw new NotImplementedException();
        }

        public void RemoveStudent(Student student)
        {
            studentRepository.Delete(student);
            //throw new NotImplementedException();
        }

        public void UpdateStandard(Standard standard)
        {
            standardRepository.Update(standard);
            //throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            studentRepository.Update(student);
            //throw new NotImplementedException();
        }

        public IList<Teacher> getAllTeachers()
        {
            return teacherRepository.GetAll().ToList();
        }

        public Teacher GetTeacherByID(int id)
        {
            return teacherRepository.GetById(id);
        }

        public Teacher GetTeacherByName(string name)
        {
            return teacherRepository.GetSingle(t => t.TeacherName.Equals(name), t => t.Standard);
        }

        public void AddTeacher(Teacher teacher)
        {
            teacherRepository.Insert(teacher);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            teacherRepository.Update(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            teacherRepository.Delete(teacher);
        }

        public IList<Course> getAllCourses()
        {
            return courseRepository.GetAll().ToList();
        }

        public Course GetCourseByID(int id)
        {
            return courseRepository.GetById(id);
        }

        public Course GetCourseByName(string name)
        {
            return courseRepository.GetSingle(c => c.CourseName.Equals(name), c => c.Teacher);
        }

        public void AddCourse(Course course)
        {
            courseRepository.Insert(course);
        }

        public void UpdateCourse(Course course)
        {
            courseRepository.Update(course);
        }

        public void RemoveCourse(Course course)
        {
            courseRepository.Delete(course);
        }

        public IList<Course> GetCoursesByTeacherID(int id)
        {
            return courseRepository.SearchFor(c => c.TeacherId == id).ToList<Course>();
        }

        public IList<Course> GetCoursesByTeacherName(string name)
        {
            return courseRepository.SearchFor(c => c.Teacher.TeacherName == name).ToList<Course>();
        }
    }
}
