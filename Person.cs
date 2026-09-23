using System;

namespace centerDPO
{
	public class Person
	{
		protected string lastName;
		protected string firstName;
		protected string middleName;
		protected DateTime birthDate;
		protected string gender;
		protected string phone;
		protected string email;

		public Person(string lastName, string firstName, string middleName,
					  DateTime birthDate, string gender, string phone, string email)
		{
			this.lastName = lastName;
			this.firstName = firstName;
			this.middleName = middleName;
			this.birthDate = birthDate;
			this.gender = gender;
			this.phone = phone;
			this.email = email;
		}

		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}

		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}

		public string MiddleName
		{
			get { return middleName; }
			set { middleName = value; }
		}

		public DateTime BirthDate
		{
			get { return birthDate; }
			set { birthDate = value; }
		}

		public string Gender
		{
			get { return gender; }
			set { gender = value; }
		}

		public string Phone
		{
			get { return phone; }
			set { phone = value; }
		}

		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		public string GetFullName()
		{
			return $"{lastName} {firstName} {middleName}";
		}

		public int GetAge()
		{
			if (birthDate == default) return 0;
			DateTime now = DateTime.Now;
			int age = now.Year - birthDate.Year;
			if (now < birthDate.AddYears(age)) age--;
			return age;
		}
	}
}