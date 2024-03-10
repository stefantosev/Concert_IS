using Concert.WEB.Models.IdentityModels;
using System.ComponentModel.DataAnnotations;

namespace Concert.WEB.Models
{
    public class Ticket
    {

        [Key]
        public Guid Id { get; set; }

        public int NumberOfPeople { get; set; }

        public virtual ConcertAppUser? ConcertAppUser { get; set; }


        public Guid ConcertId { get; set; }
        public virtual ConcertLab? Concert { get; set; }   //virtual se koristi kako za fetch types na relacii

    }
}
