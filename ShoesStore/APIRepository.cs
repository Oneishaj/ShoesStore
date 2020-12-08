using Newtonsoft.Json.Linq;
using RestSharp;
using ShoesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesStore
{
    public class APIRepository : IAPIRepository
    {
        public IEnumerable<Shoes> GetShoes()
        {
            var client = new RestClient("https://amazon-product-reviews-keywords.p.rapidapi.com/product/search?keyword=shoes&category=aps&country=US");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "2f3895f6abmsh63811fc98028072p13045ajsnc8fd9268353c");
            request.AddHeader("x-rapidapi-host", "amazon-product-reviews-keywords.p.rapidapi.com");
            IRestResponse response = client.Execute(request);

            var obj = JObject.Parse(response.Content).GetValue("products");
            
            var shoesList = new List<Shoes>();

            foreach (var item in obj)
            {
                var shoe = new Shoes();
                shoe.ThumbNail = (string)item["thumbnail"];
                shoe.Title = (string)item["title"];
                shoe.Rating = (double)item["reviews"]["rating"];
                shoe.Price = (double)item["price"]["current_price"];
                shoesList.Add(shoe);
            }
            return shoesList;
        }
    }
}
