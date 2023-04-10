﻿using System;
using System.Collections.Generic;

namespace Bamboo.Core.Entities;

public partial class AccountReportLine
{
    public Guid Id { get; set; }

    public Guid? ReportId { get; set; }

    public long? HierarchyLevel { get; set; }

    public Guid? ParentId { get; set; }

    public long? Sequence { get; set; }

    public Guid? ActionId { get; set; }

    public Guid? CreatorId { get; set; }

    public Guid? LastModifierId { get; set; }

    public string? Groupby { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public bool? Foldable { get; set; }

    public bool? PrintOnNewPage { get; set; }

    public bool? HideIfZero { get; set; }

    public DateTime? CreationTime { get; set; }

    public DateTime? LastModificationTime { get; set; }

    //public virtual ICollection<AccountReportExpression> AccountReportExpressions { get; } = new List<AccountReportExpression>();

    //public virtual ICollection<AccountReportExternalValue> AccountReportExternalValues { get; } = new List<AccountReportExternalValue>();

    public virtual ResUser? CreateU { get; set; }

    //public virtual ICollection<AccountReportLine> InverseParent { get; } = new List<AccountReportLine>();

    public virtual AccountReportLine? Parent { get; set; }

    public virtual AccountReport? Report { get; set; }

    public virtual ResUser? WriteU { get; set; }
}
