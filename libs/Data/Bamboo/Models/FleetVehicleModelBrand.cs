﻿using System;
using System.Collections.Generic;

namespace Bamboo.Core.Entities;

public partial class FleetVehicleModelBrand
{
    public long Id { get; set; }

    public long? ModelCount { get; set; }

    public Guid? CreatorId { get; set; }

    public Guid? LastModifierId { get; set; }

    public string? Name { get; set; }

    public DateTime? CreationTime { get; set; }

    public DateTime? LastModificationTime { get; set; }

    public virtual ResUser? CreateU { get; set; }

    //public virtual ICollection<FleetVehicleModel> FleetVehicleModels { get; } = new List<FleetVehicleModel>();

    //public virtual ICollection<FleetVehicle> FleetVehicles { get; } = new List<FleetVehicle>();

    public virtual ResUser? WriteU { get; set; }
}
