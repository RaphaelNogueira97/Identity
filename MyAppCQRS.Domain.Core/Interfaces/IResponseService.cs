using MyAppCQRS.Domain.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyAppCQRS.Domain.Core.Interfaces
{
    public interface IResponseService
    {
        Response CreateResponse(object response = null, bool isValid = true);
        Response CreateFailResponse();
    }
}
