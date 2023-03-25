﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Entities;

[Table("account_analytic_applicability")]
public partial class AccountAnalyticApplicability
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("analytic_plan_id")]
    public Guid? AnalyticPlanId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("business_domain")]
    public string? BusinessDomain { get; set; }

    [Column("applicability")]
    public string? Applicability { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("product_categ_id")]
    public long? ProductCategId { get; set; }

    [Column("account_prefix")]
    public string? AccountPrefix { get; set; }

    [ForeignKey("AnalyticPlanId")]
    [InverseProperty("AccountAnalyticApplicabilities")]
    public virtual AccountAnalyticPlan? AnalyticPlan { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("AccountAnalyticApplicabilityCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductCategId")]
    [InverseProperty("AccountAnalyticApplicabilities")]
    public virtual ProductCategory? ProductCateg { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("AccountAnalyticApplicabilityWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
