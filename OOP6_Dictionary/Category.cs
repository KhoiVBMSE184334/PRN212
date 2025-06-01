using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6_Dictionary
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, Product> Products { get; set; }
        public Category() 
        { 
            Products = new Dictionary<int, Product>();
        }
        public override string ToString()
        {
            return $"{Id}\t{Name}";

        }
        /*Khi quản lý đối tượng ta đều phải đáp ứng đầy đủ tính năng CRUD*/
        public void AddProduct(Product p)
        {
            //Kiểm tra nếu Id cỉa Product chưa tồn tại, thì thêm mới
            if(p == null)
            {
                return;//Dữ liệu đầu vào null
            }
            if (Products.ContainsKey(p.Id))
            {
                return;//Id đã tồn tại ko thêm
            }
            //Thêm mới vào 
            Products.Add(p.Id, p);
        }
        //Xuất toàn bộ sản phẩm
        public void PrintProduct()
        {
            foreach(KeyValuePair<int, Product> kvp in Products)
            {
                Product p = kvp.Value;
                Console.WriteLine(p);
            }
        }
        // Lọc các sản phẩm có giá từ min tới max
        public Dictionary<int, Product> FilterProductsByPrice(double min, double max)
        {
            return Products.Where(item => item.Value.Price >= min && item.Value.Price <= max).ToDictionary<int, Product>();
        }
        // Sắp xếp sản phẩm theo đơn giá tăng dần
        public Dictionary<int, Product> SortProductByPrice()
        {
            return Products.OrderBy(item => item.Value.Price).ToDictionary<int, Product>();
        }

        public Dictionary<int, Product> SortComplex()
        {
            return Products.OrderByDescending(item => item.Value.Quantity).OrderBy(item => item.Value.Price).ToDictionary<int, Product>();
        }

        public bool UpdateProduct(Product p)
        {
            if (p == null)
            {
                return false;
            }
            if(!Products.ContainsKey(p.Id) == false)
            {
                return false;
            }
            Products[p.Id] = p;
            return true;
        }
        public bool RemoveProduct(int id)
        {
            if(Products.ContainsKey(id) == false)
            {
                return false;
            }
            Products.Remove(id);
            return true;
        }

        public bool RemoveComplex(int id1, int id2)
        {
            var keysToRemove = Products
                .Where(pair => pair.Value.Id >= id1 && pair.Value.Id <= id2)
                .Select(pair => pair.Key)
                .ToList();

            if (keysToRemove.Count == 0)
            {
                return false;
            }

            foreach (var key in keysToRemove)
            {
                Products.Remove(key);
            }

            return true;
        }

    }
}
