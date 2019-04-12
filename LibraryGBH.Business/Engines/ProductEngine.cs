using Core.Common.Contracts;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryGBH.Business.Engines.Contracts;
using LibraryGBH.Business.Entities;
using LibraryGBH.Business.Entities.DTOs;

namespace LibraryGBH.Business.Engines
{
    public class ProductEngine : IProductEngine
    {
        private readonly IBusinessEngineFactory _businessEngineFactory;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IDataRepositoryFactory _dataRepositoryFactory;

        public ProductEngine(IDataRepositoryFactory dataRepositoryFactory, UserManager<IdentityUser> userManager, IBusinessEngineFactory businessEngineFactory)
        {
            this.userManager = userManager;
            this._businessEngineFactory = businessEngineFactory;
            this._dataRepositoryFactory = dataRepositoryFactory;
        }

        //public bool DeleteProduct(string productId)
        //{
        //    //var repoProductPool = _dataRepositoryFactory
        //    //    .GetDataRepository<ProductosPool>();
        //    //var repoProductTienda = _dataRepositoryFactory
        //    //    .GetDataRepository<ProductosTienda>();
        //    //var repoStock = _dataRepositoryFactory
        //    //    .GetDataRepository<Inventario>();
        //    //Guardamos en productos Pool
        //    var uow = _dataRepositoryFactory.GetUnitOfWork();
        //    using (var transaction = uow.CreateTransaction())
        //    {
        //        //soft delete
        //        // var productTienda = repoProductTienda.Get(productId);
        //        ProductosTienda productTienda = repoProductTienda.Get(x => 
        //        x.Where(y => y.CodigoProducto.ToLower() == productId.ToLower()));
        //        productTienda.Deferred = true;
        //        repoProductTienda.Update(productTienda);

        //        ProductosPool productPool = repoProductPool
        //            .Get(x => x.Where(r => r.ProductoId == productTienda.Id));
        //        //soft delete
        //        productPool.Deferred = true;
        //        repoProductPool.Update(productPool);
        //        transaction.Commit();
        //        return true;
        //    }
         
        //}

        //public bool EditProduct(ProductDTO product)
        //{
        //    var repoProductPool = _dataRepositoryFactory.GetDataRepository<ProductosPool>();
        //    var repoProductTienda = _dataRepositoryFactory.GetDataRepository<ProductosTienda>();
        //    var repoStock = _dataRepositoryFactory.GetDataRepository<Inventario>();          
           

        //    //Guardamos en productos Pool
        //    var uow = _dataRepositoryFactory.GetUnitOfWork();

        //    using (var transaction = uow.CreateTransaction())
        //    {
        //        Inventario updateInventario = null;

        //        var stockExits = repoProductTienda.Get(x => x.Select(r => new ProductosTienda()), x => x.CodigoProducto == product.ProductCode);

        //        if (stockExits != null)
        //        {

        //            updateInventario = stockExits.Inventario;
        //            updateInventario.CantidadEnStock = product.Quantity;
        //            updateInventario.UsuarioReposicion = product.user;
        //            updateInventario.FechaReposicion = DateTime.Now;

        //            repoStock.Update(updateInventario);
        //        }
        //        else
        //        {
        //            updateInventario = new Inventario();
        //            updateInventario.CantidadEnStock = product.Quantity;
        //            updateInventario.UsuarioReposicion = product.user;
        //            updateInventario.FechaReposicion = DateTime.Now;

        //            repoStock.Add(updateInventario);
        //        }


        //        ProductosTienda updateProductosTienda = new ProductosTienda();
        //        updateProductosTienda.CodigoProducto = product.ProductCode;
        //        updateProductosTienda.Precio = product.Price;
        //        updateProductosTienda.InventarioId = updateInventario.Id;

        //        repoProductTienda.Update(updateProductosTienda);


        //        ProductosPool updateProductPool = new ProductosPool();
        //        updateProductPool.Nombre = product.Name;
        //        updateProductPool.Img = product.Img;
        //        updateProductPool.Descripcion = product.Description;
        //        repoProductPool.Update(updateProductPool);


        //        transaction.Commit();
        //    }



        //    return true;
        //}

        //public List<ProductDTO> GetListProducts(string param)
        //{
        //    var repoProductPool = _dataRepositoryFactory.GetDataRepository<ProductosPool>();
        //    var predicate = PredicateBuilder.New<ProductosPool>(true);
        //    predicate = predicate.And(c => !c.Deferred);


