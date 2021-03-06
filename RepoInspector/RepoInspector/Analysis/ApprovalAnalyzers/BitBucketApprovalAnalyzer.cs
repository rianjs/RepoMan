﻿using System;
using System.Collections.Generic;

namespace RepoInspector.Analysis.ApprovalAnalyzers
{
    public class BitBucketApprovalAnalyzer
        : TextMatchingApprovalAnalyzer
    {
        public BitBucketApprovalAnalyzer(
            IEnumerable<string> approvalStateOptions,
            IEnumerable<string> noApprovalStateOptions,
            IEnumerable<string> approvalTextFragments)
            : base(approvalStateOptions, noApprovalStateOptions, approvalTextFragments, StringComparison.OrdinalIgnoreCase)
        {
        }
    }
}
