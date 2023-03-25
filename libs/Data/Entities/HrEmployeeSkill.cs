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

[Table("hr_employee_skill")]
[Index("EmployeeId", "SkillId", Name = "hr_employee_skill__unique_skill", IsUnique = true)]
public partial class HrEmployeeSkill
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("skill_id")]
    public Guid? SkillId { get; set; }

    [Column("skill_level_id")]
    public long? SkillLevelId { get; set; }

    [Column("skill_type_id")]
    public long? SkillTypeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("HrEmployeeSkillCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("HrEmployeeSkills")]
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("SkillId")]
    [InverseProperty("HrEmployeeSkills")]
    public virtual HrSkill? Skill { get; set; }

    [ForeignKey("SkillLevelId")]
    [InverseProperty("HrEmployeeSkills")]
    public virtual HrSkillLevel? SkillLevel { get; set; }

    [ForeignKey("SkillTypeId")]
    [InverseProperty("HrEmployeeSkills")]
    public virtual HrSkillType? SkillType { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("HrEmployeeSkillWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
