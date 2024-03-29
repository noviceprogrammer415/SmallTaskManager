﻿using System;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;


namespace MetricsManagerTests
{
    public class NetworkMetricsControllerTests
    {
		private readonly NetworkMetricsController _controller;

		public NetworkMetricsControllerTests()
		{
			
		}

		[Fact]
		public void GetMetricsFromAgent_ResultOk()
		{
			var agentId = 1;
			var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
			var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

			var result = _controller.GetMetricsFromAgent(agentId, fromTime, toTime);

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void GetMetricsFromAllCluster_ResultOk()
		{
			var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
			var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

			var result = _controller.GetMetricsFromAllCluster(fromTime, toTime);

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}
	}
}
