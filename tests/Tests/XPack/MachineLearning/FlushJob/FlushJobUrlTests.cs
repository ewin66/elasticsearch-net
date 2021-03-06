// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

﻿using System.Threading.Tasks;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework.EndpointTests;
using static Tests.Framework.EndpointTests.UrlTester;

namespace Tests.XPack.MachineLearning.FlushJob
{
	public class FlushJobUrlTests : UrlTestsBase
	{
		[U] public override async Task Urls() => await POST("/_ml/anomaly_detectors/job_id/_flush")
			.Fluent(c => c.MachineLearning.FlushJob("job_id"))
			.Request(c => c.MachineLearning.FlushJob(new FlushJobRequest("job_id")))
			.FluentAsync(c => c.MachineLearning.FlushJobAsync("job_id"))
			.RequestAsync(c => c.MachineLearning.FlushJobAsync(new FlushJobRequest("job_id")));
	}
}
