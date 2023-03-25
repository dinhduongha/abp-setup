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

[Table("pos_close_session_wizard")]
public partial class PosCloseSessionWizard
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("message")]
    public string? Message { get; set; }

    [Column("account_readonly")]
    public bool? AccountReadonly { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("amount_to_balance")]
    public double? AmountToBalance { get; set; }

    [ForeignKey("AccountId")]
    [InverseProperty("PosCloseSessionWizards")]
    public virtual AccountAccount? Account { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("PosCloseSessionWizardCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("PosCloseSessionWizardWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
