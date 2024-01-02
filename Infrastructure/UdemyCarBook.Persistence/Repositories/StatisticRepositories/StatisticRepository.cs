using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.StatisticInterfaces;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.StatisticRepositories
{
	public class StatisticRepository : IStatisticRepository
	{
		private readonly CarBookContext _context;
		public StatisticRepository(CarBookContext context)
		{
			_context = context;
		}

		public string GetBlogTitleByMaxBlogComment()
		{
			throw new NotImplementedException();
		}

		public string GetBrandNameByMaxCar()
		{
			throw new NotImplementedException();
		}

		public int GetAuthorCount()
		{
			var value = _context.Authors.Count();
			return value;
		}

		public decimal GetAvgRentPriceForDaily()
		{
			int id = _context.Pricings.Where(x=>x.Name == "Günlük").Select(y=>y.PricingID).FirstOrDefault();
			var value = _context.CarPricings.Where(w=>w.CarPricingID == id).Average(x => x.Amount);
			return value;
		}

		public decimal GetAvgRentPriceForMonthly()
		{
			int id = _context.Pricings.Where(x => x.Name == "Aylık").Select(y => y.PricingID).FirstOrDefault();
			var value = _context.CarPricings.Where(w => w.CarPricingID == id).Average(x => x.Amount);
			return value;
		}

		public decimal GetAvgRentPriceForWeekly()
		{
			int id = _context.Pricings.Where(x => x.Name == "Haftalık").Select(y => y.PricingID).FirstOrDefault();
			var value = _context.CarPricings.Where(w => w.CarPricingID == id).Average(x => x.Amount);
			return value;
		}

		public int GetBlogCount()
		{
			var value = _context.Blogs.Count();
			return value;
		}

		public int GetBrandCount()
		{
			var value = _context.Brands.Count();
			return value;
		}

		public string GetCarBrandAndModelByRentPriceDailyMax()
		{
			throw new NotImplementedException();
		}

		public string GetCarBrandAndModelByRentPriceDailyMin()
		{
			throw new NotImplementedException();
		}

		public int GetCarCount()
		{
			var value = _context.Cars.Count();
			return value;
		}

		public int GetCarCountByElectric()
		{
			var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
			return value;
		}

		public int GetCarCountByFuelGasolineOrDiesel()
		{
			var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
			return value;
		}

		public int GetCarCountByKmSmallerThan1000()
		{
			var value = _context.Cars.Where(x => x.Km <= 1000).Count();
			return value;
		}

		public int GetCarCountByTransmissionAuto()
		{
			var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
			return value;
		}

		public int GetLocationCount()
		{
			var value = _context.Locations.Count();
			return value;
		}
	}
}
