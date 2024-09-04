﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBroker.Models;

public class Equity
{
	public string Symbol { get; set; } = string.Empty;

	public ExchangeSection Section { get; set; } = ExchangeSection.NONE;

	public string NameOfficial { get; set; } = string.Empty;

	public string NameAlt { get; set; } = string.Empty;

	public DiscardStatus DiscardStatus { get; set; } = DiscardStatus.TRADABLE;
}