using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Eticaret.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class ReportsController : Controller
    {
        private readonly DatabaseContext _context;

        public ReportsController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
        {
            // 1. KPI Metrics with Date Filters
            var revenueQuery = _context.Orders
                .Where(o => o.OrderState == Eticaret.Core.Entities.EnumOrderState.Completed || o.OrderState == Eticaret.Core.Entities.EnumOrderState.Approved);
            if (startDate.HasValue) revenueQuery = revenueQuery.Where(o => o.OrderDate >= startDate.Value);
            if (endDate.HasValue) revenueQuery = revenueQuery.Where(o => o.OrderDate <= endDate.Value);
            var totalRevenue = await revenueQuery.SumAsync(o => o.TotalPrice);

            var ordersQuery = _context.Orders.AsQueryable();
            if (startDate.HasValue) ordersQuery = ordersQuery.Where(o => o.OrderDate >= startDate.Value);
            if (endDate.HasValue) ordersQuery = ordersQuery.Where(o => o.OrderDate <= endDate.Value);
            var totalOrdersCount = await ordersQuery.CountAsync();

            var totalProductsCount = await _context.Products.CountAsync();

            var usersQuery = _context.AppUsers.AsQueryable();
            if (startDate.HasValue) usersQuery = usersQuery.Where(u => u.CreateDate >= startDate.Value);
            if (endDate.HasValue) usersQuery = usersQuery.Where(u => u.CreateDate <= endDate.Value);
            var totalUsersCount = await usersQuery.CountAsync();

            var averageOrderValue = totalOrdersCount > 0 ? totalRevenue / totalOrdersCount : 0;

            // 2. Sales by Category with Date Filters
            var categorySalesQuery = _context.Products
                .Include(p => p.Category)
                .Join(_context.Set<Eticaret.Core.Entities.OrderLine>(), 
                    p => p.Id, 
                    ol => ol.ProductId, 
                    (p, ol) => new { p, ol });
            
            var ordersFilterQuery = _context.Orders.Where(o => o.OrderState != Eticaret.Core.Entities.EnumOrderState.Cancelled);
            if (startDate.HasValue) ordersFilterQuery = ordersFilterQuery.Where(o => o.OrderDate >= startDate.Value);
            if (endDate.HasValue) ordersFilterQuery = ordersFilterQuery.Where(o => o.OrderDate <= endDate.Value);
            
            var categorySales = await categorySalesQuery
                .Join(ordersFilterQuery,
                    pol => pol.ol.OrderId,
                    o => o.Id,
                    (pol, o) => new { pol.p.Category.Name, Revenue = pol.ol.Quantity * pol.ol.UnitPrice })
                .GroupBy(x => x.Name)
                .Select(g => new
                {
                    CategoryName = g.Key ?? "Kategorisiz",
                    TotalSales = g.Sum(x => x.Revenue)
                })
                .ToListAsync();

            // 3. Top 5 Best Selling Products with Date Filters
            var orderLineQuery = _context.Set<Eticaret.Core.Entities.OrderLine>().Include(ol => ol.Product).AsQueryable();
            var topOrdersFilterQuery = _context.Orders.Where(o => o.OrderState != Eticaret.Core.Entities.EnumOrderState.Cancelled);
            if (startDate.HasValue) topOrdersFilterQuery = topOrdersFilterQuery.Where(o => o.OrderDate >= startDate.Value);
            if (endDate.HasValue) topOrdersFilterQuery = topOrdersFilterQuery.Where(o => o.OrderDate <= endDate.Value);
            
            var topProducts = await orderLineQuery
                .Join(topOrdersFilterQuery,
                    ol => ol.OrderId,
                    o => o.Id,
                    (ol, o) => ol)
                .GroupBy(ol => ol.ProductId)
                .Select(g => new
                {
                    ProductName = g.FirstOrDefault().Product.Name ?? "Bilinmeyen Ürün",
                    ProductCode = g.FirstOrDefault().Product.ProductCode,
                    QuantitySold = g.Sum(x => x.Quantity),
                    TotalRevenue = g.Sum(x => x.Quantity * x.UnitPrice)
                })
                .OrderByDescending(x => x.QuantitySold)
                .Take(5)
                .ToListAsync();

            // 4. Monthly Sales with Date Filters
            var monthlySalesQuery = _context.Orders.Where(o => o.OrderState != Eticaret.Core.Entities.EnumOrderState.Cancelled);
            if (startDate.HasValue) monthlySalesQuery = monthlySalesQuery.Where(o => o.OrderDate >= startDate.Value);
            if (endDate.HasValue) monthlySalesQuery = monthlySalesQuery.Where(o => o.OrderDate <= endDate.Value);
            
            var monthlySales = await monthlySalesQuery
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalSales = g.Sum(x => x.TotalPrice)
                })
                .OrderBy(x => x.Year).ThenBy(x => x.Month)
                .ToListAsync();

            // Set ViewData for view consumption
            ViewBag.TotalRevenue = totalRevenue;
            ViewBag.TotalOrders = totalOrdersCount;
            ViewBag.TotalProducts = totalProductsCount;
            ViewBag.TotalUsers = totalUsersCount;
            ViewBag.AverageOrderValue = averageOrderValue;
            ViewBag.CategorySales = categorySales;
            ViewBag.TopProducts = topProducts;
            ViewBag.MonthlySales = monthlySales;
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");

            return View();
        }
    }
}