        //    if (!string.IsNullOrEmpty(param))
        //    {
        //        predicate = predicate.And(c => c.Nombre.Contains(param));              
        //    }

        //    var listProducts = repoProductPool.GetAll(x => x.Select(r => new ProductDTO
        //    {
        //        ProductCode = r.ProductosTienda.CodigoProducto,
        //        ProductId = r.ProductoId,
        //        Name = r.Nombre,
        //        Quantity = r.ProductosTienda.Inventario.CantidadEnStock,
        //        Description = r.Descripcion,
        //        Img = r.Img,
        //        Price = r.ProductosTienda.Precio

        //    }), predicate);

        //    return listProducts.ToList();


        //}

        //public ProductDTO GetProductById(string productCode)
        //{
        //    var repoProductPool = _dataRepositoryFactory.GetDataRepository<ProductosPool>();

        //    var predicate = PredicateBuilder.New<ProductosPool>(true);            

        //    if (!string.IsNullOrEmpty(productCode))
        //    {
        //        predicate = predicate.And(c => !c.Deferred);
        //        predicate = predicate.And(c => c.ProductosTienda.CodigoProducto.Contains(productCode));
        //    }

        //    var product = repoProductPool.Get(x => x.Select(r => new ProductDTO {


        //        ProductCode = r.ProductosTienda.CodigoProducto,
        //        ProductId = r.ProductoId,
        //        Name = r.Nombre,
        //        Quantity = r.ProductosTienda.Inventario.CantidadEnStock,
        //        Description = r.Descripcion,
        //        Img = r.Img,
        //        Price = r.ProductosTienda.Precio

        //    }), predicate);


        //    return product;
        //}

        //public string IncreaseProductCode(string ProductCode)
        //{
        //    String[] parts = ProductCode.Split("-");
        //    int increaseProductCode = Int32.Parse(parts[1]);
        //    increaseProductCode = increaseProductCode + 1;

        //    switch (increaseProductCode.ToString().Length)
        //    {
        //        case 1:
        //            ProductCode = "P-000" + increaseProductCode;
        //            break;
        //        case 2:
        //            ProductCode = "P-00" + increaseProductCode;
        //            break;
        //        case 3:
        //            ProductCode = "P-0" + increaseProductCode;
        //            break;
        //        case 4:
        //            ProductCode = increaseProductCode.ToString();
        //            break;
        //        default:
        //            break;
        //    }

        //    return ProductCode;
        //}

        //public bool ReplenishProduct(long quantity, string productCode)
        //{
        //    var repoStock = _dataRepositoryFactory.GetDataRepository<Inventario>();
        //    var repoProductTienda = _dataRepositoryFactory.GetDataRepository<ProductosTienda>();

        //    var predicate = PredicateBuilder.New<ProductosPool>(true);

        //    if (!string.IsNullOrEmpty(productCode) && quantity > 0)
        //    {
        //        predicate = predicate.And(c => !c.Deferred);
        //        predicate = predicate.And(c => c.ProductosTienda.CodigoProducto.Contains(productCode));
        //    }

        //    Inventario updateInventario = null;

        //    // var stockExits = repoProductTienda.Get(x => x.Select(r => new ProductosTienda()), x => x.CodigoProducto.ToLower().Contains(productCode.ToLower()));
        //    var stockExits = repoProductTienda.Get(x => x.Where(r => r.CodigoProducto.ToLower().Trim() == productCode.ToLower().Trim()));

        //    var stock = repoStock.Get(stockExits.InventarioId.Value);

        //    updateInventario = stockExits.Inventario;
        //    updateInventario.CantidadEnStock = quantity;
        //    updateInventario.UsuarioReposicion = new Guid();
        //    updateInventario.FechaReposicion = DateTime.Now;

        //    repoStock.Update(updateInventario);

        //    return true;
        //}

        //public bool SaveProduct(ProductDTO product)
        //{
        //    var repoProductPool = _dataRepositoryFactory.GetDataRepository<ProductosPool>();
        //    var repoProductTienda = _dataRepositoryFactory.GetDataRepository<ProductosTienda>();
        //    var repoStock = _dataRepositoryFactory.GetDataRepository<Inventario>();
        //    string lastProductCode = string.Empty;
        //    // var predicate = PredicateBuilder.New<ProductosPool>(true);

