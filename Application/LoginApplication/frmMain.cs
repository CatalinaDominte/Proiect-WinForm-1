

using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace LoginApplication
{
    public partial class frmMain : Form
    {
        Product products = new Product();
      
        private DBEntities Db;
       
        public frmMain()
        {
            InitializeComponent();
            Db = new DBEntities();
                
                var types = Db.Categories.ToList<Category>();
                foreach (var item in types)
                {

                    comboBox.Items.Add(item.CategoryName);
               

                 }

            
           
            

        }

        //btn_LogOut Click Event
        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin fl = new frmLogin();
            fl.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            populateDataGridView();

            Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sureyou wont to delete this product?","EF CRUDOperations", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                var entry = Db.Entry(products);
                if(entry.State==EntityState.Detached)
                {
                    Db.Products.Attach(products);
                   
                }
                Db.Products.Remove(products);
                Db.SaveChanges();
                populateDataGridView();
                Clear();
                MessageBox.Show("deleted successfully");
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Clear();

        }
        private void Clear()
        {
            txt_name.Text = string.Empty;
            comboBox.Text = "Plese select...";
            txt_price.Text = string.Empty;
            txt_units.Text = string.Empty;
            txt_description.Text = string.Empty;
            btn_save.Text = "Save";
            btn_delete.Enabled = false;
            

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
             
            
                products.Name = txt_name.Text.Trim();
                products.price = decimal.Parse(txt_price.Text.Trim());
                products.ProductsDescription = txt_description.Text.Trim();
                products.UnitsInStock = int.Parse(txt_units.Text.Trim());
                products.Category = comboBox.SelectedItem as Category;
               if(btn_save.Text =="Update")
                {
                    Db.Entry(products).State = EntityState.Modified;
                Db.SaveChanges();
                populateDataGridView();

            }
               else
                {
                    Db.Products.Add(products);
                Db.SaveChanges();
                populateDataGridView();
            }
                
               
               



             
            
            
            
                Clear();
           
            MessageBox.Show("Submitted Successfully");
            
        }
        public void populateDataGridView()
        {
            
            
                dataGridProduct.DataSource = Db.Products.ToList<Product>();
            
        }

        private void dataGridProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridProduct_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridProduct.CurrentRow.Index!=-1)
            {
                products.Id = Convert.ToInt32(dataGridProduct.CurrentRow.Cells["Id"].Value);
                
                
                    products = Db.Products.Where(x => x.Id == products.Id).FirstOrDefault();
                    txt_name.Text = products.Name;
                    txt_price.Text = products.price.ToString();
                    txt_description.Text = products.ProductsDescription;
                    txt_units.Text = products.UnitsInStock.ToString();
                    //comboBox.Text = products.CategoryId.ToString();

                
                btn_save.Text = "Update";
                btn_delete.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Chart ch = new Chart();
            ch.Show();
        }
    }
}
