using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using FADY.Services.Lookup.API.Model;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcLookup
{
    public class LookupService //: Lookup.LookupBase
    {
        private readonly ILookupTRepository _repository;
        private readonly ILogger<LookupService> _logger;

        public LookupService(ILookupTRepository repository, ILogger<LookupService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

       // [AllowAnonymous]
        //public override async Task<CustomerLookupResponse> GetLookupById(LookupRequest request, ServerCallContext context)
        //{
        //    _logger.LogInformation("Begin grpc call from method {Method} for Lookup id {Id}", context.Method, request.Id);

        //    var data = await _repository.GetLookupAsync(request.Id);

        //    if (data != null)
        //    {
        //        context.Status = new Status(StatusCode.OK, $"Lookup with id {request.Id} do exist");

        //        return MapToCustomerLookupResponse(data);
        //    }
        //    else
        //    {
        //        context.Status = new Status(StatusCode.NotFound, $"Lookup with id {request.Id} do not exist");
        //    }

        //    return new CustomerLookupResponse();
        //}

        //public override async Task<CustomerLookupResponse> UpdateLookup(CustomerLookupRequest request, ServerCallContext context)
        //{
        //    _logger.LogInformation("Begin grpc call LookupService.UpdateLookupAsync for buyer id {Buyerid}", request.Buyerid);

        //    var customerLookup = MapToCustomerLookup(request);

        //    var response = await _repository.UpdateLookupAsync(customerLookup);

        //    if (response != null)
        //    {
        //        return MapToCustomerLookupResponse(response);
        //    }

        //    context.Status = new Status(StatusCode.NotFound, $"Lookup with buyer id {request.Buyerid} do not exist");

        //    return null;
        //}

        //private CustomerLookupResponse MapToCustomerLookupResponse(CustomerLookup customerLookup)
        //{
        //    var response = new CustomerLookupResponse
        //    {
        //        Buyerid = customerLookup.BuyerId
        //    };

        //    customerLookup.Items.ForEach(item => response.Items.Add(new LookupItemResponse
        //    {
        //        Id = item.Id,
        //        Oldunitprice = (double)item.OldUnitPrice,
        //        Pictureurl = item.PictureUrl,
        //        Productid = item.ProductId,
        //        Productname = item.ProductName,
        //        Quantity = item.Quantity,
        //        Unitprice = (double)item.UnitPrice
        //    }));

        //    return response;
        //}

        //private CustomerLookup MapToCustomerLookup(CustomerLookupRequest customerLookupRequest)
        //{
        //    var response = new CustomerLookup
        //    {
        //        BuyerId = customerLookupRequest.Buyerid
        //    };

        //    customerLookupRequest.Items.ToList().ForEach(item => response.Items.Add(new LookupItem
        //    {
        //        Id = item.Id,
        //        OldUnitPrice = (decimal)item.Oldunitprice,
        //        PictureUrl = item.Pictureurl,
        //        ProductId = item.Productid,
        //        ProductName = item.Productname,
        //        Quantity = item.Quantity,
        //        UnitPrice = (decimal)item.Unitprice
        //    }));

        //    return response;
      //  }
    }
}
