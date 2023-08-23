using Lecture18;
using Lecture18.Dynamic;
using Lecture18.Shop;

//var publisher = new Publisher();
//var subscriber = new Subscriber();

//publisher.TestEvent += subscriber.EventHandler;

//publisher.RaiseEvent("AAAA");

//Clock clock = new Clock();
//Log log = new Log();

//clock.SecondsChanged += log.LogTime;

//clock.Run();

// Second example
//var items = new List<Item>()
//{
//    new Item() { Id = 1, Name = "Test", Price = 44 },
//    new Item() { Id = 2, Name = "2", Price = 22 }
//};
//var shop = new TechShop() { ItemsToSell = items };

//var f = items.ToList();
//f.Add(new Item() { Id = 3, Name = "taeta", Price = 33 });
//var warehouse = new Warehouse() { StoredItems = f };
//shop.ItemSold += warehouse.RemoveStoredItem;
//var user = new User() { Cart = new Cart() { CartItems = items } };

//shop.SellItems(user);

//Console.ReadKey();
// Third example
//var test = new { Name = "Jondo", LastName = "Bondo" };
//var jsonReader = new JsonReader();
//jsonReader.WriteJson("test.txt", test);
//var json = jsonReader.ReadJson("test.txt");

//if (json is null)
//    return;

//Console.WriteLine(json.Name);
//Console.WriteLine(json.LastName);
//Console.WriteLine(json.GetAge());
//json.Sing();

//var items = new List<Item>() { new Item() { Name = "1" }, new Item() { Name = "2" } };
//var dynamicList = new List<dynamic>();
//foreach (var item in items)
//{
//    var testx = new { item.Name, item.Id };
//    var type = testx.GetType();
//    Console.WriteLine(type.Name);
//    dynamicList.Add(testx);
//}

//foreach (var item in dynamicList)
//{
//    Console.WriteLine(item.Name);
//    Console.WriteLine(item.Id);
//}

//var impTypedArray = new[] { new { Test = "A" }, new { Test = "f" } };

//foreach (var item in impTypedArray)
//{
//    Console.WriteLine(item.Test);
//}

var publisher = new Publisher();

//publisher.TestEvent += string (string message) =>
//{
//    Console.WriteLine(message);
//    return message;
//};

//publisher.TestEvent += delegate (string message)
//{
//    return "test";
//};

publisher.RaiseEvent("test");

Console.WriteLine("Something");