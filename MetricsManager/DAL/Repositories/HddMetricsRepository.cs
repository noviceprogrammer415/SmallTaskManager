﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using MetricsManager.DAL.Repositories.Connection;

namespace MetricsManager.DAL.Repositories
{
    public class HddMetricsRepository : IHddMetricsRepository
    {
	    private readonly IConnection _connection;

	    public HddMetricsRepository(IConnection connection)
	    {
		    _connection = connection;
	    }


	    public void Create(HddMetric item)
	    {
		    using var connection = _connection.GetOpenedConnection();

		    connection.Execute("INSERT INTO hddmetrics(agentId, value, time) VALUES(@agentId, @value, @time)",
			    new
			    {
					agentId = item.AgentId,
				    value = item.Value,
				    time = item.Time
			    });
		}

	    public IList<HddMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
			using var connection = _connection.GetOpenedConnection();

			return connection
				.Query<HddMetric>("SELECT id, agentId, value, time FROM hddmetrics WHERE time>=@fromTime AND time<=@toTime",
					new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds() })
				.ToList();
		}
    }
}