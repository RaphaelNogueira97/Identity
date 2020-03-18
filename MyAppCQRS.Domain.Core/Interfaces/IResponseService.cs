using MyAppCQRS.Domain.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyAppCQRS.Domain.Core.Interfaces
{
    public interface IResponseService
    {
<<<<<<< HEAD
<<<<<<< HEAD
        Response CreateResponse(object response = null, bool isValid = true);
        Response CreateFailResponse();
=======
        Response CreateResponse(object response, bool isValid);
>>>>>>> Adjust login authentication and implements parcial cache
=======
        Response CreateResponse(object response, bool isValid = true);
>>>>>>> adjust and implementation generic classes, but is broken application
    }
}
