using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Domain.Core.Responses;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyAppCQRS.Infra.Responses
{
    public class ResponseRepository : IResponseService
    {
<<<<<<< HEAD
        public Response CreateFailResponse()
        {
            return new Response(null, false);
        }

        public Response CreateResponse(object response, bool isValid)
        {
=======
        public Response CreateResponse(object response, bool isValid)
        {
>>>>>>> Adjust login authentication and implements parcial cache
            return new Response(response, isValid);
        }
    }
}
