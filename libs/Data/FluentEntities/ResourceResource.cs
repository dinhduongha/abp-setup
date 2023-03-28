﻿using System;
using System.Collections.Generic;

namespace Bamboo.Core.Entities;

public partial class ResourceResource
{
    public Guid Id { get; set; }

    public Guid? TenantId { get; set; }

    public Guid? UserId { get; set; }

    public Guid? CalendarId { get; set; }

    public Guid? CreatorId { get; set; }

    public Guid? LastModifierId { get; set; }

    public string? Name { get; set; }

    public string? ResourceType { get; set; }

    public string? Tz { get; set; }

    public bool? Active { get; set; }

    public DateTime? CreationTime { get; set; }

    public DateTime? LastModificationTime { get; set; }

    public double? TimeEfficiency { get; set; }

    public virtual ResourceCalendar? Calendar { get; set; }

    public virtual ResCompany? Company { get; set; }

    public virtual ResUser? CreateU { get; set; }

    //public virtual ICollection<HrEmployee> HrEmployees { get; } = new List<HrEmployee>();

    //public virtual ICollection<MrpWorkcenter> MrpWorkcenters { get; } = new List<MrpWorkcenter>();

    //public virtual ICollection<ResourceCalendarAttendance> ResourceCalendarAttendances { get; } = new List<ResourceCalendarAttendance>();

    //public virtual ICollection<ResourceCalendarLeaf> ResourceCalendarLeaves { get; } = new List<ResourceCalendarLeaf>();

    public virtual ResUser? User { get; set; }

    public virtual ResUser? WriteU { get; set; }
}
