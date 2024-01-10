using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBroker;

public interface IConnection
{
    bool IsConnected { get; }

    void SetKeys(string appkey, string appsecret);

    bool Connect();

    bool Disconnect();
}
