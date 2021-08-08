﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using MetricsManager.Requests.ApiRequests;
using MetricsManager.Responses.ApiResponses;
using Quartz;

namespace MetricsManager.Jobs
{
	[DisallowConcurrentExecution]
    public class CpuMetricJob : IJob
    {
	    private readonly IAgentsRepository _agentsRepository;
	    private readonly ICpuMetricsRepository _cpuMetricsRepository;
	    private readonly IMetricsAgentClient _metricsAgentClient;
		private readonly IMapper _mapper;

	    public CpuMetricJob(IAgentsRepository agentsRepository,
		    ICpuMetricsRepository cpuMetricsRepository,
		    IMetricsAgentClient agentClient,
			IMapper mapper)
	    {
		    _agentsRepository = agentsRepository;
		    _cpuMetricsRepository = cpuMetricsRepository;
		    _metricsAgentClient = agentClient;
			_mapper = mapper;
	    }

	    public async Task Execute(IJobExecutionContext context)
	    {
			var maxDate = _cpuMetricsRepository.GetMaxDate();

			var registerObjects = _agentsRepository.GetRegisterObjects();

			var metrics = new AllCpuMetricsApiResponse();

			foreach (var registerObject in registerObjects)
			{
				metrics = await _metricsAgentClient.GetAllCpuMetrics(new GetAllCpuMetricsApiRequest
				{
					ClientBaseAddress = new Uri(registerObject.AgentUrl),
					FromTime = maxDate,
					ToTime = DateTimeOffset.UtcNow
				});

				if (registerObject.Enabled)
				{
					foreach (var metric in metrics.Metrics)
					{
						metric.AgentId = registerObject.AgentId;
						_cpuMetricsRepository.Create(_mapper.Map<CpuMetric>(metric));
					}
				}
			}
        }
    }
}
