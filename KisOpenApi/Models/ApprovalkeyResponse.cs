﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KisOpenApi;
internal class ApprovalKeyResponse : KisResponseBase
{
    [JsonPropertyName("approval_key")]
    public string ApprovalKey { get; set; } = string.Empty;
}
