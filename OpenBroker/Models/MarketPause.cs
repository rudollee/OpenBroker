using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBroker.Models;
public class MarketPause
{
	public TimeOnly Time { get; set; }

	public MarketPauseType PauseType { get; set; }

	public string Symbol { get; set; } = string.Empty;

	public decimal BasePrice { get; set; }

	public decimal TriggerPrice { get; set; }

	public string Remark { get; set; } = string.Empty;

}
