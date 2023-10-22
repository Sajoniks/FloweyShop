using Flowey.DataLayer.Models.ProductAPI.V1;
using Flowey.Web.Models;

namespace Flowey.Web.Services.IServices;

public interface IBaseService : IDisposable
{
    public ResponseDto ResponseModel { get; set; }
    Task<ResponseDto> SendAsync(ApiRequest apiRequest);
}