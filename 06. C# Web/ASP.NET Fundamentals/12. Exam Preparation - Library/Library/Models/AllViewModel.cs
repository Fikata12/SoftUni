﻿namespace Library.Models
{
	public class AllViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public string Author { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

		public string Rating { get; set; } = null!;

		public string Category { get; set; } = null!;
	}
}
