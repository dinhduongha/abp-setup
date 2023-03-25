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

[Table("hr_recruitment_source")]
public partial class HrRecruitmentSource
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("source_id")]
    public Guid? SourceId { get; set; }

    [Column("job_id")]
    public Guid? JobId { get; set; }

    [Column("alias_id")]
    public Guid? AliasId { get; set; }

    [Column("medium_id")]
    public Guid? MediumId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AliasId")]
    [InverseProperty("HrRecruitmentSources")]
    public virtual MailAlias? Alias { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("HrRecruitmentSourceCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("JobId")]
    [InverseProperty("HrRecruitmentSources")]
    public virtual HrJob? Job { get; set; }

    [ForeignKey("MediumId")]
    [InverseProperty("HrRecruitmentSources")]
    public virtual UtmMedium? Medium { get; set; }

    [ForeignKey("SourceId")]
    [InverseProperty("HrRecruitmentSources")]
    public virtual UtmSource? Source { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("HrRecruitmentSourceWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
