using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace HSATest
{
    class BusinessEnrollment : Enrollment
    {
		private string FirstName = "";
		private string LastName = "";
		private string BirthDate = "";
		private string PlanType = "";
		private string EffectiveDate = "";
		private string Status = "";
		public BusinessEnrollment(string FirstName, string LastName, string BirthDate, string PlanType, string EffectiveDate)
		{
			this.FirstName = FirstName;
			this.LastName = LastName;
			this.BirthDate = BirthDate;
			this.PlanType = PlanType;
			this.EffectiveDate = EffectiveDate;
			Status = "Rejected";
		}

		public string getFirstName()
		{
			return FirstName;
		}

		public string getLastName()
		{
			return LastName;
		}

		public string getBirthDate()
		{
			return BirthDate;
		}

		public string getPlanType()
		{
			return PlanType;
		}

		public string getEffectiveDate()
		{
			return EffectiveDate;
		}
		public string getStatus()
		{
			return Status;
		}
		public override bool isNotNull()
		{
			if (FirstName == null || LastName == null || BirthDate == null || PlanType == null || EffectiveDate == null)
			{
				return false;
			}

			return true;
		}

		public override bool isValidBirthDate()
		{
			try
			{
				DateTime dt = DateTime.ParseExact(BirthDate, "MMddyyyy", CultureInfo.InvariantCulture);
				return true;
			}
			catch
			{
				return false;
			}

		}

		public override bool isValidEffectiveDate()
		{
			try
			{
				DateTime dt = DateTime.ParseExact(EffectiveDate, "MMddyyyy", CultureInfo.InvariantCulture);
				return true;
			}
			catch
			{
				return false;
			}

		}

		public override bool isValidPlan()
		{
			if (PlanType == "HSA" || PlanType == "HRA" || PlanType == "FSA")
				return true;
			return false;
		}

		public bool validEntry()
		{
			if(isNotNull() && isValidBirthDate() && isValidEffectiveDate() && isValidPlan())
				return true;
			return false;
		}
		
		private bool isEighteen()
		{
			DateTime currentDate = DateTime.Now;
			DateTime birthday = DateTime.ParseExact(BirthDate, "MMddyyyy", CultureInfo.InvariantCulture);
			int age = birthday.AddYears(18).CompareTo(currentDate);
			if (age <= 0)
				return true;
			return false;
		}

		private bool allowedTimeFrame()
		{
			DateTime currentDate = DateTime.Now;
			DateTime startDate = DateTime.ParseExact(EffectiveDate, "MMddyyyy", CultureInfo.InvariantCulture);
			int period = currentDate.AddDays(30).CompareTo(startDate);
			if (period >= 0)
				return true;
			return false;
		}

		public void determineStatus()
		{
			if(isEighteen() && allowedTimeFrame())
			{
				Status = "Accepted";
			}
		}
	}
}
