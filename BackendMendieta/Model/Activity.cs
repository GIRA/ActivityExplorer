using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	public class Activity
	{
		public Activity()
		{
		}

		public Activity(string id, string author, string area, string title, string institution, int ageMin, int ageMax, string shortDescp, string description, string files, string duration, string naps, DateTime publishingDate, DateTime modifiedDate)
		{
			Id = id;
			Author = author;
			Area = area;
			Title = title;
			Institution = institution;
			AgeMin = ageMin;
			AgeMax = ageMax;
			ShortDescp = shortDescp;
			Description = description;
			Files = files;
			Duration = duration;
			Naps = naps;
			PublishingDate = publishingDate;
			ModifiedDate = modifiedDate;
		}

		public string Id { get; set; }
		public string Author { get; set; }
		public string Area { get; set; }
		public string Title { get; set; }
		public string Institution { get; set; }
		public int AgeMin { get; set; }
		public int AgeMax { get; set; }
		public string ShortDescp { get; set; }
		public string Description { get; set; }
		public string Files { get; set; }
		public string Duration { get; set; }
		public string Naps { get; set; }
		public DateTime PublishingDate { get; set; } 
		public DateTime ModifiedDate { get; set; }

	}
}
