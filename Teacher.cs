using System;

namespace centerDPO
{
	public class Teacher : Person
	{
		private int teacherId;
		private DateTime hireDate;
		private string specialization;

		public Teacher(string lastName, string firstName, string middleName,
					   DateTime birthDate, string gender, string phone, string email,
					   int teacherId, DateTime hireDate, string specialization)
			: base(lastName, firstName, middleName, birthDate, gender, phone, email)
		{
			this.teacherId = teacherId;
			this.hireDate = hireDate;
			this.specialization = specialization;
		}

		public int TeacherId
		{
			get { return teacherId; }
			set { teacherId = value; }
		}

		public DateTime HireDate
		{
			get { return hireDate; }
			set { hireDate = value; }
		}

		public string Specialization
		{
			get { return specialization; }
			set { specialization = value; }
		}
	}
}