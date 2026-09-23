using System;

namespace centerDPO
{
	public class Student : Person
	{
		private int studentId;
		private DateTime registrationDate;

		public Student(string lastName, string firstName, string middleName,
					   DateTime birthDate, string gender, string phone, string email,
					   int studentId, DateTime registrationDate)
			: base(lastName, firstName, middleName, birthDate, gender, phone, email)
		{
			this.studentId = studentId;
			this.registrationDate = registrationDate;
		}

		public int StudentId
		{
			get { return studentId; }
			set { studentId = value; }
		}

		public DateTime RegistrationDate
		{
			get { return registrationDate; }
			set { registrationDate = value; }
		}
	}
}