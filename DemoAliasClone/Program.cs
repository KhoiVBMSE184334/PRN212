using DemoAliasClone;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Customer c1 = new Customer();
c1.Id = 1;
c1.Name = "Sinh Vien";
Customer c2 = new Customer();
c2.Id = 2;
c1.Name = "Tho Dien";

c1 = c2;
//c1 trỏ tới vùng nhớ mà c2 đang quản lý chứ ko phải c1 = c2 
//=> Lúc này xảy ra 2 tình huống 
//(1) Ô nhớ alpha mà c1 quản lý lúc nãy bị tróng ko còn đối tượng nào tham gia quản lý nữa
//=> Hệ điều hành sẽ thu hồi ô nhớ alpha này gọi là cơ chế gom rác tự động: Automatic Garbage collection
// Ta ko thể lấy giá trị tại ô nhớ này nữa
// (2) Lúc này ô nhớ Beta sẽ có 2 đối tượng tham gia quản lý
//- Đối tượng ban đầu là c2
//- Bây h thêm đối tượng c1 quản lý
//Trường hợp 1 ô nhớ từ 2 đối tượng trở nên tham gia quản lý nó đc gọi là Alias
//-> Bất kỳ 1 đối tượng nào đổi giá trị tại ô nhớ Beta => thì các đối tượng còn lại đều bị ảnh hưởng

c1.Name = "Ngu";
//thì lúc này c2 cũng bị đổi thành ngu vì c1 và c2 quản lý 1 ô nhớ 
