using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Data;
using System;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using System.ComponentModel.DataAnnotations;
using MessagePack;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
	public class Stocks
	{
		[Key]
		[Required]
		[NotMapped]
		public string Stkid { get; set; }
		public string? StkDesc { get; set; }
	}
}
