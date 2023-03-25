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

[Table("ir_cron")]
public partial class IrCron
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("ir_actions_server_id")]
    public Guid? IrActionsServerId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("interval_number")]
    public long? IntervalNumber { get; set; }

    [Column("numbercall")]
    public long? Numbercall { get; set; }

    [Column("priority")]
    public long? Priority { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("interval_type")]
    public string? IntervalType { get; set; }

    [Column("cron_name", TypeName = "jsonb")]
    public string? CronName { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("doall")]
    public bool? Doall { get; set; }

    [Column("nextcall", TypeName = "timestamp without time zone")]
    public DateTime? Nextcall { get; set; }

    [Column("lastcall", TypeName = "timestamp without time zone")]
    public DateTime? Lastcall { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("IrCronCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("IrActionsServerId")]
    [InverseProperty("IrCrons")]
    public virtual IrActServer? IrActionsServer { get; set; }

    [InverseProperty("Cron")]
    [NotMapped]
    public virtual ICollection<IrCronTrigger> IrCronTriggers { get; } = new List<IrCronTrigger>();

    [InverseProperty("Cron")]
    [NotMapped]
    public virtual ICollection<LunchAlert> LunchAlerts { get; } = new List<LunchAlert>();

    [InverseProperty("Cron")]
    [NotMapped]
    public virtual ICollection<LunchSupplier> LunchSuppliers { get; } = new List<LunchSupplier>();

    [ForeignKey("UserId")]
    [InverseProperty("IrCronUsers")]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("IrCronWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
