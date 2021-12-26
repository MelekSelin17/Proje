using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Data
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            CreateFoodCategories(context);
            CreateFood(context);
            CreateRoles(roleManager, userManager).Wait();
        
        }

        private static void CreateFoodCategories(ApplicationDbContext context)
        {
            if (!context.FoodCategories.Any())
            {
                context.FoodCategories.Add(new Models.FoodCategory()
                {
                    Name = "Pizza"
                });
                context.FoodCategories.Add(new Models.FoodCategory()
                {
                    Name = "Salata"
                });
                context.FoodCategories.Add(new Models.FoodCategory()
                {
                    Name = "Noodle"
                });
                context.SaveChanges();
            }
            
            
        }
        
        private static void CreateFood(ApplicationDbContext context)
        {
            if (!context.Foods.Any())
            {
                context.Foods.Add(new Models.Food()
                {
                    Name = "Margarita Pizza",
                    Description = "Margarita pizza, domates, mozarella, fesleğen, zeytinyağı ve tuzla yapılan Napoli pizzasıdır.",
                    FoodCategoryId = 1,
                    Fiyat = "10$"

                }) ;
                context.Foods.Add(new Models.Food()
                {
                    Name = "Karışık Pizza",
                    Description = "Pizza, İtalyan mutfağında bir mayalı hamur işi. Üstüne birçok malzeme konulabilir. Peynir, sosis, domates, salam, biber, zeytin, mısır gibi ana malzemeleri dışında birçok değişik malzemenin konulduğu pizzalar da bulunmaktadır. ",
                    FoodCategoryId = 1,
                    Fiyat = "15$"

                });
                context.Foods.Add(new Models.Food()
                {
                    Name = "Tavuklu Barbekülü Pizza",
                    Description = "İçinde enfes barbekü sosu ve tavuk parçalarıyla...",
                    FoodCategoryId = 1,
                    Fiyat = "15$"

                });
                context.Foods.Add(new Models.Food()
                {
                    Name = "Sezar Salata",
                    Description = "Sezar salatası limon suyu, zeytinyağı, yumurta, Worcestershire sos, ançuez, sarımsak, Dijon hardalı, Parmesan peyniri ve karabiber ile hazırlanan yeşil marul ve krutonlu yeşillik salatasıdır. Türkiye'de ançüez yerine genellikle ızgara tavuk göğsü kullanılır.",
                    FoodCategoryId = 2,
                    Fiyat = "20$"

                });
                context.Foods.Add(new Models.Food()
                {
                    Name = "Akdeniz Salata",
                    Description = "Peyniri bol yeşilliği bol leziz bir salata olan Akdeniz salatası, besin içeriğiyle de şifa dağıtıyor.",
                    FoodCategoryId = 2,
                    Fiyat = "20$"

                });
                context.Foods.Add(new Models.Food()
                {
                    Name = "Ton Balıklı Salata",
                    Description = "Diyetlerin olmazsa olmazı; Mısırlı Ton Balıklı Salata en çok tercih edilen ürünlerimizdendir",
                    FoodCategoryId = 2,
                     Fiyat = "18$"

                });
                context.Foods.Add(new Models.Food()
                {
                    Name = "Tavuklu Noodle",
                    Description = "Noodle, bir erişte ve şehriye türüdür. Yine buna karşılık Kâşgarlı Mahmud, Divanü Lûgat-it-Türk adlı eserinde Ügre sözcüğünü zikretmektedir. Düz haddelenmiş ve kesilmiş, gerilmiş veya ekstrüde edilmiş, uzun şeritler veya teller halinde mayalanmamış hamurdan yapılmıştır",
                    FoodCategoryId = 3,
                    Fiyat = "20$"

                });
                context.Foods.Add(new Models.Food()
                {
                    Name = "Sebzeli Noodle",
                    Description = "Noodle, gerilmiş, ekstrüde edilmiş veya yassı haddelenmiş ve genellikle uzun, ince şeritler veya dalgalar, helisler, borular, teller veya kabukları içeren, katlanmış veya başka kesilmiş veya şekillendirilmiş çeşitli şekillerden birine kesilmiş mayasız hamurlardır. Çorbanın içerisine katılabilen, kızartılabilen noodle, özellikle hızlıca akşam yemeği hazırlamak isteyenler için ideal bir lezzet.",
                    FoodCategoryId = 3,
                    Fiyat = "10$"

                });
                context.Foods.Add(new Models.Food()
                {
                    Name = "Ramen",
                    Description = "Rāmen, Çin kökenli olan ve çorba içinde sunulan eriştenin Japon mutfağı'ndaki adıdır. Genellikle çorbası, et suyu ile yapılır ve dilimlenmiş et, kurutulmuş deniz yosunu, kamaboko, yeşil soğan ve hatta mısır gibi üst malzemeleri ile servis edilir.",
                    FoodCategoryId = 3,
                    Fiyat = "25$"

                });
                context.SaveChanges();
            }


        }

        private async static Task CreateRoles(RoleManager<IdentityRole> roleManager,UserManager<IdentityUser> userManager)
        {
            await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
            await roleManager.CreateAsync(new IdentityRole() { Name = "Guest" });
            await roleManager.CreateAsync(new IdentityRole() { Name = "Chef" });


            var adminObject = new IdentityUser()
            {
                Email = "admin@gmail.com",
                UserName = "superAdmin",
            };
            var userObject = new IdentityUser()
            {
                Email = "selin@gmail.com",
                UserName = "Selin",
            };
            var ccc = await userManager.CreateAsync(userObject, "1234");
            await userManager.AddToRoleAsync(userObject, "Guest");

            return;
        }
       

    }
}
