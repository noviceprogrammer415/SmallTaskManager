﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace MetricsAgent.Jobs
{
    public class SingletonJobFactory : IJobFactory
    {
	    private readonly IServiceProvider _serviceProvider;

	    public SingletonJobFactory(IServiceProvider serviceProvider)
	    {
		    _serviceProvider = serviceProvider;
	    }

	    public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
	    {
		    return _serviceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
	    }

	    public void ReturnJob(IJob job)
	    {
	    }
    }
}
