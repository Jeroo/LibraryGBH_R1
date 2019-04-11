using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LibraryGBH.Business.Engines.Contracts;
using LibraryGBH.Business.Entities;
using LibraryGBH.Business.Entities.DTOs;
using LibraryGBH.WEB.Models.ViewModels;

namespace LibraryGBH.WEB.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {

        private readonly IBusinessEngineFactory _businessEngineFactory;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IDataRepositoryFactory _dataRepositoryFactory;

        public ProductController(IDataRepositoryFactory dataRepositoryFactory, UserManager<IdentityUser> userManager, 
            IBusinessEngineFactory businessEngineFactory, 
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this._businessEngineFactory = businessEngineFactory;
            this.signInManager = signInManager;
            this._dataRepositoryFactory = dataRepositoryFactory;
        }

        [Route("listaproductos")]
        public async Task<List<ProductDTO>> ListaProductos(string param)
        {
            var productEngine = _businessEngineFactory.GetBusinessEngine<IProductEngine>();
            return productEngine.GetListProducts(param);
        }


        [Route("getproductbyid")]
        public async Task<ProductDTO> GetProductById(string param)
        {
            var productEngine = _businessEngineFactory.GetBusinessEngine<IProductEngine>();

            return productEngine.GetProductById(param);
        }

        [Route("getproductsdll")]
        public async Task<List<KeyValueDTO>> GetProductForDDl()
        {
            var productRepo = _dataRepositoryFactory.GetDataRepository<ProductosPool>();
            var ListProductKeyValue = productRepo.GetAll(x =>x.Select(r => new KeyValueDTO {
                key = r.ProductosTienda.Id,
                value = r.Nombre
            }));

            return ListProductKeyValue.ToList();
        }


        [HttpPost,Route("replenishproduct")]
        public async Task<IActionResult> ReplenishProduct([FromBody]ReplenishProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productEngine = _businessEngineFactory.GetBusinessEngine<IProductEngine>();

                productEngine.ReplenishProduct(model.Quantity,model.ProductCode);

                return Ok("Ok");

            }

            return BadRequest("Error");
        }

        [Route("editproduct")]
        public async Task<IActionResult> EditProduct(AddEditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productEngine = _businessEngineFactory.GetBusinessEngine<IProductEngine>();
                var user = await userManager.GetUserAsync(principal: User);

                ProductDTO updateProductDTO = new ProductDTO
                {
                    Description = model.Description,
                    Img = null,
                    Name = model.Name,
                    Price = model.Price,
                    ProductCode = model.ProductCode,
                    ProductId = model.ProductId,
                    Quantity = model.Quantity,
                    user = model.user
                    // user = new Guid(user.Id)

                };

                foreach (var item in model.Img)
                {
                    if (item.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {

                            await item.CopyToAsync(stream);
                            updateProductDTO.Img = stream.ToArray();
                        }
                    }
                }


                productEngine.SaveProduct(updateProductDTO);

                return Ok("Ok");

            }

            return BadRequest("Error");
        }

        [Route("saveproduct")]
        public async Task<IActionResult> saveProduct(AddEditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productEngine = _businessEngineFactory.GetBusinessEngine<IProductEngine>();
                var user = await userManager.GetUserAsync(principal: User);

                ProductDTO newProductDTO = new ProductDTO
                {
                    Description = model.Description,
                    Img = null,
                    Name = model.Name,
                    Price = model.Price,
                    ProductCode = model.ProductCode,
                    ProductId = model.ProductId,
                    Quantity = model.Quantity,
                    user = model.user
                    // user = new Guid(user.Id)

                };

                foreach (var item in model.Img)
                {
                    if (item.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {

                            await item.CopyToAsync(stream);
                            newProductDTO.Img = stream.ToArray();
                        }
                    }
                }  


                productEngine.SaveProduct(newProductDTO);

                return Ok("Ok");

            }

            return BadRequest("Error");
        }

        [Route("deleteproduct")]
        public async Task<IActionResult> DeleteProduct(string productId)
        {
            var productEngine = _businessEngineFactory.GetBusinessEngine<IProductEngine>();

            productEngine.DeleteProduct(productId);

            return Ok("Ok");
        }


       
        [HttpPost]
        [Route("savetobuyproduct")]
        public async Task<IActionResult> SaveToBuyProduct([FromBody]ViewModelProducts[] products)
        {
            if (ModelState.IsValid)
            {
                var productEngine = _businessEngineFactory.GetBusinessEngine<IProductEngine>();

                List<ProductDTO> listProducts = new List<ProductDTO>();

                foreach (ViewModelProducts item in products)
                {
                    listProducts.Add(new ProductDTO {
                        Description = item.Description,
                        Img = item.Img,
                        Name = item.Name,
                        Price = item.Price,
                        ProductCode = item.ProductId,
                        ProductId = null,
                        Quantity = item.Quantity,
                        user = item.user

                    });
                }

                if (productEngine.SaveToBuyProduct(listProducts))
                {
                    return Ok("Ok");
                }

                return BadRequest("Error");

            }              


            return BadRequest("Error");
        }

    }
}