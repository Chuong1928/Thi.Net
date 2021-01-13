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
    public partial class ThemNhom : Form
    {
        NHOM nhom;
        public ThemNhom()
        {
            InitializeComponent();
        }
      

        private void btndongy_Click(object sender, EventArgs e)
        {
            var tennhom = txttennhom.Text;
            System.Random rd = new Random();
            var nhommoi = new NHOM
            {
                MaNhom = "NHOM" + rd.Next(1, 1000),
                TenNhom = tennhom,
            };
            var db = new QLDANHBADBContext();
            db.NHOMs.Add(nhommoi);
            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
