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

[Table("base_import_tests_models_m2o_required_related")]
public partial class BaseImportTestsModelsM2oRequiredRelated
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

    [ForeignKey("CreatorId")]
    //[InverseProperty("BaseImportTestsModelsM2oRequiredRelatedCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("BaseImportTestsModelsM2oRequiredRelatedWriteUs")]
    public virtual ResUser? WriteU { get; set; }

    [InverseProperty("ValueNavigation")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2oRequired> BaseImportTestsModelsM2oRequireds { get; } = new List<BaseImportTestsModelsM2oRequired>();

}
