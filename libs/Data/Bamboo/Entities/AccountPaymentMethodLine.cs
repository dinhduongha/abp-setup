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

[Table("account_payment_method_line")]
public partial class AccountPaymentMethodLine
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("payment_method_id")]
    public Guid? PaymentMethodId { get; set; }

    [Column("payment_account_id")]
    public Guid? PaymentAccountId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

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

    [Column("payment_provider_id")]
    public Guid? PaymentProviderId { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountPaymentMethodLineCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("JournalId")]
    //[InverseProperty("AccountPaymentMethodLines")]
    public virtual AccountJournal? Journal { get; set; }

    [ForeignKey("PaymentAccountId")]
    //[InverseProperty("AccountPaymentMethodLines")]
    public virtual AccountAccount? PaymentAccount { get; set; }

    [ForeignKey("PaymentMethodId")]
    //[InverseProperty("AccountPaymentMethodLines")]
    public virtual AccountPaymentMethod? PaymentMethod { get; set; }

    [ForeignKey("PaymentProviderId")]
    //[InverseProperty("AccountPaymentMethodLines")]
    public virtual PaymentProvider? PaymentProvider { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountPaymentMethodLineWriteUs")]
    public virtual ResUser? WriteU { get; set; }

    [InverseProperty("PaymentMethodLine")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisters { get; } = new List<AccountPaymentRegister>();

    [InverseProperty("PaymentMethodLine")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPayments { get; } = new List<AccountPayment>();

}
