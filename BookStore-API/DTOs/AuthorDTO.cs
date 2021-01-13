using System.Collections.Generic;

namespace BookStore_API.DTOs
{
    public class AuthorDTO
    {
        public AuthorDTO()
        {
            Books = new HashSet<BookDTO>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<BookDTO> Books { get; set; }
    }
}
