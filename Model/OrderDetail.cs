using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderWebApi.Model
{
    [Serializable, BsonIgnoreExtraElements]
    public class OrderDetail
    {
        [BsonElement("Product_Id"), BsonRepresentation(BsonType.Int32)]
        public int ProductId { get; set; }

        [BsonElement("Quantity"), BsonRepresentation(BsonType.Decimal128)]
        public decimal Quantity { get; set; }

        [BsonElement("Unit_price"), BsonRepresentation(BsonType.Decimal128)]

        public decimal Unitprice { get; set; }
    }
}
