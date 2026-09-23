using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace centerDPO
{
	public class MainApp
	{
		static List<Student> students = new List<Student>();
		static List<Teacher> teachers = new List<Teacher>();
		static List<ProgramInfo> programs = new List<ProgramInfo>();
		static List<Course> courses = new List<Course>();

		static readonly string studentsFile = "students.txt";
		static readonly string teachersFile = "teachers.txt";
		static readonly string programsFile = "programs.txt";

		static void Main(string[] args)
		{
			ImportData();

			bool exit = false;
			while (!exit)
			{
				Console.WriteLine("\n============ МЕНЮ ============");
				Console.WriteLine("1. Добавить студента");
				Console.WriteLine("2. Добавить преподавателя");
				Console.WriteLine("3. Добавить программу обучения");
				Console.WriteLine("4. Добавить курс");
				Console.WriteLine("5. Показать все данные");
				Console.WriteLine("0. Выход");
				Console.Write("Ваш выбор: ");

				string choice = Console.ReadLine();
				switch (choice)
				{
					case "1": AddStudent(); break;
					case "2": AddTeacher(); break;
					case "3": AddProgram(); break;
					case "4": AddCourse(); break;
					case "5": ShowAll(); break;
					case "0": exit = true; break;
					default:
						Console.WriteLine("Неверный пункт меню. Повторите ввод.");
						break;
				}
			}

			ExportData();
			Console.WriteLine("Данные сохранены. До свидания!");
		}

		static void AddStudent()
		{
			try
			{
				Console.Write("ID студента: ");
				int id = int.Parse(Console.ReadLine());

				Console.Write("Фамилия: ");
				string ln = Console.ReadLine();
				Console.Write("Имя: ");
				string fn = Console.ReadLine();
				Console.Write("Отчество: ");
				string mn = Console.ReadLine();

				Console.Write("Дата рождения (yyyy-MM-dd): ");
				DateTime bd = DateTime.ParseExact(Console.ReadLine(),
					"yyyy-MM-dd", CultureInfo.InvariantCulture);

				Console.Write("Пол (м/ж): ");
				string gender = Console.ReadLine();
				Console.Write("Телефон: ");
				string phone = Console.ReadLine();
				Console.Write("Email: ");
				string email = Console.ReadLine();

				Student s = new Student(ln, fn, mn, bd, gender, phone, email,
										id, DateTime.Now);
				students.Add(s);
				Console.WriteLine("Студент успешно добавлен.");
			}
			catch (Exception e)
			{
				Console.WriteLine("Ошибка ввода: " + e.Message);
			}
		}

		static void AddTeacher()
		{
			try
			{
				Console.Write("ID преподавателя: ");
				int id = int.Parse(Console.ReadLine());

				Console.Write("Фамилия: ");
				string ln = Console.ReadLine();
				Console.Write("Имя: ");
				string fn = Console.ReadLine();
				Console.Write("Отчество: ");
				string mn = Console.ReadLine();

				Console.Write("Дата рождения (yyyy-MM-dd): ");
				DateTime bd = DateTime.ParseExact(Console.ReadLine(),
					"yyyy-MM-dd", CultureInfo.InvariantCulture);

				Console.Write("Пол (м/ж): ");
				string gender = Console.ReadLine();
				Console.Write("Телефон: ");
				string phone = Console.ReadLine();
				Console.Write("Email: ");
				string email = Console.ReadLine();

				Console.Write("Дата приёма (yyyy-MM-dd): ");
				DateTime hire = DateTime.ParseExact(Console.ReadLine(),
					"yyyy-MM-dd", CultureInfo.InvariantCulture);

				Console.Write("Специализация: ");
				string spec = Console.ReadLine();

				Teacher t = new Teacher(ln, fn, mn, bd, gender, phone, email,
										id, hire, spec);
				teachers.Add(t);
				Console.WriteLine("Преподаватель успешно добавлен.");
			}
			catch (Exception e)
			{
				Console.WriteLine("Ошибка ввода: " + e.Message);
			}
		}

		static void AddProgram()
		{
			try
			{
				Console.Write("ID программы: ");
				int id = int.Parse(Console.ReadLine());

				Console.Write("Наименование: ");
				string name = Console.ReadLine();
				Console.Write("Описание: ");
				string desc = Console.ReadLine();

				Console.Write("Продолжительность (часы): ");
				int hours = int.Parse(Console.ReadLine());

				Console.Write("Категория: ");
				string category = Console.ReadLine();

				ProgramInfo p = new ProgramInfo(id, name, desc, hours, category);
				programs.Add(p);
				Console.WriteLine("Программа обучения успешно добавлена.");
			}
			catch (Exception e)
			{
				Console.WriteLine("Ошибка ввода: " + e.Message);
			}
		}

		static void AddCourse()
		{
			try
			{
				Console.Write("ID курса: ");
				int id = int.Parse(Console.ReadLine());

				Console.Write("ID программы обучения: ");
				int progId = int.Parse(Console.ReadLine());
				ProgramInfo prog = programs.Find(p => p.ProgramId == progId);
				if (prog == null)
				{
					Console.WriteLine("Программа с таким ID не найдена.");
					return;
				}

				Console.Write("Дата начала (yyyy-MM-dd): ");
				DateTime start = DateTime.ParseExact(Console.ReadLine(),
					"yyyy-MM-dd", CultureInfo.InvariantCulture);

				Console.Write("Дата окончания (yyyy-MM-dd): ");
				DateTime end = DateTime.ParseExact(Console.ReadLine(),
					"yyyy-MM-dd", CultureInfo.InvariantCulture);

				Console.Write("Максимальное число студентов: ");
				int max = int.Parse(Console.ReadLine());

				Course c = new Course(id, prog, start, end, null, max);
				courses.Add(c);
				Console.WriteLine("Курс успешно добавлен.");
			}
			catch (Exception e)
			{
				Console.WriteLine("Ошибка ввода: " + e.Message);
			}
		}

		static void ShowAll()
		{
			Console.WriteLine($"\nСтудентов: {students.Count}; " +
							  $"Преподавателей: {teachers.Count}; " +
							  $"Программ: {programs.Count}; " +
							  $"Курсов: {courses.Count}");

			Console.WriteLine("\n-- Студенты --");
			foreach (var s in students)
				Console.WriteLine($"  #{s.StudentId} {s.GetFullName()}, " +
								  $"возраст: {s.GetAge()}");

			Console.WriteLine("\n-- Преподаватели --");
			foreach (var t in teachers)
				Console.WriteLine($"  #{t.TeacherId} {t.GetFullName()}, " +
								  $"специализация: {t.Specialization}");

			Console.WriteLine("\n-- Программы --");
			foreach (var p in programs)
				Console.WriteLine($"  #{p.ProgramId} {p.Name}, {p.DurationHours} ч.");

			Console.WriteLine("\n-- Курсы --");
			foreach (var c in courses)
				Console.WriteLine($"  #{c.CourseId} ({c.Program?.Name}), " +
								  $"студентов: {c.Students.Count}/{c.MaxStudents}");
		}

		static void ImportData()
		{
			try
			{
				if (File.Exists(studentsFile))
					FileInputOutput.StudentsImport(
						FileInputOutput.TextFileRead(studentsFile), students);

				if (File.Exists(teachersFile))
					FileInputOutput.TeachersImport(
						FileInputOutput.TextFileRead(teachersFile), teachers);

				if (File.Exists(programsFile))
					FileInputOutput.ProgramsImport(
						FileInputOutput.TextFileRead(programsFile), programs);

				Console.WriteLine("Импорт данных выполнен.");
			}
			catch (IOException e)
			{
				Console.WriteLine("Ошибка импорта данных: " + e.Message);
			}
		}

		static void ExportData()
		{
			try
			{
				FileInputOutput.TextFileWrite(studentsFile,
					FileInputOutput.StudentsExport(students));

				FileInputOutput.TextFileWrite(teachersFile,
					FileInputOutput.TeachersExport(teachers));

				FileInputOutput.TextFileWrite(programsFile,
					FileInputOutput.ProgramsExport(programs));
			}
			catch (IOException e)
			{
				Console.WriteLine("Ошибка экспорта данных: " + e.Message);
			}
		}
	}
}