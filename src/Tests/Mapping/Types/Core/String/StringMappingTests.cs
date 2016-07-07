﻿using System;
using Nest;

#pragma warning disable 618
namespace Tests.Mapping.Types.Core.String
{
	public class StringTest
	{
		[String(
			Analyzer = "myanalyzer",
			Boost = 1.2,
			DocValues = true,
			IgnoreAbove = 50,
			IncludeInAll = false,
			Index = FieldIndexOption.NotAnalyzed,
			IndexOptions = IndexOptions.Offsets,
			NullValue = "na",
			PositionIncrementGap = 5,
			SearchAnalyzer = "mysearchanalyzer",
			Similarity = SimilarityOption.BM25,
			Store = true,
			TermVector = TermVectorOption.WithPositionsOffsets)]
		public string Full { get; set; }

		[String]
		public string Minimal { get; set; }

		public string Inferred { get; set; }

		public char Char { get; set; }

		public Guid Guid { get; set; }
	}

	public class StringMappingTests : TypeMappingTestBase<StringTest>
	{
		protected override object ExpectJson => new
		{
			properties = new
			{
				full = new
				{
					type = "string",
					analyzer = "myanalyzer",
					boost = 1.2,
					doc_values = true,
					ignore_above = 50,
					include_in_all = false,
					index = "not_analyzed",
					index_options = "offsets",
					null_value = "na",
					position_increment_gap = 5,
					search_analyzer = "mysearchanalyzer",
					similarity = "BM25",
					store = true,
					term_vector = "with_positions_offsets"
				},
				minimal = new
				{
					type = "string"
				},
				inferred = new
				{
					type = "text",
					fields = new
					{
						keyword = new
						{
							type = "keyword"
						}
					}
				},
				@char = new
				{
					type = "keyword"
				},
				guid = new
				{
					type = "keyword"
				}
			}
		};

		protected override Func<PropertiesDescriptor<StringTest>, IPromise<IProperties>> FluentProperties => p => p
			.String(s => s
				.Name(o => o.Full)
				.Analyzer("myanalyzer")
				.Boost(1.2)
				.DocValues()
				.IgnoreAbove(50)
				.IncludeInAll(false)
				.Index(FieldIndexOption.NotAnalyzed)
				.IndexOptions(IndexOptions.Offsets)
				.NullValue("na")
				.PositionIncrementGap(5)
				.SearchAnalyzer("mysearchanalyzer")
				.Similarity(SimilarityOption.BM25)
				.Store(true)
				.TermVector(TermVectorOption.WithPositionsOffsets)
			)
			.String(s => s
				.Name(o => o.Minimal)
			)
			.Text(s => s
				.Name(o => o.Inferred)
				.Fields(f => f
					.Keyword(k => k
						.Name("keyword")
					)
				)
			)
			.Keyword(s => s
				.Name(o => o.Char)
			)
			.Keyword(s => s
				.Name(o => o.Guid)
			);

		protected override object ExpectJsonFluentOnly => new
		{
			properties = new
			{
				full = new
				{
					type = "string",
					norms = true
				}
			}
		};
		protected override Func<PropertiesDescriptor<StringTest>, IPromise<IProperties>> FluentOnlyProperties => p => p
			.String(s => s
				.Name(o => o.Full)
				.Norms()
			);
	}
}
#pragma warning restore 618
