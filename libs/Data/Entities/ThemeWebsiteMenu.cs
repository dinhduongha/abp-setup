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

[Table("theme_website_menu")]
[Index("ParentId", Name = "theme_website_menu_parent_id_index")]
public partial class ThemeWebsiteMenu
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("page_id")]
    public long? PageId { get; set; }

    [Column("sequence", TypeName = "bigserial")]
    public long Sequence { get; set; }

    [Column("parent_id")]
    public long? ParentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("mega_menu_classes")]
    public string? MegaMenuClasses { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("mega_menu_content")]
    public string? MegaMenuContent { get; set; }

    [Column("new_window")]
    public bool? NewWindow { get; set; }

    [Column("use_main_menu_as_parent")]
    public bool? UseMainMenuAsParent { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("ThemeWebsiteMenuCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<ThemeWebsiteMenu> InverseParent { get; } = new List<ThemeWebsiteMenu>();

    [ForeignKey("PageId")]
    [InverseProperty("ThemeWebsiteMenus")]
    public virtual ThemeWebsitePage? Page { get; set; }

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual ThemeWebsiteMenu? Parent { get; set; }

    [InverseProperty("ThemeTemplate")]
    [NotMapped]
    public virtual ICollection<WebsiteMenu> WebsiteMenus { get; } = new List<WebsiteMenu>();

    [ForeignKey("LastModifierId")]
    [InverseProperty("ThemeWebsiteMenuWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
