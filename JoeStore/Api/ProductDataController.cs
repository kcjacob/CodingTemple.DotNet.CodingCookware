using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace CodingTemple.CodingCookware.Web.Controllers
{
    //My API controllers are inheriting from the ApiController base class, not the same thing as MVC's Controller base class.
    public class ProductDataController : ApiController
    {
        //Each method responds on a matching HTTP verb - calling "Get" on ProductData will return one of the GET methods:
        
        public Models.ProductModel[] Get()
        {
            return Models.ProductData.Products.ToArray();
      
        }


        //Most exciting part: WebAPI automatically handles the Serialization of data - either JSON or XML, based on the "Accept" header sent by the client
        public Models.ProductModel Get(int id)
        {
            return Models.ProductData.Products.FirstOrDefault(x => x.ID == id);
        }

        public IHttpActionResult Post(Models.ProductModel model)
        {
            var p = Models.ProductData.Products.FirstOrDefault(x => x.ID == model.ID);
            if(p != null)
            {
                p.Description = model.Description;
                p.Name = model.Name;
                p.Price = model.Price;
                return this.Ok<Models.ProductModel>(p);
            }
            return this.BadRequest("Product not found");
        }

        public IHttpActionResult Put(Models.ProductModel model)
        {
            int nextId = Models.ProductData.Products.Max(x => x.ID) + 1;
            model.ID = nextId;
            Models.ProductData.Products.Add(model);

            return this.Created("/api/Get/" + nextId, model);
        }

        public IHttpActionResult Delete(int id)
        {
            Models.ProductData.Products.RemoveAt(Models.ProductData.Products.FindIndex(x => x.ID == id));
            return this.Ok();
        }
    }
}
