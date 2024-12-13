using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderWebApi.Model
{
    [Serializable,BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId, BsonElement("_id"),BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; }

        [BsonElement("Customer_id"), BsonRepresentation(BsonType.Int32)]
        public int CustomerId { get; set; }
        public DateTime OrderedOn { get; set; }

        public List<OrderDetail> orderDetails { get; set; } 

      
    }
}
