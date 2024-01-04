using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.StatisticDtos
{
	public class ResultStatisticDto
	{
		public int carCount { get; set; }
		public int locationCount { get; set; }
		public int authorCount { get; set; }
		public int blogCount { get; set; }
		public int brandCount { get; set; }
		public decimal avgPriceForDaily { get; set; }
		public decimal avgRentPriceForWeekly { get; set; }
		public decimal avgRentPriceForMonthly { get; set; }
		public int carCountByTransmissionAuto { get; set; }
		public int carCountByKmSmallerThan1000 { get; set; }
		public int carCountByFuelGasolineOrDiesel { get; set; }
		public int carCountByElectric { get; set; }
		public string carBrandAndModelByRentPriceDailyMax { get; set; }
		public string carBrandAndModelByRentPriceDailyMin { get; set; }
		public string brandNameByMaxCar { get; set; }
		public string blogTitleByMaxBlogComment { get; set; }
	}
}
