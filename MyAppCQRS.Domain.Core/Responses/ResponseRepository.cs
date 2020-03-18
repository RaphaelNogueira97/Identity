using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Domain.Core.Responses;

namespace MyAppCQRS.Infra.Responses
{
    public class ResponseRepository : IResponseService
    {
        public Response CreateFailResponse()
        {
            return new Response(null, false);
        }
        public Response CreateResponse(object response, bool isValid)
        {
            return new Response(response, isValid);
        }
    }
}
