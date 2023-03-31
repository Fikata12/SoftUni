using System.ComponentModel.DataAnnotations.Schema;

namespace Trucks.Data.Models
{
    public class ClientTruck
    {
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [ForeignKey("Truck")]
        public int TruckId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Truck Truck { get; set; } = null!;
    }
}