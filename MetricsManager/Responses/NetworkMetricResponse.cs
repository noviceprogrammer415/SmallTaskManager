﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManager.Responses.DTO;

namespace MetricsManager.Responses
{
    public class NetworkMetricResponse
    {
	    public List<NetworkMetricDto> Metrics { get; set; }
    }
}
