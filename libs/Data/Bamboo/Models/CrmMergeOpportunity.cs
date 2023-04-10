﻿using System;
using System.Collections.Generic;

namespace Bamboo.Core.Entities;

public partial class CrmMergeOpportunity
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? TeamId { get; set; }

    public Guid? CreatorId { get; set; }

    public Guid? LastModifierId { get; set; }

    public DateTime? CreationTime { get; set; }

    public DateTime? LastModificationTime { get; set; }

    public virtual ResUser? CreateU { get; set; }

    public virtual CrmTeam? Team { get; set; }

    public virtual ResUser? User { get; set; }

    public virtual ResUser? WriteU { get; set; }

    //public virtual ICollection<CrmLead> Opportunities { get; } = new List<CrmLead>();
}
