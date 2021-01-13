using NgoQuyTruong.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NgoQuyTruong.GUI
{
    public partial class ThemLienLac : Form
    {
        public ThemLienLac()
        {
            InitializeComponent();
            loadcombobox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tengoi = txttengoi.Text;
            var email = txtemail.Text;
            var sodienthoai = txtsodt.Text;
            var diachi = txtdiachi.Text;
            var nhom = cbnhom.Text;
            System.Random rd = new Random();
            var lienlacmoi = new LIENLAC {
                MaLienLac = "LL" + rd.Next(1, 1000),
                TenGoi = tengoi,
                Email=email,
                SoDienThoai= 123,
                DiaChi=diachi,
                MaNhom=nhom
            };
            var db = new QLDANHBADBContext();
            db.LIENLACs.Add(lienlacmoi);
            db.SaveChanges();
            DialogResult = DialogResult.OK;

        }
        void loadcombobox()
        {
            var db = new QLDANHBADBContext();
            var cbbox = db.NHOMs.OrderBy(e => e.MaNhom).ToList();
            for (int i = 0; i < cbbox.Count; i++)
            {
                cbnhom.Items.Add(cbbox.ElementAt(i).MaNhom);
            }

        }
    }
}
