using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Concert.WEB.Models.IdentityModels
{
    public class ConcertAppUser : IdentityUser
    {
      

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Address { get; set; }

        //? -> stavame za dali moze da bide nullable
    }
}
