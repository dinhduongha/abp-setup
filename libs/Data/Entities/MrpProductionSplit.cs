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

[Table("mrp_production_split")]
public partial class MrpProductionSplit
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("production_split_multi_id")]
    public Guid? ProductionSplitMultiId { get; set; }

    [Column("production_id")]
    public Guid? ProductionId { get; set; }

    [Column("counter")]
    public long? Counter { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("MrpProductionSplitCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [InverseProperty("MrpProductionSplit")]
    public virtual ICollection<MrpProductionSplitLine> MrpProductionSplitLines { get; } = new List<MrpProductionSplitLine>();

    [ForeignKey("ProductionId")]
    [InverseProperty("MrpProductionSplits")]
    public virtual MrpProduction? Production { get; set; }

    [ForeignKey("ProductionSplitMultiId")]
    [InverseProperty("MrpProductionSplits")]
    public virtual MrpProductionSplitMulti? ProductionSplitMulti { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("MrpProductionSplitWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
