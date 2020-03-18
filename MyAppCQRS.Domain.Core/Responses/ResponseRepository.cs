using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Domain.Core.Responses;
using System.Threading.Tasks;

namespace MyAppCQRS.Infra.Responses
{
    public class ResponseRepository : IResponseService
    {
        public async Task<Response> CreateResponse(object response, bool isValid)
        {
            return await Task.FromResult(new Response(response, isValid));
        }
    }
}
