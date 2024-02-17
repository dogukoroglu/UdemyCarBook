using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Application.Interfaces.CarDescriptionInterfaces;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;
using UdemyCarBook.Application.Interfaces.ReviewInterfaces;
using UdemyCarBook.Application.Interfaces.StatisticInterfaces;
using UdemyCarBook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarBook.Persistence.Repositories;
using UdemyCarBook.Persistence.Repositories.BlogRepositories;
using UdemyCarBook.Persistence.Repositories.CarDescriptionRepositories;
using UdemyCarBook.Persistence.Repositories.CarFeatureRepositories;
using UdemyCarBook.Persistence.Repositories.CarPricingRepositories;
using UdemyCarBook.Persistence.Repositories.CarRepository;
using UdemyCarBook.Persistence.Repositories.CommentRepositories;
using UdemyCarBook.Persistence.Repositories.RentACarRepositories;
using UdemyCarBook.Persistence.Repositories.ReviewRepositories;
using UdemyCarBook.Persistence.Repositories.StatisticRepositories;
using UdemyCarBook.Persistence.Repositories.TagCloudRepositories;

namespace UdemyCarBook.WebApi.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddCustomServices(this IServiceCollection services)
		{
			var serviceMappings = new Dictionary<Type, Type>
			{
				{ typeof(IRepository<>), typeof(Repository<>) },
				{ typeof(ICarRepository), typeof(CarRepository) },
				{ typeof(IBlogRepository), typeof(BlogRepository) },
				{ typeof(IStatisticRepository), typeof(StatisticRepository)},
				{ typeof(ICarPricingRepository), typeof(CarPricingRepository)},
				{ typeof(ITagCloudRepository), typeof(TagCloudRepository)},
				{ typeof(IRentACarRepository), typeof(RentACarRepository)},
				{ typeof(IGenericRepository<>), typeof(CommentRepository<>)},
				{ typeof(ICarFeatureRepository), typeof(CarFeatureRepository)},
				{ typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository)},
				{ typeof(IReviewRepository), typeof(ReviewRepository)},

			};

			foreach (var serviceMapping in serviceMappings)
			{
				services.AddScoped(serviceMapping.Key, serviceMapping.Value);
			}

			var queryHandlers = new List<Type>
			{
				typeof(GetAboutQueryHandler),
				typeof(GetAboutByIdQueryHandler),
				typeof(CreateAboutCommandHandler),
				typeof(UpdateAboutCommandHandler),
				typeof(RemoveAboutCommandHandler),
				typeof(GetBannerQueryHandler),
				typeof(GetBannerByIdQueryHandler),
				typeof(CreateBannerCommandHandler),
				typeof(UpdateBannerCommandHandler),
				typeof(RemoveBannerCommandHandler),

				typeof(GetBrandQueryHandler),
				typeof(GetBrandByIdQueryHandler),
				typeof(CreateBrandCommandHandler),
				typeof(UpdateBrandCommandHandler),
				typeof(RemoveBrandCommandHandler),

				typeof(GetCarQueryHandler),
				typeof(GetCarByIdQueryHandler),
				typeof(CreateCarCommandHandler),
				typeof(UpdateCarCommandHandler),
				typeof(RemoveCarCommandHandler),
				typeof(GetCarWithBrandQueryHandler),
				typeof(GetLast5CarWithBrandQueryHandler),

				typeof(GetCategoryQueryHandler),
				typeof(GetCategoryByIdQueryHandler),
				typeof(CreateCategoryCommandHandler),
				typeof(UpdateCategoryCommandHandler),
				typeof(RemoveCategoryCommandHandler),

				typeof(GetContactQueryHandler),
				typeof(GetContactByIdQueryHandler),
				typeof(CreateContactCommandHandler),
				typeof(UpdateContactCommandHandler),
				typeof(RemoveContactCommandHandler),
			};
			foreach (var queryHandler in queryHandlers)
			{
				services.AddScoped(queryHandler);
			}
		}
	}
}


//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
//builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
//builder.Services.AddScoped(typeof(IStatisticRepository), typeof(StatisticRepository));
//builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
//builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
//builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
//builder.Services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
//builder.Services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
//builder.Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));

//builder.Services.AddScoped<GetAboutQueryHandler>();
//builder.Services.AddScoped<GetAboutByIdQueryHandler>();
//builder.Services.AddScoped<CreateAboutCommandHandler>();
//builder.Services.AddScoped<UpdateAboutCommandHandler>();
//builder.Services.AddScoped<RemoveAboutCommandHandler>();

//builder.Services.AddScoped<GetBannerQueryHandler>();
//builder.Services.AddScoped<GetBannerByIdQueryHandler>();
//builder.Services.AddScoped<CreateBannerCommandHandler>();
//builder.Services.AddScoped<UpdateBannerCommandHandler>();
//builder.Services.AddScoped<RemoveBannerCommandHandler>();

//builder.Services.AddScoped<GetBrandQueryHandler>();
//builder.Services.AddScoped<GetBrandByIdQueryHandler>();
//builder.Services.AddScoped<CreateBrandCommandHandler>();
//builder.Services.AddScoped<UpdateBrandCommandHandler>();
//builder.Services.AddScoped<RemoveBrandCommandHandler>();

//builder.Services.AddScoped<GetCarQueryHandler>();
//builder.Services.AddScoped<GetCarByIdQueryHandler>();
//builder.Services.AddScoped<CreateCarCommandHandler>();
//builder.Services.AddScoped<UpdateCarCommandHandler>();
//builder.Services.AddScoped<RemoveCarCommandHandler>();
//builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
//builder.Services.AddScoped<GetLast5CarWithBrandQueryHandler>();

//builder.Services.AddScoped<GetCategoryQueryHandler>();
//builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
//builder.Services.AddScoped<CreateCategoryCommandHandler>();
//builder.Services.AddScoped<UpdateCategoryCommandHandler>();
//builder.Services.AddScoped<RemoveCategoryCommandHandler>();

//builder.Services.AddScoped<GetContactQueryHandler>();
//builder.Services.AddScoped<GetContactByIdQueryHandler>();
//builder.Services.AddScoped<CreateContactCommandHandler>();
//builder.Services.AddScoped<UpdateContactCommandHandler>();
//builder.Services.AddScoped<RemoveContactCommandHandler>();