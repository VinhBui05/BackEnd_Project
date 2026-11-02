using Microsoft.AspNetCore.Mvc;
using BackEnd_Project.Models;

namespace BackEnd_Project.Controllers
{
    public class ProductController : Controller
    {
        // ===== DỮ LIỆU TẠM THỜI (static List) =====
        private static List<Product> _products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Pizza Margherita",
                Price = 129000,
                Category = "Truyền thống",
                Description = "Phô mai mozzarella, cà chua, basil tươi"
            },
            new Product
            {
                Id = 2,
                Name = "Pizza Hải Sản",
                Price = 219000,
                Category = "Hải sản",
                Description = "Tôm, mực, nghêu, sốt cà chua"
            },
            new Product
            {
                Id = 3,
                Name = "Pizza Pepperoni",
                Price = 179000,
                Category = "Truyền thống",
                Description = "Pepperoni, phô mai, sốt cà chua"
            },
            new Product
            {
                Id = 4,
                Name = "Pizza Chay",
                Price = 149000,
                Category = "Chay",
                Description = "Nấm, ớt chuông, ô liu, phô mai"
            },
            new Product
            {
                Id = 5,
                Name = "Pizza Gà Nướng",
                Price = 189000,
                Category = "Đặc biệt",
                Description = "Gà nướng, phô mai, sốt BBQ"
            }
        };

        // ===== 1. INDEX: Hiển thị danh sách =====
        public IActionResult Index()
        {
            return View(_products);
        }

        // ===== 2. DETAILS: Xem chi tiết theo Id + Route tùy chỉnh =====
        [Route("san-pham/chi-tiet/{id:int}")]
        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // ===== 3. CREATE (GET): Hiển thị form thêm mới =====
        public IActionResult Create()
        {
            return View();
        }

        // ===== 4. CREATE (POST): Xử lý thêm mới =====
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product model)
        {
            if (!ModelState.IsValid)
            {
                // Trả lại form kèm thông báo lỗi
                return View(model);
            }

            // Gán Id tự động tăng: Max(Id) + 1
            model.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;

            // Thêm vào danh sách
            _products.Add(model);

            // Quay về trang danh sách
            return RedirectToAction("Index");
        }
    }
}