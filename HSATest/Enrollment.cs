using System;
using System.Collections.Generic;
using System.Text;

namespace HSATest
{
	public abstract class Enrollment
	{
		public abstract bool isNotNull();
		
		public abstract bool isValidBirthDate();
		
		public abstract bool isValidEffectiveDate();
		
		public abstract bool isValidPlan();
		
	};

}
