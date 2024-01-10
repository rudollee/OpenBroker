using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisOpenApi;
public class ConnectionBase
{
    internal readonly string host = "https://openapi.koreainvestment.com:9443";
    internal readonly string grant_type = "client_credentials";
}
