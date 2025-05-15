using AP_4_LR2;
using AP_4_LR2.Models;
using AP_4_LR2.Repositories;
using System.Text;

var context = new LibraryContext();
context.Database.EnsureCreated();
Console.OutputEncoding = UTF8Encoding.UTF8;
var contentRepo = new GenericRepository<ContentItem>(context);
var locationRepo = new GenericRepository<StorageLocation>(context);

while (true)
{
    Console.WriteLine("\n--- Бібліотека контенту ---");
    Console.WriteLine("1. Додати сховище");
    Console.WriteLine("2. Додати контент");
    Console.WriteLine("3. Переглянути весь контент");
    Console.WriteLine("4. Пошук за назвою");
    Console.WriteLine("5. Видалити контент за ID");
    Console.WriteLine("0. Вихід");
    Console.Write("Оберіть дію: ");

    var input = Console.ReadLine();
    Console.WriteLine();

    switch (input)
    {
        case "1":
            Console.Write("Назва сховища: ");
            var name = Console.ReadLine();
            Console.Write("Адреса: ");
            var address = Console.ReadLine();
            Console.Write("Тип: ");
            var type = Console.ReadLine();

            locationRepo.Create(new StorageLocation
            {
                Name = name ?? "",
                Address = address ?? "",
                Type = type ?? ""
            });
            locationRepo.Save();
            Console.WriteLine("Сховище додано.");
            break;

        case "2":
            Console.WriteLine("Оберіть тип: 1-Книга, 2-Документ, 3-Відео, 4-Аудіо");
            var typeChoice = Console.ReadLine();
            Console.Write("Назва: ");
            var title = Console.ReadLine();
            Console.Write("Формат: ");
            var format = Console.ReadLine();

            Console.WriteLine("ID наявних сховищ:");
            foreach (var s in locationRepo.GetAll())
                Console.WriteLine($"{s.Id}: {s.Name} - {s.Type}");

            Console.Write("Введіть ID сховища: ");
            int.TryParse(Console.ReadLine(), out int storageId);

            ContentItem item = typeChoice switch
            {
                "1" => new Book
                {
                    Title = title ?? "",
                    Format = format ?? "",
                    Author = Ask("Автор"),
                    Pages = int.Parse(Ask("Кількість сторінок")),
                    StorageLocationId = storageId
                },
                "2" => new Document
                {
                    Title = title ?? "",
                    Format = format ?? "",
                    DocumentType = Ask("Тип документу"),
                    Size = int.Parse(Ask("Розмір (КБ)")),
                    StorageLocationId = storageId
                },
                "3" => new Video
                {
                    Title = title ?? "",
                    Format = format ?? "",
                    Duration = int.Parse(Ask("Тривалість (сек)")),
                    Resolution = Ask("Роздільна здатність"),
                    StorageLocationId = storageId
                },
                "4" => new Audio
                {
                    Title = title ?? "",
                    Format = format ?? "",
                    Duration = int.Parse(Ask("Тривалість (сек)")),
                    Bitrate = int.Parse(Ask("Бітрейт (Кбіт/с)")),
                    StorageLocationId = storageId
                },
                _ => null!
            };

            if (item != null)
            {
                contentRepo.Create(item);
                contentRepo.Save();
                Console.WriteLine("Контент додано.");
            }
            break;

        case "3":
            foreach (var c in contentRepo.GetAll())
            {
                Console.WriteLine($"ID: {c.Id}, Назва: {c.Title}, Тип: {c.GetType().Name}, Сховище ID: {c.StorageLocationId}");
            }
            break;

        case "4":
            Console.Write("Введіть назву для пошуку: ");
            var keyword = Console.ReadLine()?.ToLower();

            var results = contentRepo.GetAll().Where(c => c.Title.ToLower().Contains(keyword ?? ""));
            foreach (var r in results)
                Console.WriteLine($"ID: {r.Id}, Назва: {r.Title}, Тип: {r.GetType().Name}");
            break;

        case "5":
            Console.Write("Введіть ID контенту: ");
            if (int.TryParse(Console.ReadLine(), out int delId))
            {
                contentRepo.Delete(delId);
                contentRepo.Save();
                Console.WriteLine("Контент видалено.");
            }
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Невідома команда.");
            break;
    }
}

string Ask(string message)
{
    Console.Write($"{message}: ");
    return Console.ReadLine() ?? "";
}
