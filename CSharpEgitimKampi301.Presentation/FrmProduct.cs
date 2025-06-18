using CSharpEgitimKampi301.BusinnessLayer.Abstract;
using CSharpEgitimKampi301.BusinnessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.Presentation
{
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public FrmProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values = _categoryService.TGetAll();
            cmbCategory.DataSource = values;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetAll();
            dataGridView1.DataSource = values;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductsWithCategory();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ProductStock = int.Parse(txtProductStock.Text);
            product.ProductName = txtProductName.Text;
            product.ProductDescription = rTxtDescription.Text;
            product.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            _productService.TInsert(product);
            MessageBox.Show("Ekleme işlemi yapıldı...");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var deletedValues = _productService.TGetById(id);
            _productService.TDelete(deletedValues);
            MessageBox.Show("Silme işlemi başarılı...");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var updatedValue = _productService.TGetById(id);
            updatedValue.ProductDescription = rTxtDescription.Text;
            updatedValue.ProductStock= int.Parse(txtProductStock.Text);
            updatedValue.ProductName = txtProductName.Text;
            updatedValue.ProductPrice = int.Parse(txtProductPrice.Text);
            updatedValue.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());

            _productService.TUpdate(updatedValue);
            MessageBox.Show("Ürün başarıyla güncellendi...");
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {

        }
    }
}
