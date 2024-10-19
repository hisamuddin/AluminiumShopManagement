using AluminumShopManagement.APIs.Common;
using AluminumShopManagement.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace AluminumShopManagement.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class PurchaseOrderFindManyArgs : FindManyInput<PurchaseOrder, PurchaseOrderWhereInput> { }
