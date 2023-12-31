using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpbLeague.Domain.Enum
{
    public enum StatusCode
    {
        UserNotFound = 0,
        PasswordIncorrect = 10,
        Ok = 200,
        InternalServerError = 500
    }
}
