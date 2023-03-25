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

[Table("ir_exports")]
[Index("Resource", Name = "ir_exports_resource_index")]
public partial class IrExport
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("resource")]
    public string? Resource { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("IrExportCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [InverseProperty("Export")]
    public virtual ICollection<IrExportsLine> IrExportsLines { get; } = new List<IrExportsLine>();

    [ForeignKey("LastModifierId")]
    [InverseProperty("IrExportWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
