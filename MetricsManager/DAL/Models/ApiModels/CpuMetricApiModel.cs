﻿using System;

namespace MetricsManager.DAL.Models.ApiModels
{
    public class CpuMetricApiModel
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}
