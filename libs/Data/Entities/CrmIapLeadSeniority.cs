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

[Table("crm_iap_lead_seniority")]
[Index("Name", Name = "crm_iap_lead_seniority_name_uniq", IsUnique = true)]
public partial class CrmIapLeadSeniority
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("reveal_id")]
    public string? RevealId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("CrmIapLeadSeniorityCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [InverseProperty("Seniority")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequests { get; } = new List<CrmIapLeadMiningRequest>();

    [ForeignKey("LastModifierId")]
    [InverseProperty("CrmIapLeadSeniorityWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
