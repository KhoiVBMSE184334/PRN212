using OOP6_Dictionary;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Category c1 = new Category();
c1.Id = 1;
c1.Name = "Nuoc thanh";
Product p1 = new Product();
p1.Id = 1;
p1.Name = "Pepsi";
p1.Quantity = 10;
p1.Price = 30;
c1.AddProduct(p1);

Product p2 = new Product();
p2.Id = 2;
p2.Name = "Coca";
p2.Quantity = 10;
p2.Price = 34;
c1.AddProduct(p2);

Product p3 = new Product();
p3.Id = 3;
p3.Name = "Number1";
p3.Quantity = 10;
p3.Price = 46;
c1.AddProduct(p3);

Product p4 = new Product();
p4.Id = 4;
p4.Name = "Sting";
p4.Quantity = 10;
p4.Price = 12;
c1.AddProduct(p4);

Product p5 = new Product();
p5.Id = 5;
p5.Name = "7 Up";
p5.Quantity = 10;
p5.Price = 24;
c1.AddProduct(p5);

Console.WriteLine("Thông tin danh mục");
Console.WriteLine(c1);
Console.WriteLine("Danh sách sản phẩm");
c1.PrintProduct();

double min_price = 10;
double max_price = 30;
Dictionary<int, Product>product_by_price = c1.FilterProductsByPrice(min_price, max_price);
Console.WriteLine($"Danh sach san pham co gia tri tu {min_price} toi {max_price}:");
foreach(KeyValuePair<int, Product>kvp in product_by_price)
{
    Product p = kvp.Value; 
    Console.WriteLine(p);
}

Dictionary<int, Product> sorted_products = c1.SortProductByPrice();
Console.WriteLine("Danh sach san pham sau khi sap xep gia tan dan");
foreach (KeyValuePair<int, Product> kvp in sorted_products)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

Dictionary<int, Product> sorted_complex_products = c1.SortComplex();
Console.WriteLine("Danh sach san pham sau khi sap xep gia tan dan");
foreach (KeyValuePair<int, Product> kvp in sorted_products)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

p5.Name = "Panta";
p5.Price = 80;
p5.Quantity = 17;
bool ret = c1.UpdateProduct(p5);
Console.WriteLine("San pham sau chinh sua");
c1.PrintProduct();

int id = 5;
ret = c1.RemoveProduct(id);
if(ret == false)
{
    Console.WriteLine($"Khon tim thay {id} de xoa");
}
else
{
    Console.WriteLine("San pham sau khi xoa");
    c1.PrintProduct();
}

int id1 = 3;
int id2 = 4;
ret = c1.RemoveComplex(id1, id2);
if (ret == false)
{
    Console.WriteLine($"Khon tim thay {id1} hoac {id2} de xoa");
}
else
{
    Console.WriteLine("San pham sau khi xoa");
    c1.PrintProduct();
}

LinkedList<Category> categories = new LinkedList<Category>();

Category c2 = new Category();
c2.Id = 2;
c2.Name = "Bia";

c2.AddProduct(new Product() { Id = 6, Name = "Tiger", Quantity = 10, Price = 300 });
c2.AddProduct(new Product() { Id = 7, Name = "333", Quantity = 20, Price = 250 }); 
c2.AddProduct(new Product() { Id = 8, Name = "Ken", Quantity = 15, Price = 500 });
categories.AddFirst(c2);
Console.WriteLine("Danh sach toan bo san pham theo danh muc");
foreach (Category c in categories)
{
    Console.WriteLine(c);
    Console.WriteLine("--------------------");
    c.PrintProduct();
    Console.WriteLine("--------------------");
}