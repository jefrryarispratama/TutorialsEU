using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TutorialsEU.Models;

namespace TutorialsEU.Pages
{
    public class PeopleModel : PageModel
    {
        //ini untuk set Entity frameworknya
        private readonly MyDbContext _context;

        //ini untuk tarik data dari model digabungin jadi satu disini
        [BindProperty]
        public Person NewPerson { get; set; }

        public List<Person> People { get; set; } = new List<Person>(); 

        //ini untuk isi database dari entity framework berdasarkan hasil input
        public PeopleModel(MyDbContext context)
        {
            _context = context;   
        }

        //get disini tidak di isi dikarenakan lu gk ada data yang mau diambil
        public void OnGet()
        {
            //ketika sudah di assign nilai pada OnGet maka nantinya hasil post akan
            //ditampilkan kembali dengan cara mengambil data dari OnPost kemudian ditampilkan
            //kembali menjadi suatu data yang berdasarkan 
            People = _context.People.ToList();  
        }

        //disini dia pakek Onpost supaya setelah submit buttonnya ditekan
        //maka nanti hasil submitan itu bakal di save kedalam entity framework
        //tujuan dari entity framework ini salah satunya adalah save Data tanpa database
        //tanpa harus menggunakan SQL Server dll, namun perlu config di Model dan Program.cs
        public IActionResult OnPost()
        {
            _context.People.Add(NewPerson); 

            _context.SaveChanges(); 

            return RedirectToPage();
        }
    }
}
