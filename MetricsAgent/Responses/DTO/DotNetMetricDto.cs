﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsAgent.Responses.DTO
{
    public class DotNetMetricDto
    {
	    public int Id { get; set; }
	    public int Value { get; set; }
	    public DateTimeOffset Time { get; set; }
    }
}
