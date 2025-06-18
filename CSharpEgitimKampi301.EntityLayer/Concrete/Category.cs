using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    // eğer değişken bir metod içinde tanımlanmışsa buna variable deriz
    // eğer int x; şeklinde tanımlanmışsa bu field olur
    // eğer public int get set diye tanımlanırsa property olur

    public class Category
    {
        public int CategoryId { get; set; } // eğer primary key olmasını istiyorsan sınıf adıyla aynı olmalı ve de sonunda Id olmalı Category --> CategoryName
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public List<Product> Products { get; set; }
    }
}