        //    // predicate = predicate.And(c => c.ProductoId);

        //    var products = repoProductTienda.GetAll();

        //    if (products.Count() > 0)
        //    {
        //        var lastProduct = products.OrderByDescending(x => x.Id).First();
        //        lastProductCode = lastProduct.CodigoProducto;

        //    }

        //    if (!string.IsNullOrEmpty(lastProductCode))
        //    {

        //        // LLamamos el metodo que incrementa en 1 el codigo del producto
        //        lastProductCode = IncreaseProductCode(lastProductCode);

        //    }
        //    else
        //    {

        //        lastProductCode = "P-0001";

        //    }

        //    //Guardamos en productos Pool
        //    var uow = _dataRepositoryFactory.GetUnitOfWork();

        //    using (var transaction = uow.CreateTransaction())
        //    {
        //        Inventario newInventario = null;

        //        var stockExits = repoProductTienda.Get(x => x.Select(r  => new  ProductosTienda()),x=>x.CodigoProducto == product.ProductCode);

        //        if (stockExits != null)
        //        {

        //            newInventario = stockExits.Inventario;
        //            newInventario.CantidadEnStock = product.Quantity;
        //            newInventario.UsuarioReposicion = product.user;
        //            newInventario.FechaReposicion = DateTime.Now;

        //            repoStock.Update(newInventario);
        //        }
        //        else
        //        {
        //            newInventario = new Inventario();
        //            newInventario.CantidadEnStock = product.Quantity;
        //            newInventario.UsuarioReposicion = product.user;
        //            newInventario.FechaReposicion = DateTime.Now;

        //            repoStock.Add(newInventario);
        //        }            


        //        ProductosTienda newProductosTienda = new ProductosTienda();
        //        newProductosTienda.CodigoProducto = lastProductCode;
        //        newProductosTienda.Precio = product.Price;
        //        newProductosTienda.InventarioId = newInventario.Id;

        //        repoProductTienda.Add(newProductosTienda);


        //        ProductosPool newProductPool = new ProductosPool();
        //        newProductPool.Nombre = product.Name;
        //        newProductPool.Img = product.Img;
        //        newProductPool.Descripcion = product.Description;
        //        newProductPool.ProductoId = newProductosTienda.Id;
        //        repoProductPool.Add(newProductPool);      


        //        transaction.Commit();
        //    }

            

        //    return true;
        //}

        //public bool SaveToBuyProduct(List<ProductDTO> products)
        //{
        //    var repoProductPool = _dataRepositoryFactory.GetDataRepository<ProductosPool>();
        //    var repoProductTienda = _dataRepositoryFactory.GetDataRepository<ProductosTienda>();
        //    var repoStock = _dataRepositoryFactory.GetDataRepository<Inventario>();
        //    var repoSales = _dataRepositoryFactory.GetDataRepository<Ventas>();


        //    //Guardamos en productos Pool
        //    var uow = _dataRepositoryFactory.GetUnitOfWork();

        //    using (var transaction = uow.CreateTransaction())
        //    {
                

        //        foreach (var product in products)
        //        {
        //            ProductosTienda newProductosTienda = repoProductTienda.Get(x => x.Where(y => y.CodigoProducto.ToLower() == product.ProductCode.ToLower()));

        //            if (newProductosTienda != null)
        //            {
        //                //Save Data into Ventas
        //                Ventas newSales = new Ventas();
        //                newSales.CantidadVendidas = Convert.ToInt64(product.Quantity);
        //                newSales.ProductoId = newProductosTienda.Id;
        //                newSales.FechaVenta = DateTime.Now;
        //                newSales.UsuarioComprador = new Guid();

        //                repoSales.Add(newSales);

        //                //Reduce Stock
        //                Inventario updateStock = repoStock.Get(newProductosTienda.InventarioId.Value);

        //                if (updateStock.CantidadEnStock > product.Quantity)
        //                {
        //                    updateStock.CantidadEnStock = updateStock.CantidadEnStock - product.Quantity;
        //                }
        //                else
        //                {
        //                    return false;
        //                }

        //                repoStock.Update(updateStock);

        //            }
        //            else
        //            {
        //                return false;
        //            }

                  
        //        }
                

        //        transaction.Commit();

        //    }

        //    return true;
        //}
    }
}
