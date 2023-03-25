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

[Table("hr_expense_refuse_wizard")]
public partial class HrExpenseRefuseWizard
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("hr_expense_sheet_id")]
    public Guid? HrExpenseSheetId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("reason")]
    public string? Reason { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("HrExpenseRefuseWizardCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("HrExpenseSheetId")]
    [InverseProperty("HrExpenseRefuseWizards")]
    public virtual HrExpenseSheet? HrExpenseSheet { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("HrExpenseRefuseWizardWriteUs")]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("HrExpenseRefuseWizardId")]
    [InverseProperty("HrExpenseRefuseWizards")]
    public virtual ICollection<HrExpense> HrExpenses { get; } = new List<HrExpense>();
}
