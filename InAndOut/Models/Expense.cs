﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
	public class Expense
	{
		[Key]
		public int MyPropertIdy { get; set; }
		[DisplayName("Expense")]
		[Required]
		public string ExpenseName { get; set; }
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Amount must be greater then 0")]
		public int Amount { get; set; }

	}
}
