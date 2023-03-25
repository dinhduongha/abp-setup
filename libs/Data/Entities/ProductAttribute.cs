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

[Table("product_attribute")]
[Index("Sequence", Name = "product_attribute_sequence_index")]
public partial class ProductAttribute
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("sequence", TypeName = "bigserial")]
    public long Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_variant")]
    public string? CreateVariant { get; set; }

    [Column("display_type")]
    public string? DisplayType { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("visibility")]
    public string? Visibility { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("ProductAttributeCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [InverseProperty("Attribute")]
    [NotMapped]
    public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; } = new List<ProductAttributeValue>();

    [InverseProperty("Attribute")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeLine> ProductTemplateAttributeLines { get; } = new List<ProductTemplateAttributeLine>();

    [InverseProperty("Attribute")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValues { get; } = new List<ProductTemplateAttributeValue>();

    [ForeignKey("LastModifierId")]
    [InverseProperty("ProductAttributeWriteUs")]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("ProductAttributeId")]
    [InverseProperty("ProductAttributes")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; } = new List<ProductTemplate>();
}
