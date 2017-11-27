using System.ComponentModel.DataAnnotations;

namespace projekt_szkoleniowy.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać imię autora")]
        [MinLength(2, ErrorMessage = "Za krótkie imię")]
        [MaxLength(20, ErrorMessage = "Za długie imię")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwisko autora")]
        [MinLength(2, ErrorMessage = "Za krótkie nazwisko")]
        [MaxLength(20, ErrorMessage = "Za długie nazwisko")]
        public string Surname { get; set; }
    }
}