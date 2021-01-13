using NgoQuyTruong.DAL;
using NgoQuyTruong.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NgoQuyTruong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            datanhom.AutoGenerateColumns = false;
            datalienlac.AutoGenerateColumns = false;
            LoadDanhSachNhom();
        }
        void LoadDanhSachNhom()
        {
            QLDANHBADBContext db = new QLDANHBADBContext();
            var ds = db.NHOMs.OrderBy(e => e.TenNhom).ToList();
            bdsnhom.DataSource = ds;
            datanhom.DataSource = bdsnhom;
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            var f = new ThemNhom();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachNhom();
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            var nhomdangchon = bdsnhom.Current as NHOM;
            if (nhomdangchon != null)
            {
                //xoa nhom dang chon
                var mess = MessageBox.Show("Bạn có muốn xóa Nhóm này không?", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (mess == DialogResult.OK)
                {
                    QLDANHBADBContext db = new QLDANHBADBContext();
                    var nhom_xoa = db.NHOMs.Where(t => t.MaNhom == nhomdangchon.MaNhom).FirstOrDefault();
                    if (nhom_xoa != null)
                    {
                        db.NHOMs.Remove(nhom_xoa);
                        db.SaveChanges();
                        LoadDanhSachNhom();
                    }
                }
            }
        }

        private void bdsnhom_CurrentChanged(object sender, EventArgs e)
        {
            var nhomdangchon = bdsnhom.Current as NHOM;
            if (nhomdangchon != null)
            {
                var db = new QLDANHBADBContext();
                var dslienlac = db.LIENLACs.Where(t => t.MaNhom == nhomdangchon.MaNhom).ToList();
                bdslienlac.DataSource = dslienlac;
                datalienlac.DataSource = bdslienlac;
            }
        }

        private void datalienlac_Click(object sender, EventArgs e)
        {
            var lienlacdangchon = bdslienlac.Current as LIENLAC;
            texttengoi.Text = lienlacdangchon.TenGoi;
            textEmail.Text = lienlacdangchon.Email;
            textDiaChi.Text = lienlacdangchon.DiaChi;
            textSDT.Text = "11111";

        }

        private void datalienlac_SelectionChanged(object sender, EventArgs e)
        {
          
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            var f = new ThemLienLac();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachNhom();
            }
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            var lienlacdangchon = bdslienlac.Current as LIENLAC;
            if (lienlacdangchon != null)
            {
                var mess = MessageBox.Show("Bạn có thật sự muốn xóa không ?", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (mess == DialogResult.OK)
                {
                    QLDANHBADBContext db = new QLDANHBADBContext();
                    var lienlac_xoa = db.LIENLACs.Where(t => t.MaLienLac == lienlacdangchon.MaLienLac).FirstOrDefault();
                    if (lienlac_xoa != null)
                    {
                        db.LIENLACs.Remove(lienlac_xoa);
                        db.SaveChanges();
                        LoadDanhSachNhom();
                    }
                }
            }
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                var keyword = txttimkiem.Text;
                var db =new  QLDANHBADBContext();
                 var ds= db.LIENLACs.Where(t => t.TenGoi.Contains(keyword)).ToList();
              //  var ds2 = db.NHOMs.Where(t => t.MaNhom.Contains(keyword)).ToList();
                datalienlac.DataSource = ds;
               // datanhom.DataSource = ds2;
            }
        }
    }
}
