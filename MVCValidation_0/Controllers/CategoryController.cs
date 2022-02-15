using MVCValidation_0.DesignPatterns.SingletonPattern;
using MVCValidation_0.Models;
using MVCValidation_0.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCValidation_0.Controllers
{
    public class CategoryController : Controller
    {
        /*
                MVC Validation(Dogrulama)

        Sizin girilmesini istediginiz verilerin ne şekilde girilmesi gerektigini(bu alanın girilmesi zorunlu mu , email formatında mı , hangi sayı aralıkları, bir property ile uyusması gerekiyor mu) MVC Validation ile yaparsınız..Bu Validation sınıflarını rahatca DBFirst ile olusan sınıflarınıza da verebilirsiniz(Bu kesinlikle modelde modifikasyon yapmak sayılmaz)

        MVC Validation sınıflarını GitHub'tan, msdn'den hazır Regex sınıflarına bakarak bulabilirsiniz...ValidationAttribute sınıfından miras alan yapılara bakarsanız Validation sınıflarının arsivlerini bulabilirsiniz...

        Validationlar ikiye ayrılır => Server Side ve Client Side


        Client Side
        Client Side Validation icin Manage Nuget'tan Jquery Unobtrusive Validation kütüphanesini indirmelisiniz...

        Bu kütüphaneyi indirdiginiz zaman bunun Jquery'e ihtiyac duyacagını da bilmeniz lazım...

       
         
         
         
         
         */






        NorthwindEntities _db;

        public CategoryController()
        {
            _db = DBTool.DBInstance;
        }

        // GET: Category
        public ActionResult CategoryList()
        {
            CategoryVM cvm = new CategoryVM
            {
                Categories = _db.Categories.ToList()
            };
            return View(cvm);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {

            //ModelState property'miz bir modelin validated özelliklerini barındıran bir property'dir...(yani bu Model gönderilmeye uygun mu Data Annotation'larina sadık mı vs)...ModelState.IsValid dersek bu bize bool döndüren bir sonuc veren bir property'i kullanmak olur ver her şey yolundaysa true döndürür ve işlemlerin devam etmesini saglamamıza yarar...Tabii Data Annotation'i veritabanı ayarlamalarına uygun vermemiz gerekir eger Data Annotation yanlıssa her halükarda hata alma ihtimaliniz dogar...

            //Client side Validation yapmıyorsanız asagıdaki şekilde Server Side Validation'i tetiklemelisiniz...

           // if (!ModelState.IsValid) return View();

            _db.Categories.Add(category);
            _db.SaveChanges();

            return View();
        }
    }
}