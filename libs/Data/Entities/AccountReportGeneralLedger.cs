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

[Table("account_report_general_ledger")]
public partial class AccountReportGeneralLedger: IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("target_move")]
    public string? TargetMove { get; set; }

    [Column("display_account")]
    public string? DisplayAccount { get; set; }

    [Column("sortby")]
    public string? Sortby { get; set; }

    [Column("date_from")]
    public DateOnly? DateFrom { get; set; }

    [Column("date_to")]
    public DateOnly? DateTo { get; set; }

    [Column("initial_balance")]
    public bool? InitialBalance { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("AccountReportGeneralLedgers")]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("AccountReportGeneralLedgerCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("AccountReportGeneralLedgerWriteUs")]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("AccountReportGeneralLedgerId")]
    [InverseProperty("AccountReportGeneralLedgers")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccounts { get; } = new List<AccountAccount>();

    [ForeignKey("AccountReportGeneralLedgerId")]
    [InverseProperty("AccountReportGeneralLedgers")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccounts { get; } = new List<AccountAnalyticAccount>();

    [ForeignKey("AccountId")]
    [InverseProperty("AccountsNavigation")]
    [NotMapped]
    public virtual ICollection<AccountJournal> Journals { get; } = new List<AccountJournal>();

    [ForeignKey("AccountReportGeneralLedgerId")]
    [InverseProperty("AccountReportGeneralLedgers")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; } = new List<ResPartner>();
}
