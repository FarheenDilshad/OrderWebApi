using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using OrderWebApi.Model;
using System.Security.Cryptography.X509Certificates;

namespace OrderWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _ordercollection;

        public OrderController()
        {
            var dbhost = "localhost";
            var dbName = "dms_Order";
            var ConnectionString = $"mongodb://{dbhost}:27017/{dbName}";
            var mongoUrl = MongoUrl.Create(ConnectionString);
            var mongoClient = new MongoClient(mongoUrl);
            var database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
            _ordercollection = database.GetCollection<Order>("order");
            //var httpclient=new HttpClient();
        }
        //
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _ordercollection.Find(Builders<Order>.Filter.Empty).ToListAsync();


        }

        [HttpGet("{OrderID}")]
        public async Task<ActionResult<Order>> GetById(string OrderID)
        {
            var fiterDefinition = Builders<Order>.Filter.Eq(x => x.OrderId, OrderID);
            return await _ordercollection.Find(fiterDefinition).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Create (Order order)
        {
            await _ordercollection.InsertOneAsync(order);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Order order)
        {
            var fiterDefinition = Builders<Order>.Filter.Eq(x => x.OrderId, order.OrderId);
            await _ordercollection.ReplaceOneAsync(fiterDefinition,order);
            return Ok();


        }

        [HttpDelete("{OrderID}")]
        public async Task<ActionResult> Delete(string OrderID)
        {
            var fiterDefinition = Builders<Order>.Filter.Eq(x => x.OrderId, OrderID);
            await _ordercollection.DeleteOneAsync(fiterDefinition);
            return Ok();

        }




    }

   
    }

