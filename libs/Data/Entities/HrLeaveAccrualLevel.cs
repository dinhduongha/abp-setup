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

[Table("hr_leave_accrual_level")]
public partial class HrLeaveAccrualLevel
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("sequence")]
    public Guid? Sequence { get; set; }

    [Column("accrual_plan_id")]
    public Guid? AccrualPlanId { get; set; }

    [Column("start_count")]
    public Guid? StartCount { get; set; }

    [Column("first_day")]
    public Guid? FirstDay { get; set; }

    [Column("second_day")]
    public Guid? SecondDay { get; set; }

    [Column("first_month_day")]
    public Guid? FirstMonthDay { get; set; }

    [Column("second_month_day")]
    public Guid? SecondMonthDay { get; set; }

    [Column("yearly_day")]
    public Guid? YearlyDay { get; set; }

    [Column("parent_id")]
    public long? ParentId { get; set; }

    [Column("postpone_max_days")]
    public Guid? PostponeMaxDays { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("start_type")]
    public string? StartType { get; set; }

    [Column("added_value_type")]
    public string? AddedValueType { get; set; }

    [Column("frequency")]
    public string? Frequency { get; set; }

    [Column("week_day")]
    public string? WeekDay { get; set; }

    [Column("first_month")]
    public string? FirstMonth { get; set; }

    [Column("second_month")]
    public string? SecondMonth { get; set; }

    [Column("yearly_month")]
    public string? YearlyMonth { get; set; }

    [Column("action_with_unused_accruals")]
    public string? ActionWithUnusedAccruals { get; set; }

    [Column("is_based_on_worked_time")]
    public bool? IsBasedOnWorkedTime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("added_value")]
    public double? AddedValue { get; set; }

    [Column("maximum_leave")]
    public double? MaximumLeave { get; set; }

    [ForeignKey("AccrualPlanId")]
    [InverseProperty("HrLeaveAccrualLevels")]
    public virtual HrLeaveAccrualPlan? AccrualPlan { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("HrLeaveAccrualLevelCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<HrLeaveAccrualLevel> InverseParent { get; } = new List<HrLeaveAccrualLevel>();

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual HrLeaveAccrualLevel? Parent { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("HrLeaveAccrualLevelWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
