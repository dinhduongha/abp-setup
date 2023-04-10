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

[Table("crm_lead_lost")]
public partial class CrmLeadLost
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("lost_reason_id")]
    public long? LostReasonId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("lost_feedback")]
    public string? LostFeedback { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("CrmLeadLostCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LostReasonId")]
    //[InverseProperty("CrmLeadLosts")]
    public virtual CrmLostReason? LostReason { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CrmLeadLostWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
