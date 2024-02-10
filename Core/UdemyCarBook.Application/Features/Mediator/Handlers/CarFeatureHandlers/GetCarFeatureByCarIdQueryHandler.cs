﻿using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarFeatureResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
	public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
	{
		private readonly ICarFeatureRepository _repository;
		public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarFeaturesByCarId(request.Id);
			return values.Select(x => new GetCarFeatureByCarIdQueryResult
			{
				Available = x.Available,
				CarFeatureID = x.CarFeatureID,
				FeatureID = x.FeatureID,
				FeatureName = x.Feature.Name
			}).ToList();
		}
	}
}
