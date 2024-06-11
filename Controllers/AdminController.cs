using AGB_Bank.Data;
using AGB_Bank.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AGB_Bank.Models.product;


namespace AGB_Bank.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult UnconfirmedUsers()
        {
            var users = _userManager.Users.Where(u => !u.IsConfirmed).ToList();
            return View(users);
        }

        [HttpPost]
        //public async void ConfirmUser(string userId)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user != null)
        //    {
        //        user.IsConfirmed = true;
        //        await _userManager.UpdateAsync(user);
        //        TempData["ShowSuccessPopup"] = true;
        //    }

        //}
        public async Task<IActionResult> ConfirmUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.IsConfirmed = true;
                await _userManager.UpdateAsync(user);
                TempData["ShowSuccessPopup"] = true;
            }
            return RedirectToAction("UnconfirmedUsers");
        }


        // les produits



        // pack
        // afficher toutes les produits
        public IActionResult Pack()
        {
            var products = _context.packProduct.ToList();
            return View(products);
        }
        //// afficher le détails
        //[HttpGet]
        //public async Task<IActionResult> View(int id)
        //{
        //    var product = await  _context.packProduct.FirstOrDefaultAsync(p => p.Id == id);

        //    if (product != null) {
        //        var viewModel = new UpdateProductViewModel()
        //        {
        //            Name = product.Name,
        //            Description = product.Description,
        //            ImageUrl = product.ImageUrl

        //        };

        //        return await Task.Run(() => View("View", viewModel)) ;
        //    }

        //    //return RedirectToAction("Pack");

        //    return NotFound();
        //}

        //// update
        //[HttpPost]
        //public async Task<IActionResult> View(UpdateProductViewModel model)
        //{
        //    var product = await _context.packProduct.FindAsync(model.Id);

        //    if (product != null)
        //    {
        //        product.Name = model.Name;
        //        product.Description = model.Description;
        //        product.ImageUrl = model.ImageUrl;


        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Pack");
        //    }
        //    return RedirectToAction("Pack");
        //}

        //// ajouter 
        //[HttpGet]
        //public async Task<IActionResult> Add()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Add(AddProductViewModel model)
        //{
        //    var product = new pack_product()
        //    {
        //        Name= model.Name,
        //        Description= model.Description,
        //        ImageUrl = model.ImageUrl,
        //    };

        //    _context.packProduct.Add(product);
        //    _context.SaveChanges();
        //    return RedirectToAction("Pack");
        //}
        //// supprimer
        //[HttpPost]
        //public async Task<IActionResult> Delete(UpdateProductViewModel model)
        //{
        //    var product = await _context.packProduct.FindAsync(model.Id);

        //    if (product != null)
        //    {

        //        _context.packProduct.Remove(product);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Pack");
        //    }
        //    return RedirectToAction("Pack");
        //}











        // card
        // afficher toutes les produits
        public IActionResult Card()
        {
            var products = _context.carteProduct.ToList();
            return View(products);
        }


        public IActionResult Credit()
        {
            var products = _context.creditProduct.ToList();
            return View(products);
        }

        // afficher le détails
        [HttpGet]
        public async Task<IActionResult> View(int id, string type)
        {
            // Assigner le type de produit à ViewBag.ProductType
            ViewBag.ProductType = type;
            UpdateProductViewModel viewModel = null;

            switch (type.ToLower())
            {
                case "pack":
                    var packProduct = await _context.packProduct.FirstOrDefaultAsync(p => p.Id == id);
                    if (packProduct != null)
                    {
                        viewModel = new UpdateProductViewModel
                        {
                            Id = packProduct.Id,
                            Name = packProduct.Name,
                            Description = packProduct.Description,
                            ImageUrl = packProduct.ImageUrl
                        };
                    }
                    break;

                case "card":
                    var carteProduct = await _context.carteProduct.FirstOrDefaultAsync(p => p.Id == id);
                    if (carteProduct != null)
                    {
                        viewModel = new UpdateProductViewModel
                        {
                            Id = carteProduct.Id,
                            Name = carteProduct.Name,
                            Description = carteProduct.Description,
                            ImageUrl = carteProduct.ImageUrl
                        };
                    }
                    break;

                case "credit":
                    var creditProduct = await _context.creditProduct.FirstOrDefaultAsync(p => p.Id == id);
                    if (creditProduct != null)
                    {
                        viewModel = new UpdateProductViewModel
                        {
                            Id = creditProduct.Id,
                            Name = creditProduct.Name,
                            Description = creditProduct.Description,
                            ImageUrl = creditProduct.ImageUrl
                        };
                    }
                    break;

                default:
                    return NotFound();
            }

            if (viewModel != null)
            {
                return await Task.Run(() => View("View", viewModel));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateProductViewModel model, string type)
        {
            switch (type.ToLower())
            {
                case "pack":
                    var packProduct = await _context.packProduct.FindAsync(model.Id);
                    if (packProduct != null)
                    {
                        packProduct.Name = model.Name;
                        packProduct.Description = model.Description;
                        packProduct.ImageUrl = model.ImageUrl;
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Pack");
                    }
                    break;

                case "card":
                    var carteProduct = await _context.carteProduct.FindAsync(model.Id);
                    if (carteProduct != null)
                    {
                        carteProduct.Name = model.Name;
                        carteProduct.Description = model.Description;
                        carteProduct.ImageUrl = model.ImageUrl;
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Card");
                    }
                    break;

                case "credit":
                    var creditProduct = await _context.creditProduct.FindAsync(model.Id);
                    if (creditProduct != null)
                    {
                        creditProduct.Name = model.Name;
                        creditProduct.Description = model.Description;
                        creditProduct.ImageUrl = model.ImageUrl;
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Credit");
                    }
                    break;
            }

            return RedirectToAction("Index");
        }


        // ajouter 
        [HttpGet]
        public IActionResult Add(string type)
        {
            // Assigner le type de produit à ViewBag.ProductType
            ViewBag.ProductType = type;
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddProductViewModel model, string type)
        {
            switch (type.ToLower())
            {
                case "pack":
                    var packProduct = new pack_product
                    {
                        Name = model.Name,
                        Description = model.Description,
                        ImageUrl = model.ImageUrl,
                    };
                    _context.packProduct.Add(packProduct);
                    break;

                case "card":
                    var carteProduct = new carte_product
                    {
                        Name = model.Name,
                        Description = model.Description,
                        ImageUrl = model.ImageUrl,
                    };
                    _context.carteProduct.Add(carteProduct);
                    break;

                case "credit":
                    var creditProduct = new credit_product
                    {
                        Name = model.Name,
                        Description = model.Description,
                        ImageUrl = model.ImageUrl,
                    };
                    _context.creditProduct.Add(creditProduct);
                    break;

                default:
                    return BadRequest("Invalid product type.");
            }

            _context.SaveChanges();
            return RedirectToAction(type);
        }


        // supprimer

        [HttpPost]
        //public async Task<IActionResult> Delete(UpdateProductViewModel model)
        //{
        //    var product = await _context.packProduct.FindAsync(model.Id);

        //    if (product != null)
        //    {

        //        _context.packProduct.Remove(product);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Pack");
        //    }
        //    return RedirectToAction("Pack");
        //}

        public async Task<IActionResult> Delete(UpdateProductViewModel model, string type)
        {
            if (model == null || string.IsNullOrEmpty(type))
            {
                return BadRequest("Invalid data.");
            }

            switch (type.ToLower())
            {
                case "pack":
                    var packProduct = await _context.packProduct.FindAsync(model.Id);
                    if (packProduct != null)
                    {
                        _context.packProduct.Remove(packProduct);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Pack");
                    }
                    break;

                case "card":
                    var carteProduct = await _context.carteProduct.FindAsync(model.Id);
                    if (carteProduct != null)
                    {
                        _context.carteProduct.Remove(carteProduct);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Card");
                    }
                    break;

                case "credit":
                    var creditProduct = await _context.creditProduct.FindAsync(model.Id);
                    if (creditProduct != null)
                    {
                        _context.creditProduct.Remove(creditProduct);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Credit");
                    }
                    break;

                default:
                    return BadRequest("Invalid product type.");
            }

            return NotFound("Product not found.");
        }





    }

}
