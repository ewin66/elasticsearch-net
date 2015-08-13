using System;
using System.Threading;
using System.Threading.Tasks;

namespace Elasticsearch.Net.Connection
{
	public interface IRequestPipeline : IDisposable
	{
		bool FirstPoolUsageNeedsSniffing { get; }
		bool OutOfDateClusterInformation { get; }
		DateTime StartedOn { get; }
		DateTime CompletedOn { get; }
		bool IsTakingTooLong { get; }

		int Retried { get; }
		int MaxRetries { get; }

		ElasticsearchResponse<TReturn> CallElasticsearch<TReturn>(RequestData requestData);
		Task<ElasticsearchResponse<TReturn>> CallElasticsearchAsync<TReturn>(RequestData requestData);

		void MarkAlive();
		void MarkDead();

		bool NextNode();

		void Ping();
		Task PingAsync();

		void FirstPoolUsage(SemaphoreSlim semaphore);
		Task FirstPoolUsageAsync(SemaphoreSlim semaphore);

		void Sniff();
		Task SniffAsync();

		void BadResponse(IApiCallDetails response);
	}
}