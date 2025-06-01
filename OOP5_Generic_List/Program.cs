/*
 * Sử dụng Generic List để quản lý nhân sự với đầy đủ
 * Tính năng CRUD
 * C->CREATE --> Tạo mới dữ liệu
 * R->Read/Retrieve ->Xem, lọc, tìm kiếm, sắp xếp, thống kê...
 * U->Update --> sửa dữ liệu
 * D->DELETE--> xóa dữ liệu
 */
//Câu 1: Tạo 5 nhân viên, 3 nhân viên chính thức, 2 thời vụ
//lưu vào Generic List:
using OOP2;
using System.Text;

List<Employee> employees = new List<Employee>();
FulltimeEmployee fe1 = new FulltimeEmployee()
{
    Id = 1,
    IdCard = "123",
    Name = "Name 1",
    Birthday = new DateTime(1990, 1, 1),
};
employees.Add(fe1);
FulltimeEmployee fe2 = new FulltimeEmployee()
{
    Id = 2,
    IdCard = "456",
    Name = "Name 2",
    Birthday = new DateTime(1992, 11, 12),
};
employees.Add(fe2);
FulltimeEmployee fe3 = new FulltimeEmployee()
 {
     Id = 3,
     IdCard = "789",
     Name = "Name 3",
     Birthday = new DateTime(1980, 12, 27),
 };
employees.Add(fe3);
ParttimeEmployee pe1 = new ParttimeEmployee()
{
    Id = 4,
    IdCard = "234",
    Name = "Name 4",
    Birthday = new DateTime(1973, 12, 15),
    WorkingHour=2
};
employees.Add(pe1);
ParttimeEmployee pe2 = new ParttimeEmployee()
{
    Id = 5,
    IdCard = "987",
    Name = "Name 5",
    Birthday = new DateTime(1974, 1, 16),
    WorkingHour=3
};
employees.Add(pe2);
Console.OutputEncoding=Encoding.UTF8;
//Câu 2: R->Xuất toàn bộ nhân sự:
Console.WriteLine("Câu 2: R->Xuất toàn bộ nhân sự:");
//cách 1:
employees.ForEach(e =>Console.WriteLine(e));

//Câu 3: R-> Lọc ra các nhân sự là chính thức:
List<FulltimeEmployee> fe_list = employees.OfType<FulltimeEmployee>().ToList();
Console.WriteLine("Câu 3: R-> Lọc ra các nhân sự là chính thức:");
foreach(FulltimeEmployee fe in fe_list)
    Console.WriteLine(fe);
//Câu 4: R-> Lọc ra các nhân sự là thời vụ:
List<ParttimeEmployee> emp = employees.OfType<ParttimeEmployee>().ToList();
Console.WriteLine("Câu 4: R-> Lọc ra các nhân sự là thời vụ:");
foreach(ParttimeEmployee fe in emp) Console.WriteLine(fe);
//Câu 5: Tổng lương nhân chính thức:
double fe_sum_salary = fe_list.Sum(e => e.calSalary());
Console.WriteLine("Câu 5: Tổng lương nhân chính thức:");
Console.WriteLine(fe_sum_salary);
//Câu 6: Tổng lương nhân viên thời vụ:
double pe_sum_salary=employees.OfType<ParttimeEmployee>().Sum(e => e.calSalary());
Console.WriteLine("Câu 6: Tổng lương nhân viên thời vụ:");
Console.WriteLine(pe_sum_salary);
//Câu 7: Xóa nhân viên trong List:
employees.Remove(pe2);
Console.WriteLine("Câu 7: Nhân viên sau khi xóa pe2:");
foreach(Employee fe in employees)
   Console.WriteLine(fe);
//Câu 8: Sửa thông tin nhân viên trong List:
Employee emp1 = employees.FirstOrDefault(e => e.Id == 3);
if(emp1 != null)
{
    emp1.Name = "New Name";
    emp1.Birthday = new DateTime(2000, 4, 3);
}
foreach (Employee fe in employees)
    Console.WriteLine(fe);
