﻿using Common.Application;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers.Edit
{
    public class EditSellerCommandHadler : IBaseCommandHandler<EditSellerCommand>
    {
        private readonly ISellerRepository _repository;
        private readonly ISellerDomainService _domainService;

        public EditSellerCommandHadler(ISellerRepository repository, ISellerDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(EditSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = await _repository.GetTracking(request.id);
            if (seller == null)
                return OperationResult.NotFound();

            seller.Edit(request.shopName, request.sellerStatus, request.nationalCode, _domainService);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
