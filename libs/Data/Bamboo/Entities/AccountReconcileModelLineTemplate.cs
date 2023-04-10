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

[Table("account_reconcile_model_line_template")]
public partial class AccountReconcileModelLineTemplate
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("label")]
    public string? Label { get; set; }

    [Column("amount_type")]
    public string? AmountType { get; set; }

    [Column("amount_string")]
    public string? AmountString { get; set; }

    [Column("force_tax_included")]
    public bool? ForceTaxIncluded { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AccountId")]
    //[InverseProperty("AccountReconcileModelLineTemplates")]
    public virtual AccountAccountTemplate? Account { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountReconcileModelLineTemplateCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ModelId")]
    //[InverseProperty("AccountReconcileModelLineTemplates")]
    public virtual AccountReconcileModelTemplate? Model { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountReconcileModelLineTemplateWriteUs")]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("AccountReconcileModelLineTemplateId")]
    [InverseProperty("AccountReconcileModelLineTemplates")]
    [NotMapped]
    public virtual ICollection<AccountTaxTemplate> AccountTaxTemplates { get; } = new List<AccountTaxTemplate>();
}
