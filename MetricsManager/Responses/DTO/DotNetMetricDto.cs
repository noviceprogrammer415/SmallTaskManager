﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManager.Responses.DTO
{
    public class DotNetMetricDto : IMetricDto
    {
	    public int AgentId { get; set; }
	    public int Value { get; set; }
	    public DateTimeOffset Time { get; set; }
    }
}
