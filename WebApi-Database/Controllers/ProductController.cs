﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Database.DMO;

namespace WebApi_Database.Controllers
{
	[Route("wissen/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		AdventureWorks2019Context _context;
        public ProductController(AdventureWorks2019Context context)
        {
            _context = context;	
        }
		[HttpGet]
        public IActionResult Get()
		{
			var result =_context.Products.AsEnumerable<Product>();
			return Ok(result);

		}
		[HttpGet("Detail")]
		public IActionResult GetById(int id)
		{
			var result = _context.Products.Where(s => s.ProductId == id).FirstOrDefault();
			return Ok(result);
		}
		[HttpGet("Color")]
		public IActionResult FilterColor(string color)
		{
			var result =_context.Products.Where(s => s.Color == color).ToList();
			return Ok(result);
		}
	}
}
