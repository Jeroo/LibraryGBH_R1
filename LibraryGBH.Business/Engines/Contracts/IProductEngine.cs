using Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryGBH.Business.Entities;
using LibraryGBH.Business.Entities.DTOs;

namespace LibraryGBH.Business.Engines.Contracts
{
    public interface IProductEngine : IBusinessEngine
    {
        string IncreaseProductCode(string ProductCode);
        bool SaveProduct(ProductDTO product);
        List<ProductDTO> GetListProducts(string param);
        bool DeleteProduct(string productId);
        bool SaveToBuyProduct(List<ProductDTO> products);
        bool EditProduct(ProductDTO product);
        bool ReplenishProduct(long quantity,string productCode);
        ProductDTO GetProductById(string productCode);       

    }
}
