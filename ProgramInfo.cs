namespace centerDPO
{
	public class ProgramInfo
	{
		private int programId;
		private string name;
		private string description;
		private int durationHours;
		private string category;

		public ProgramInfo(int programId, string name, string description,
						   int durationHours, string category)
		{
			this.programId = programId;
			this.name = name;
			this.description = description;
			this.durationHours = durationHours;
			this.category = category;
		}

		public int ProgramId
		{
			get { return programId; }
			set { programId = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		public int DurationHours
		{
			get { return durationHours; }
			set { durationHours = value; }
		}

		public string Category
		{
			get { return category; }
			set { category = value; }
		}
	}
}