﻿using Benchmarking.Codewars;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarking.Benchmarks
{
    //[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, ExpectedResult = "(123) 456-7890")]
    //[TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, ExpectedResult = "(111) 111-1111")]

    [SimpleJob(RuntimeMoniker.Net60)]
    public class CreatePhoneNumberBenchmark
    {
        [Params(
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 },
            new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        )]
        public int[] input;

        [Benchmark(Baseline = true)]
        public string CreatePhoneNumber_StringFormat_SelectTostringArray() =>
            CreatePhoneNumber.CreatePhoneNumber_StringFormat_SelectToStringArray(input);

        #region KataSolutions

        [Benchmark]
        public string CreatePhoneNumber_Parse_Concat_ToString() =>
            CreatePhoneNumber.CreatePhoneNumber_LongParse_Concat_ToString(input);

        [Benchmark]
        public string CreatePhoneNumber_RegexReplace_Grouping() =>
            CreatePhoneNumber.CreatePhoneNumber_RegexReplace_Grouping(input);

        [Benchmark]
        public string CreatePhoneNumber_StringFormat_SkipTake() =>
            CreatePhoneNumber.CreatePhoneNumber_StringFormat_SkipTake(input);

        [Benchmark]
        public string CreatePhoneNumber_StringFormat_ParseULong_StringJoin() =>
            CreatePhoneNumber.CreatePhoneNumber_StringFormat_ParseULong_StringJoin(input);

        #endregion
    }
}
