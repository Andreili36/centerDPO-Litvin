using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace centerDPO
{
	public static class FileInputOutput
	{
		private const string DateFormat = "yyyy-MM-dd";

		public static List<string> TextFileRead(string path)
		{
			List<string> result = new List<string>();
			using (StreamReader reader = new StreamReader(path))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					if (!string.IsNullOrWhiteSpace(line))
						result.Add(line);
				}
			}
			return result;
		}

		public static bool TextFileWrite(string path, List<string> data)
		{
			try
			{
				using (StreamWriter writer = new StreamWriter(path, false))
				{
					foreach (string line in data)
					{
						writer.WriteLine(line);
					}
				}
				return true;
			}
			catch (IOException)
			{
				return false;
			}
		}

		public static List<string> StudentsExport(List<Student> source)
		{
			List<string> result = new List<string>();
			foreach (Student s in source)
			{
				result.Add(string.Join(";",
					s.StudentId,
					s.LastName,
					s.FirstName,
					s.MiddleName,
					s.BirthDate.ToString(DateFormat),
					s.Gender,
					s.Phone,
					s.Email,
					s.RegistrationDate.ToString(DateFormat)));
			}
			return result;
		}

		public static bool StudentsImport(List<string> source, List<Student> destination)
		{
			try
			{
				foreach (string line in source)
				{
					string[] p = line.Split(';');
					if (p.Length < 9) continue;

					int id = int.Parse(p[0]);
					string lastName = p[1];
					string firstName = p[2];
					string middleName = p[3];
					DateTime bd = DateTime.ParseExact(p[4], DateFormat,
											CultureInfo.InvariantCulture);
					string gender = p[5];
					string phone = p[6];
					string email = p[7];
					DateTime reg = DateTime.ParseExact(p[8], DateFormat,
											CultureInfo.InvariantCulture);

					destination.Add(new Student(lastName, firstName, middleName,
						bd, gender, phone, email, id, reg));
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static List<string> TeachersExport(List<Teacher> source)
		{
			List<string> result = new List<string>();
			foreach (Teacher t in source)
			{
				result.Add(string.Join(";",
					t.TeacherId,
					t.LastName,
					t.FirstName,
					t.MiddleName,
					t.BirthDate.ToString(DateFormat),
					t.Gender,
					t.Phone,
					t.Email,
					t.HireDate.ToString(DateFormat),
					t.Specialization));
			}
			return result;
		}

		public static bool TeachersImport(List<string> source, List<Teacher> destination)
		{
			try
			{
				foreach (string line in source)
				{
					string[] p = line.Split(';');
					if (p.Length < 10) continue;

					int id = int.Parse(p[0]);
					string lastName = p[1];
					string firstName = p[2];
					string middleName = p[3];
					DateTime bd = DateTime.ParseExact(p[4], DateFormat,
											CultureInfo.InvariantCulture);
					string gender = p[5];
					string phone = p[6];
					string email = p[7];
					DateTime hire = DateTime.ParseExact(p[8], DateFormat,
											CultureInfo.InvariantCulture);
					string spec = p[9];

					destination.Add(new Teacher(lastName, firstName, middleName,
						bd, gender, phone, email, id, hire, spec));
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static List<string> ProgramsExport(List<ProgramInfo> source)
		{
			List<string> result = new List<string>();
			foreach (ProgramInfo p in source)
			{
				result.Add(string.Join(";",
					p.ProgramId,
					p.Name,
					p.Description,
					p.DurationHours,
					p.Category));
			}
			return result;
		}

		public static bool ProgramsImport(List<string> source, List<ProgramInfo> destination)
		{
			try
			{
				foreach (string line in source)
				{
					string[] p = line.Split(';');
					if (p.Length < 5) continue;

					int id = int.Parse(p[0]);
					string name = p[1];
					string desc = p[2];
					int hours = int.Parse(p[3]);
					string cat = p[4];

					destination.Add(new ProgramInfo(id, name, desc, hours, cat));
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}