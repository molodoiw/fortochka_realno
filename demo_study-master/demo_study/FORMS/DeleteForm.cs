using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using demo_study.UTILS;
using demo_study.FORMS;

namespace demo_study.FORMS
{
    public partial class DeleteForm : ParentForm
    {
        private static string connStr = ConnectionString.connectionString;
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var productArticle = textBoxDeleteProduct.Text;

            bool DelResult = false;
            string queryDel = $"DELETE FROM [Product] WHERE ProductArticleNumber = '{productArticle}'";

            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand com = new SqlCommand(queryDel, con);
                try
                {
                    con.Open();
                    if (com.ExecuteNonQuery() == 1)
                    {
                        DelResult = true;
                        MessageBox.Show("Удаление прошло успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Артикул введен неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch
                {
                }
            }

            this.Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

        

