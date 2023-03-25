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

[Table("hr_department")]
[Index("TenantId", Name = "hr_department_company_id_index")]
[Index("ParentId", Name = "hr_department_parent_id_index")]
[Index("ParentPath", Name = "hr_department_parent_path_index")]
public partial class HrDepartment: IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("manager_id")]
    public Guid? ManagerId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("master_department_id")]
    public Guid? MasterDepartmentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("complete_name")]
    public string? CompleteName { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("HrDepartments")]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("HrDepartmentCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<HrApplicant> HrApplicants { get; } = new List<HrApplicant>();

    [InverseProperty("Department")]
    public virtual ICollection<HrContract> HrContracts { get; } = new List<HrContract>();

    [InverseProperty("Department")]
    public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLogs { get; } = new List<HrEmployeeSkillLog>();

    [InverseProperty("Department")]
    public virtual ICollection<HrEmployee> HrEmployees { get; } = new List<HrEmployee>();

    [InverseProperty("Department")]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheets { get; } = new List<HrExpenseSheet>();

    [InverseProperty("Department")]
    public virtual ICollection<HrJob> HrJobs { get; } = new List<HrJob>();

    [InverseProperty("Department")]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocations { get; } = new List<HrLeaveAllocation>();

    [InverseProperty("Department")]
    public virtual ICollection<HrLeave> HrLeaves { get; } = new List<HrLeave>();

    [InverseProperty("Department")]
    public virtual ICollection<HrPlan> HrPlans { get; } = new List<HrPlan>();

    [InverseProperty("MasterDepartment")]
    public virtual ICollection<HrDepartment> InverseMasterDepartment { get; } = new List<HrDepartment>();

    [InverseProperty("Parent")]
    public virtual ICollection<HrDepartment> InverseParent { get; } = new List<HrDepartment>();

    [InverseProperty("Department")]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipments { get; } = new List<MaintenanceEquipment>();

    [ForeignKey("ManagerId")]
    [InverseProperty("HrDepartments")]
    public virtual HrEmployee? Manager { get; set; }

    [ForeignKey("MasterDepartmentId")]
    [InverseProperty("InverseMasterDepartment")]
    public virtual HrDepartment? MasterDepartment { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    [InverseProperty("HrDepartments")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual HrDepartment? Parent { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("HrDepartmentWriteUs")]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("HrDepartmentId")]
    [InverseProperty("HrDepartments")]
    public virtual ICollection<HrLeaveStressDay> HrLeaveStressDays { get; } = new List<HrLeaveStressDay>();

    [ForeignKey("HrDepartmentId")]
    [InverseProperty("HrDepartments")]
    public virtual ICollection<MailChannel> MailChannels { get; } = new List<MailChannel>();
}
