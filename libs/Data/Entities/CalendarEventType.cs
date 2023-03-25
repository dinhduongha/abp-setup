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

[Table("calendar_event_type")]
[Index("Name", Name = "calendar_event_type_name_uniq", IsUnique = true)]
public partial class CalendarEventType
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("color")]
    public long? Color { get; set; }

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

    [ForeignKey("CreatorId")]
    [InverseProperty("CalendarEventTypeCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("CalendarEventTypeWriteUs")]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("TypeId")]
    [InverseProperty("Types")]
    public virtual ICollection<CalendarEvent> Events { get; } = new List<CalendarEvent>();
}
