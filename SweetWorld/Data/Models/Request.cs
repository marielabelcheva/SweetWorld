using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Data.Models
{
    public class Request
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Client))]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey(nameof(Confectioner))]
        public Guid ConfectionerId { get; set; }
        public Confectioner Confectioner { get; set; }

        public string Description { get; set; }
    }
}
