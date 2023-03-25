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

[Table("product_packaging")]
[Index("Barcode", Name = "product_packaging_barcode_uniq", IsUnique = true)]
[Index("TenantId", Name = "product_packaging_company_id_index")]
public partial class ProductPackaging: IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("qty")]
    public decimal? Qty { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("sales")]
    public bool? Sales { get; set; }

    [Column("package_type_id")]
    public long? PackageTypeId { get; set; }

    [Column("purchase")]
    public bool? Purchase { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("ProductPackagings")]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("ProductPackagingCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PackageTypeId")]
    [InverseProperty("ProductPackagings")]
    public virtual StockPackageType? PackageType { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductPackagings")]
    public virtual ProductProduct? Product { get; set; }

    [InverseProperty("ProductPackaging")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; } = new List<PurchaseOrderLine>();

    [InverseProperty("ProductPackaging")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; } = new List<SaleOrderLine>();

    [InverseProperty("ProductPackaging")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; } = new List<StockMove>();

    [ForeignKey("LastModifierId")]
    [InverseProperty("ProductPackagingWriteUs")]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("PackagingId")]
    [InverseProperty("Packagings")]
    [NotMapped]
    public virtual ICollection<StockRoute> Routes { get; } = new List<StockRoute>();
}
