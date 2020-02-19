using MyAppCQRS.Domain.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyAppCQRS.Domain.Core.Interfaces
{
    public interface IResponseService
    {
        Task<Response> CreateResponse(object response, bool isValid);
    }
}
