﻿using System;
using System.Collections.Generic;

namespace Bamboo.Core.Entities;

public partial class ResPartnerIndustry
{
    public long Id { get; set; }

    public Guid? CreatorId { get; set; }

    public Guid? LastModifierId { get; set; }

    public string? Name { get; set; }

    public string? FullName { get; set; }

    public bool? Active { get; set; }

    public DateTime? CreationTime { get; set; }

    public DateTime? LastModificationTime { get; set; }

    public virtual ResUser? CreateU { get; set; }

    //public virtual ICollection<ResPartner> ResPartners { get; } = new List<ResPartner>();

    public virtual ResUser? WriteU { get; set; }
}
