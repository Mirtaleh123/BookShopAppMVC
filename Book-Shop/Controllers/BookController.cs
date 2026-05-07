using Book_Shop.Models;
using Book_Shop.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.EntityFrameworkCore;

namespace Book_Shop.Controllers
{
 public class BookController : Controller
        {
            private static readonly List<Book> books = new List<Book>
            {
                 new Book
                  {
                      Id=1,
                      Title="Elçibəy",
                      Author=" Mehmet Necati Dəmircan",
                      Price=11.82m,
                      ImageUrl="https://static.insales-cdn.com/images/products/1/800/833495840/ELCIBEY_qapaq__1_.jpg",
                      About="Sənədli-bədii tarixi roman Azərbaycan nəşri üçün yenidən işlənib\r\n\r\nİlk dəfə Türkiyədə (Kayseri, 2000) işıq üzü görmüş bu sənədli-tarixi roman çağdaş Azərbaycan tarixinin ən işıqlı simalarından biri, ikinci müstəqil Azərbaycan dövlətinin demokratik yolla seçilmiş ilk prezidenti Əbülfəz Elçibəyin (24.06.1938-22.08.2000) doğumundan ölümünədək olan bütün həyatını bədii-publisistik dillə əks etdirir.\r\nMüəllif M.N.Dəmircan bu əsəri ərsəyə gətirmək üçün Azərbaycanda və Türkiyədə nəşr olunmuş çoxlu kitab və məqalə ilə, internetdə yayımlanan çoxsaylı yazılı və video-materiallarla tanış olub.\r\nƏsər bütün təbəqələrdən olan oxucular üçün nəzərdə tutulub. "
                        },

                new Book
                {
                     Id=2,
                Title="Hamilə qız",
                Author = "Aləm Kəngərli",
                Price = 4.25m,
                 ImageUrl ="https://static.insales-cdn.com/r/3WeQLHOLHXk/rs:fit:570:570:1/q:80/plain/images/products/1/2841/2848353049/2025-11-24-11-46-251763970385.jpg@webp",
                     About = "\"Hamilə qız\" povestində sevgi və mənəviyyat xətti, ailə və cəmiyyət problemləri incə və dəqiq ştrixlərlə işlənib. Yaşlı bir kişinin gənc qıza sevgisi fonunda toplumun bu vəziyyətə münasibəti yazıçı tərəfindən fərqli formada təqdim edilir. Hər kəsin öz həqiqəti var və bu həqiqətlər yeni dəyərlərin formalaşmasından xəbər verir. Hadisələrin dinamikası oxucunu əsəri maraqla oxumağa sövq edir, yazıçı ustalıqla hadisədən hadisəyə keçidlər edərək, dramatik situasiyada belə, xoş ovqat yarada bilir. Müəllif xeyirxahlıq mexanizmini işə salaraq məsələnin sülh yolu ilə həllinə çalışır. Məsələ isə kifayət qədər mürəkkəbdir, bir anın içində kişinin bütün həyatı məhv ola bilər. Hər şey keçmiş sevgilidən asılıdır. Onlar vəziyyətdən necə çıxacaqlar, hamilə qızın taleyi necə olacaq? Əhvalat pozitiv prizmadan təqdim olunur. Əsəri oxuyanda həqiqət sizə agah olacaq.\r\n\r\nYazıçının kitaba toplanmış hekayələrində yaşadığımız dövrün mənzərəsi müxtəlif aspektlərdən təsvir edilir. \"Ona de ki...\" hekayəsində təsvir edilən kövrək sevgi hekayəsi oxucunun qəlbini riqqətə gətirir. Film kimi bir hekayədir. Digər hekayələrdəki incə yumor, sarkazm, qrotesk oxucunu həm düşündürür, həm də üzündə xoş təbəssüm yaradır.\r\nİnanırıq ki, yazıçının bu kitabı oxucular tərəfindən sevilə-sevilə oxunacaq. "
                },
                  new Book
                {
                     Id=3,
                Title="13-cü Kottecin Sirri",
                Author = "Nəzakət Cavadova",
                Price = 13.60m,
                 ImageUrl ="https://static.insales-cdn.com/images/products/1/7401/2848292073/2026-03-09-16-16-221773058582.png",
                     About = "Bu roman sevginin xilas yox, hökmə çevrildiyi bir dünyada vicdan, sədaqət və günah arasında parçalanan insanların hekayəsidir. Burada cinayət, sədaqət və susqunluq üzərində qurulmuş bir ailə bağının iç üzü açılmaqdadır. Cinayət şəbəkəsi, gizli qərarlar... Susdurulan şahidlər və “səni qorumaq üçün” verilən ölüm hökmləri... Burada nifrət açıq düşməndir, sevgi isə səssiz cəllad. Roman kriminal bir dünyanın içində böyüdülən bir gəncin qorunma adı ilə başqalarının ölümünə şərik edilməsini əks etdirir. Burada hər sirrin bir cəsədi, hər sədaqətin bir qurbanı var. Bu dünyada ən təhlükəli silah sevgidir, çünki sevgi silaha çevriləndə təhlükəli olur! Kitab susqunluğun günah, sevginin isə bəzən amansız hökm olduğunu xatırladır. Əsərin qəhrəmanı keçmişi ilə üz-üzə qalanda anlayır ki, bəzi günahlar törədildiyi an deyil, illər sonra da vicdanın dərinliyində cəza kimi yaşayır. Keçmiş susmur, sevgi xilas etmir və hər qorunanın bir bədəli olur. Keçmişlə üzləşmək isə qaçılmazdır. Kitab son səhifəyədək oxucunu bir sualla baş-başa qoyur: Səni qoruyan əllər başqasını qoruyursa, sən nə qədər günahsızsan? "
                },
                  new Book
                  {
                      Id=4,
                      Title="Əyləncəli fəlsəfə",
                      Author="Ömər Sevinçgül",
                      Price=8.45m,
                      ImageUrl="https://static.insales-cdn.com/images/products/1/673/2848072353/ANI_YASHA_qapaq.jpg",
                      About="Hər şey tarixi məhəllələrin birində kiçik bir ev almağımla başladı. Təmir vaxtı zirzəmidə sehrli bir otaq kəşf etdim və bu qəribə, yeraltı otağı yazıçı guşəmə çevirdim. Bundan sonra qəribə hadisələr baş verdi. Fəlsəfə tarixinin məşhur filosofları, mütəfəkkirləri, müdrikləri şəffaf bədənləri ilə otağımda peyda oldular. Sonra buna da öyrəşdim. Axı bu filosoflarla birlikdə fəlsəfə kitabları yazmaq, doğrudan da, maraqlı və əyləncəli olurdu. Amma ən qəribəsi odur ki, indi filosof olmayan bəzi adamlar da bu gizli otağa gəlməyə başladılar... Müslüm Baba, Dəli Ziya, Güldanə, Zəhra, Rəna və Onur. Uzun illərdən bəri arzuladığım fəlsəfə kitablarını indi qəribə qonaqlarımla birlikdə yazıram. Kim dedi ki, fəlsəfə darıxdırıcıdır? Oxuduğunuz bütün darıxdırıcı fəlsəfə kitablarını unudun! Bu kitabda fəlsəfə yoxdur! O, fəlsəfənin mahiyyətini açır, oxucunu filosof edir. Bu otaqdakılar sərbəst şəkildə sual verə, fikir yürüdə, tənqidi fikirlərini söyləyə bilərlər. Əlinizdə tutduğunuz bu kitab isə materializmlə idealizmin, dinsizliklə dinin əbədi mübarizəsinə həsr olunub."
                  },
                    new Book
                  {
                      Id=5,
                      Title="İkigai",
                      Author="Bettina Lemke",
                      Price=8.49m,
                      ImageUrl="https://static.insales-cdn.com/images/products/1/6425/2926074137/IKIGAI_qapaq.jpg",
                      About="Öz həyatını mənalandırmağı və onu gündəlik həyatda tapmağı bacaran insan xoşbəxtdir. Gündoğan ölkənin əksər sakinlərinin uzunömürlülüyü və məmnunluğu üçün məsul olan yapon prinsipi İkigai məhz bundan ibarətdir. Yazıçı Bettina Lemke öz kitabında İkigai fəlsəfəsinin təməl prinsiplərindən danışır, bir sıra tapşırıq və təcrübələr təklif edir. Onların köməyi ilə özünüzə bələd ola, ürəyinizi dinləməyi və İkigainizi tapmağı öyrənə bilərsiniz. Müəllifin həssas və ruhlandırıcı idarəçiliyi altında, bir çox nümunələr əsasında və ilhamverici meditativ üsullarla uşaqlığın xoş arzularını xatırlayın, üstün tutduğunuz kitabları, bədii nümunələri təhlil edin, ən cəsarətli xəyallarınıza doğru yol alın. Kitabın əsas hissəsi təcrübidir. Sizə hər tapşırığın yerinə yetirilməsi üçün dəqiq təlimatlar, həmçinin qeydləriniz üçün boş yer verilir."
                  },
                      new Book
                  {
                      Id=6,
                      Title="Pulun Psixologiyası",
                      Author="Morqan Haruzel",
                      Price=10.19m,
                      ImageUrl="https://static.insales-cdn.com/images/products/1/3457/2926046593/PULUN_PSIXOLOGIYASI_qapaq.jpg",
                      About="Əlinizdə tutduğunuz kitab həyatın ən vacib mövzularından birini - pul məsələsini daha yaxşı öyrədən hekayələr toplusudur. Morqan Hauzel düzgün maliyyə qərarları qəbul etmək\r\nvə sərvət sahibi olmaq üçün insan davranışını anlamağın vacibliyindən danışır. Çünki pullarınızın idarə olunması birbaşa biliyinizdən deyil, məhz ona münasibətinizdən asılıdır. Bəzən çox ağıllı insanlara belə bunları öyrənmək çətin gəlir. Bu, düşüncə tərzini dəyişməklə maddi rifahını yüksəltməyi qarşısına məqsəd qoyan insanlar üçün dəyərli məsləhətlər verən kitablardandır. Siz maliyyə fırıldaqlarını anlayacaq, lazım gəldiyi təqdirdə izafi xərclərdən yayına biləcəksiniz."
                   },
                      new Book
                  {
                      Id=7,
                      Title="Mafiya şahid saxlamır",
                      Author="Sabir Şahtaxtı",
                      Price=10.12m,
                      ImageUrl="https://static.insales-cdn.com/images/products/1/4465/2908098929/2026-03-09-15-15-201773054920.png",
                      About="Mürəkkəb və ziddiyyətli hadisələri... Cəmiyyətin dərin təzadları... İnsan münasibətlərinin mürəkkəbliyi... Müxtəlif xislətlər və xarakterlər... Bütün bunlar əsərin kəskin dramaturgiyasının əsasını təşkil edir. Oxucu romanda cəmiyyətin eybəcərliklərini görür, cinayətkar aləmdə əriyib-itən insan taleləri ilə tanış olur. Romanda çox maraqlı obrazlar silsiləsi yaradılıb. Onların hər birinin özünəməxsus xarakteri bədii ustalıqla açılır. Beş kitabdan ibarət olan sisilənin ilk kitabı böyük maraqla qarşılanıb və detektiv janrda yazılan yerli bestsellərə çevrilib."
                   },
                     new Book
                {
                Id=8,
                Title="Həmin o an",
                Author = "Qurban Səid",
                Price = 10.63m,
                 ImageUrl ="https://static.insales-cdn.com/images/products/1/5401/2851656985/WhatsApp_Image_2026-03-17_at_10.36.11.jpeg",
                     About = "Bəzən həyat səssiz görünür. Sanki hər şey axır, amma heç nə dəyişmir. İnsan özünü axtarır, amma nə axtardığını dəqiq bilmir. Sual çoxdur, cavab az. “Kiməm mən?” – deyir... “Niyə buradayam?” – soruşur. Və bir gün həmin o an gəlir.\r\nBu kitab sənin o anındır. Burada yazılanlar sadəcə bilik deyil. Bu, bir xatırlamadır.\r\nÇünki sən artıq bilirsən. Amma unutdurulmusan. Bu kitabda yenidən özünə qayıdırsan. Sənə deyilmir nə düşünməlisən. Sadəcə deyilir: bax budur... seç. Anla. Oyun bitdi. Əgər içində bir titrəyiş hiss edirsənsə, artıq gec deyil. Əgər oxuyarkən suallar açılırsa, deməli, sən oyanmağa başlamısan.\r\nBurada yazılan hər şeyin məqsədi var: Səni öz enerjinlə tanış etmək. Çünki bu enerji sadəcə bir varlıq deyil – bu sənsən. Sən həqiqət axtaran bir ruhsansa, mən sənin üçün yazıram bu kitabı. İçində çoxlu sualların varsa, hələ də cavabların yoxdursa, bil, oxuduğun\r\nsətirlər sənin cavabların olacaq. Bəlkə də, kitabı oxuyarkən bir anda içində bir şey dəyişəcək. Bəlkə, ağlayacaqsan, bəlkə, sakitcə dərin düşüncələrə qərq ola-\r\ncaqsan. Amma O an gələcək. Və sən həmin O an nəyin nə demək olduğunu anlayacaqsan... Həmin o an heç nə partlamır. Səssizdir o an. Elə bil zaman dayanır. Sən yenə eyni yerdəsən, amma sənin içində nə isə dəyişir. Ətrafda hər şey əvvəlki kimidir: eyni otaq, eyni insanlar, eyni səslər..."
                },
                     new Book
                     {
                Id=9,
                Title=" Всего шесть чисел: Главные силы, формирующие Вселенную",
                Author = " Мартин Рис",
                Price = 11.34m,
                 ImageUrl ="https://static.insales-cdn.com/images/products/1/2585/2855471641/7135681377-large.webp",
                     About = "Ключевые понятия космологии описаны доступным языком, без использования сложного математического аппарата В книге всемирно известного астрофизика, члена Королевского астрономического общества сэра Мартина Риса описываются фундаментальные силы, управляющие нашей Вселенной. Автор утверждает, что расширяющаяся Вселенная может быть определена всего шестью числами: N, e, Ω, l, Q, D, каждое из которых играет особую и решающую роль в ее эволюции, а вместе они определяют ее развитие и потенциал возможностей. Два из них связаны с основными силами; другие два определяют размер и общую структуру Вселенной и показывают, будет ли она существовать вечно; еще два говорят о свойствах самой Вселенной. Если бы любое из них было чуть чуть другим, не было бы звезд и не могла бы существовать жизнь. Мы могли появиться — и существуем сейчас — только во Вселенной с правильной комбинацией этих основополагающих чисел. А потому осознание этого дает совершенно новую точку зрения на Вселенную и наше место в ней, а также на саму природу физических законов. Мартину Рису удалось доступным языком, без использования сложного математического аппарата описать ключевые понятия космологии, которая стремительно развивается и сегодня находится на переднем крае науки."
                     },
                     new Book
                     {
                Id=10,
                Title=" Двенадцатая планета",
                Author = "Захария Ситчин",
                Price = 11.34m,
                 ImageUrl ="https://static.insales-cdn.com/images/products/1/1977/2855471033/7328593592.webp",
                     About = "За многие годы исследований были обнаружены удивительные свидетельства, бросающие вызов устоявшимся представлениям о происхождении Земли и жизни на ней и указывающие на существование высокоразвитой расы существ, когда-то населявших нашу планету. Итог тридцати лет интенсивных исследований, \"Двенадцатая планета\" (первая книга из серии \"Хроники Земли\") Захарии Ситчина - потрясающий труд, в котором представлены неоспоримые задокументированные доказательства существования внеземных предков человечества. Эти космические странники прибыли на Землю многие эоны лет назад и принесли с собой генетическое семя, которое в конечном итоге дало замечательный плод... названный Человеком. \"Двенадцатая планета\" рассказывает историю возникновения шумерской цивилизации и представляет древние свидетельства существования Нибиру, родной планеты ануннаков, которые прилетают на Землю каждые 3600 лет, а также раскрывает полную историю возникновения и развития Солнечной системы - в том виде, как об этом поведали землянам эти пришельцы. Серия \"Хроники Земли\", издаваемая миллионными тиражами по всему миру, посвящена истории и предыстории Земли и человечества. Каждая книга опирается на информацию, зафиксированную на глиняных табличках древними цивилизациями Ближнего Востока.\r\n"
                     },
                     new Book
                     {
                Id=11,
                Title=" Üç yoldaş",
                Author = " Erix Mariya Remark",
                Price = 11.04m,
                 ImageUrl ="https://static.insales-cdn.com/images/products/1/265/2904301833/UC_YOLDASH_qapaq.jpg",
                     About ="Hadisələr Birinci Dünya müharibəsindən sonrakı Almaniyada, sosial və iqtisadi böhran dövründə cərəyan edir. Müharibədən sağ çıxmış üç dost – Robert Lokamp, Otto Kester və Qottfrid Lens öz keçmişlərinin ağrısından, gələcəyə olan ümidsizlikdən qurtulmaq və həyatın mənasını yenidən tapmaq uğrunda mübarizə yaşayır. Onlar köhnə avtomobil təmiri sexində işləyir, kiçik sevinclər və dostluq sayəsində çətinliklərə sinə gərirlər. Lakin Robertin\r\nPatrisiya Holman adlı zərif və xəstə qıza aşiq olması dostların həyatını dəyişdirir... Böyük alman yazıçısı Erix Mariya Remarkın ötən əsrin 30-cu illərində qələmə aldığı “Üç yoldaş” romanı müəllifin ən duyğulu əsərlərindəndir. Romandakı sevgi və dostluq hekayəsi oxucunu\r\nhəm ağladır, həm düşündürür, həm də insan ruhunun müharibədən sonra da yaşamaq üçün necə dirəndiyini göstərir...." },
                      };




       

