using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiABMCActivity.Models
{
	public class Activity
	{
		public Activity()
		{
		}
		public string Id { get; set; }
		public string Author { get; set; }
		public string Area { get; set; }
		public string Title { get; set; }
		public string Institution { get; set; }
		public int AgeMin { get; set; }
		public int AgeMax { get; set; }
		public int ShortDescp { get; set; }
		public string Description{ get; set; }
		public string Files { get; set; }
		public string Duration { get; set; }
		public string Naps { get; set; }
		public DateTime PublishingDate { get; set; }
		public DateTime ModifiedDate { get; set; }

	}
}
