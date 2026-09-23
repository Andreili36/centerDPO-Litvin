using System;
using System.Collections.Generic;

namespace centerDPO
{
	public class Course
	{
		private int courseId;
		private ProgramInfo program;
		private DateTime startDate;
		private DateTime endDate;
		private Teacher teacher;
		private List<Student> students;
		private int maxStudents;

		public Course(int courseId, ProgramInfo program, DateTime startDate,
					  DateTime endDate, Teacher teacher, int maxStudents)
		{
			this.courseId = courseId;
			this.program = program;
			this.startDate = startDate;
			this.endDate = endDate;
			this.teacher = teacher;
			this.students = new List<Student>();
			this.maxStudents = maxStudents;
		}

		public int CourseId
		{
			get { return courseId; }
			set { courseId = value; }
		}

		public ProgramInfo Program
		{
			get { return program; }
			set { program = value; }
		}

		public DateTime StartDate
		{
			get { return startDate; }
			set { startDate = value; }
		}

		public DateTime EndDate
		{
			get { return endDate; }
			set { endDate = value; }
		}

		public Teacher Teacher
		{
			get { return teacher; }
			set { teacher = value; }
		}

		public List<Student> Students
		{
			get { return students; }
			set { students = value; }
		}

		public int MaxStudents
		{
			get { return maxStudents; }
			set { maxStudents = value; }
		}
		public bool AddStudent(Student student)
		{
			if (student == null) return false;
			if (students.Count >= maxStudents) return false;
			students.Add(student);
			return true;
		}

		public bool RemoveStudent(Student student)
		{
			if (student == null) return false;
			return students.Remove(student);
		}

		public bool AssignTeacher(Teacher teacher)
		{
			if (teacher == null) return false;
			this.teacher = teacher;
			return true;
		}
	}
}