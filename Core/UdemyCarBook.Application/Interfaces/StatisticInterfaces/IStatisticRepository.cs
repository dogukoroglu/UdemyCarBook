using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Interfaces.StatisticInterfaces
{
	public interface IStatisticRepository
	{
		int GetCarCount();
		int GetLocationCount();
		int GetAuthorCount();
		int GetBlogCount();
		int GetBrandCount();
		decimal GetAvgRentPriceForDaily();
		decimal GetAvgRentPriceForWeekly();
		decimal GetAvgRentPriceForMonthly();
		int GetCarCountByTransmissionAuto();
		string GetBrandNameByMaxCar();
		string GetBlogTitleByMaxBlogComment();
		int GetCarCountByKmSmallerThan1000();
		int GetCarCountByFuelGasolineOrDiesel();
		int GetCarCountByElectric();
		string GetCarBrandAndModelByRentPriceDailyMax();
		string GetCarBrandAndModelByRentPriceDailyMin();
	}
}
