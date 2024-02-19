using System;
using Microsoft.AspNetCore.Mvc;
using OrderFoodApi.Interfaces;
using OrderFoodApi.Models;

namespace OrderFoodApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DelivererReviewController : Controller
	{
		private readonly IRepository<DelivererReview> _drr;

		public DelivererReviewController(IRepository<DelivererReview> drr)
		{
			_drr = drr;
		}

	}
}

