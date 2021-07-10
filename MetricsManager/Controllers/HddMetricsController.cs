﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Client;
using MetricsManager.Requests;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
	[Route("api/metrics/hdd")]
	[ApiController]
	public class HddMetricsController : ControllerBase
	{
		private readonly ILogger<HddMetricsController> _logger;
		private readonly IMetricsAgentClient _metricsAgentClient;

		public HddMetricsController(ILogger<HddMetricsController> logger, IMetricsAgentClient metricsAgentClient)
		{
			_logger = logger;
			_metricsAgentClient = metricsAgentClient;
		}

		[HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
		{
			_logger.LogInformation($"id {agentId} from {fromTime} to {toTime}");

			var metrics = _metricsAgentClient.GetAllHddMetrics(new GetAllHddMetricsApiRequest
			{
				FromTime = fromTime,
				ToTime = toTime
			});

			return Ok(metrics);
		}

		[HttpGet("cluster/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
		{
			_logger.LogInformation($"from {fromTime} to {toTime}");
			return Ok();
		}
	}
}
