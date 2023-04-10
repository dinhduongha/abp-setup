﻿using System;
using System.Collections.Generic;

namespace Bamboo.Core.Entities;

public partial class MaintenanceTeam
{
    public Guid Id { get; set; }

    public Guid? TenantId { get; set; }

    public long? Color { get; set; }

    public Guid? CreatorId { get; set; }

    public Guid? LastModifierId { get; set; }

    public string? Name { get; set; }

    public bool? Active { get; set; }

    public DateTime? CreationTime { get; set; }

    public DateTime? LastModificationTime { get; set; }

    public virtual ResCompany? Company { get; set; }

    public virtual ResUser? CreateU { get; set; }

    //public virtual ICollection<MaintenanceEquipment> MaintenanceEquipments { get; } = new List<MaintenanceEquipment>();

    //public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; } = new List<MaintenanceRequest>();

    public virtual ResUser? WriteU { get; set; }

    //public virtual ICollection<ResUser> ResUsers { get; } = new List<ResUser>();
}
