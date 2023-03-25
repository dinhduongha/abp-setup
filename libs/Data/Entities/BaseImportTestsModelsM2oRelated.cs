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

[Table("base_import_tests_models_m2o_related")]
public partial class BaseImportTestsModelsM2oRelated
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("value")]
    public Guid? Value { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [InverseProperty("ValueNavigation")]
    public virtual ICollection<BaseImportTestsModelsM2o> BaseImportTestsModelsM2os { get; } = new List<BaseImportTestsModelsM2o>();

    [ForeignKey("CreatorId")]
    [InverseProperty("BaseImportTestsModelsM2oRelatedCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("BaseImportTestsModelsM2oRelatedWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
