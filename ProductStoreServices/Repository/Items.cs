using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStoreServices.Repository
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public string Base64Content { get; set; }
    }

}