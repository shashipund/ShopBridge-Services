using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProductStoreServices.Repository;
using ProductStoreServices.Models;
using System.Web;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace ProductStoreServices.Controllers
{
    [RoutePrefix("api/Product")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        private IProductMasterRepository productRepository;
      
        public ProductController(IProductMasterRepository repository)  
        {
            this.productRepository = repository;
        }


        [Route("ProductList")]
        public IHttpActionResult GetAll()
        {
          
                List<Items> list = productRepository.GetProductList();
                return Ok(list);
            
        }

        [HttpGet]
        [Route("GetProductDetails/{id}")]
        public IHttpActionResult GetProduct(int id)
        {
            Item item = productRepository.GetProduct(id);

            if (item != null)
                return Ok(item);
            else
                return NotFound();
        }


        [HttpPost]
        [Route("AddProduct")]
        public IHttpActionResult PostProduct(Item _item)
        {
            return Ok(productRepository.AddProduct(_item));
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public IHttpActionResult UpdateProduct(Item _item)
        {
            return Ok(productRepository.UpdateProduct(_item));
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            return Ok(productRepository.DeleteProduct(id));
        }

        [HttpGet]
        [Route("SearchProductList/{term}")]
        public IHttpActionResult SearchProduct(string term)
        {
            return Ok(productRepository.SearchProductList(term));
        }
    }
}
