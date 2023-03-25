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

[Table("website_menu")]
[Index("ParentId", Name = "website_menu_parent_id_index")]
[Index("ParentPath", Name = "website_menu_parent_path_index")]
public partial class WebsiteMenu
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("page_id")]
    public Guid? PageId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("theme_template_id")]
    public long? ThemeTemplateId { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [Column("mega_menu_classes")]
    public string? MegaMenuClasses { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("mega_menu_content", TypeName = "jsonb")]
    public string? MegaMenuContent { get; set; }

    [Column("new_window")]
    public bool? NewWindow { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("WebsiteMenuCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<WebsiteMenu> InverseParent { get; } = new List<WebsiteMenu>();

    [ForeignKey("PageId")]
    [InverseProperty("WebsiteMenus")]
    public virtual WebsitePage? Page { get; set; }

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual WebsiteMenu? Parent { get; set; }

    [ForeignKey("ThemeTemplateId")]
    [InverseProperty("WebsiteMenus")]
    public virtual ThemeWebsiteMenu? ThemeTemplate { get; set; }

    [ForeignKey("WebsiteId")]
    [InverseProperty("WebsiteMenus")]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("WebsiteMenuWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
