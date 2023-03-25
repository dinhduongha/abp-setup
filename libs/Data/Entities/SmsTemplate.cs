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

[Table("sms_template")]
[Index("Model", Name = "sms_template_model_index")]
public partial class SmsTemplate
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("sidebar_action_id")]
    public Guid? SidebarActionId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("template_fs")]
    public string? TemplateFs { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("body", TypeName = "jsonb")]
    public string? Body { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [InverseProperty("SmsTemplate")]
    public virtual ICollection<CalendarAlarm> CalendarAlarms { get; } = new List<CalendarAlarm>();

    [ForeignKey("CreatorId")]
    [InverseProperty("SmsTemplateCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [InverseProperty("SmsTemplate")]
    public virtual ICollection<IrActServer> IrActServers { get; } = new List<IrActServer>();

    [ForeignKey("ModelId")]
    [InverseProperty("SmsTemplates")]
    public virtual IrModel? ModelNavigation { get; set; }

    [InverseProperty("SmsTemplate")]
    public virtual ICollection<ProjectProjectStage> ProjectProjectStages { get; } = new List<ProjectProjectStage>();

    [InverseProperty("SmsTemplate")]
    public virtual ICollection<ProjectTaskType> ProjectTaskTypes { get; } = new List<ProjectTaskType>();

    [InverseProperty("StockSmsConfirmationTemplate")]
    public virtual ICollection<ResCompany> ResCompanies { get; } = new List<ResCompany>();

    [ForeignKey("SidebarActionId")]
    [InverseProperty("SmsTemplates")]
    public virtual IrActWindow? SidebarAction { get; set; }

    [InverseProperty("Template")]
    public virtual ICollection<SmsComposer> SmsComposers { get; } = new List<SmsComposer>();

    [InverseProperty("SmsTemplate")]
    public virtual ICollection<SmsTemplatePreview> SmsTemplatePreviews { get; } = new List<SmsTemplatePreview>();

    [ForeignKey("LastModifierId")]
    [InverseProperty("SmsTemplateWriteUs")]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("SmsTemplateId")]
    [InverseProperty("SmsTemplates")]
    public virtual ICollection<SmsTemplateReset> SmsTemplateResets { get; } = new List<SmsTemplateReset>();
}