            // LIST + SEARCH + PAGINATION
            public IActionResult Index(string? search, int page = 1)
            {
                const int pageSize = 8;

                var query = books.AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.ToLower();

                    query = query.Where(x =>
                        x.Title.ToLower().Contains(search) ||
                        x.Author.ToLower().Contains(search));
                }

                var totalCount =  query.Count();

                var items =  query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                // 🔥 ƏN VACİB HİSSƏ
                var model = new PaginationList<Book>(items, totalCount, page, pageSize);

                return View(model); // ✅ artıq PaginationList göndəririk
            }

            // DETAIL
            [HttpGet]
            public IActionResult Detail(int id)
            {
                var book = books.FirstOrDefault(x => x.Id == id);

                if (book == null)
                    return NotFound();

                return View(book);
            }

            // CREATE - GET
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            // CREATE - POST
            [HttpPost]
            public IActionResult Create(Book book)
            {
                if (!ModelState.IsValid)
                    return View(book);

                books.Add(book);
               
                return RedirectToAction("Index");
            }

        // DELETE
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound();

            books.Remove(book);
            

            return RedirectToAction("Index");
        }

        // EDIT - GET
        [HttpGet]
            public IActionResult Edit(int id)
            {
                var book = books.FirstOrDefault(x => x.Id == id);

                if (book == null)
                    return NotFound();

                return View(book);
            }

            // EDIT - POST
            [HttpPost]
            public IActionResult Edit(Book book)
            {
                var existing = books.FirstOrDefault(x => x.Id == book.Id);

                if (existing == null)
                    return NotFound();

                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.Price = book.Price;
                existing.ImageUrl = book.ImageUrl;
                existing.About = book.About;

          

                return RedirectToAction("Index");
            }
        }
    }




