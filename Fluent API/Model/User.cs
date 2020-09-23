using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Fluent_API.Model
{
    public class User
    {
        public int UserId {set; get;}

        public string UserName {set; get;}

        public List<Product> ProductsPost {set; get;}
    }
}