﻿using System;
using System.Collections.Generic;

namespace Bamboo.Core.Entities;

public partial class ResourceCalendar
{
    public Guid Id { get; set; }

    public Guid? TenantId { get; set; }

    public Guid? CreatorId { get; set; }

    public Guid? LastModifierId { get; set; }

    public string? Name { get; set; }

    public string? Tz { get; set; }

    public bool? Active { get; set; }

    public bool? TwoWeeksCalendar { get; set; }

    public DateTime? CreationTime { get; set; }

    public DateTime? LastModificationTime { get; set; }

    public double? HoursPerDay { get; set; }

    public virtual ResCompany? Company { get; set; }

    public virtual ResUser? CreateU { get; set; }

    //public virtual ICollection<HrContract> HrContracts { get; } = new List<HrContract>();

    //public virtual ICollection<HrEmployee> HrEmployees { get; } = new List<HrEmployee>();

    //public virtual ICollection<HrLeaveStressDay> HrLeaveStressDays { get; } = new List<HrLeaveStressDay>();

    //public virtual ICollection<HrPayrollStructureType> HrPayrollStructureTypes { get; } = new List<HrPayrollStructureType>();

    //public virtual ICollection<MrpWorkcenter> MrpWorkcenters { get; } = new List<MrpWorkcenter>();

    //public virtual ICollection<ResCompany> ResCompanies { get; } = new List<ResCompany>();

    //public virtual ICollection<ResourceCalendarAttendance> ResourceCalendarAttendances { get; } = new List<ResourceCalendarAttendance>();

    //public virtual ICollection<ResourceCalendarLeaf> ResourceCalendarLeaves { get; } = new List<ResourceCalendarLeaf>();

    //public virtual ICollection<ResourceResource> ResourceResources { get; } = new List<ResourceResource>();

    public virtual ResUser? WriteU { get; set; }
}
