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

[Table("base_import_tests_models_o2m")]
public partial class BaseImportTestsModelsO2m
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

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsO2mChild> BaseImportTestsModelsO2mChildren { get; } = new List<BaseImportTestsModelsO2mChild>();

    [ForeignKey("CreatorId")]
    [InverseProperty("BaseImportTestsModelsO2mCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("BaseImportTestsModelsO2mWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
