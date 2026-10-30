using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CafePOS
{
    public partial class FormQuanLyMon : Form
    {
        public FormQuanLyMon()
        {
            InitializeComponent();
        }

        private void FormQuanLyMon_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            LoadDanhSachMon();
        }

        private void LoadDanhMuc()
        {
            using (SqlConnection conn = DBConnect.GetConnection())
            {
                string query = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboDanhMuc.DataSource = dt;
                cboDanhMuc.DisplayMember = "TenDanhMuc";
                cboDanhMuc.ValueMember = "MaDanhMuc";
            }
        }

        private void LoadDanhSachMon()
        {
            using (SqlConnection conn = DBConnect.GetConnection())
            {
                string query = @"
                    SELECT m.MaMon AS [Mã Món], 
                           m.TenMon AS [Tên Món], 
                           d.TenDanhMuc AS [Danh Mục], 
                           m.DonGia AS [Đơn Giá],
                           m.MaDanhMuc
                    FROM MonAn m
                    JOIN DanhMuc d ON m.MaDanhMuc = d.MaDanhMuc";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvMonAn.DataSource = dt;
                // Ẩn cột MaDanhMuc (dùng nội bộ)
                if (dgvMonAn.Columns.Contains("MaDanhMuc"))
                {
                    dgvMonAn.Columns["MaDanhMuc"].Visible = false;
                }
                dgvMonAn.Columns["Đơn Giá"].DefaultCellStyle.Format = "N0";
            }
        }

        // Kiểm tra hợp lệ dữ liệu (Validation)
        private bool ValidateInput(out string tenMon, out decimal donGia)
        {
            tenMon = txtTenMon.Text.Trim();
            donGia = 0;

            if (string.IsNullOrEmpty(tenMon))
            {
                MessageBox.Show("Tên món không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMon.Focus();
                return false;
            }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia))
            {
                MessageBox.Show("Đơn giá phải là một số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return false;
            }

            if (donGia < 0)
            {
                MessageBox.Show("Đơn giá không được phép là số âm!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out string tenMon, out decimal donGia)) return;

            int maDanhMuc = Convert.ToInt32(cboDanhMuc.SelectedValue);

            using (SqlConnection conn = DBConnect.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia) VALUES (@TenMon, @MaDM, @DonGia)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenMon", tenMon);
                cmd.Parameters.AddWithValue("@MaDM", maDanhMuc);
                cmd.Parameters.AddWithValue("@DonGia", donGia);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadDanhSachMon();
            ResetForm();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaMon.Text))
            {
                MessageBox.Show("Vui lòng chọn món ăn cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(out string tenMon, out decimal donGia)) return;

            int maMon = Convert.ToInt32(txtMaMon.Text);
            int maDanhMuc = Convert.ToInt32(cboDanhMuc.SelectedValue);

            using (SqlConnection conn = DBConnect.GetConnection())
            {
                conn.Open();
                string query = "UPDATE MonAn SET TenMon = @TenMon, MaDanhMuc = @MaDM, DonGia = @DonGia WHERE MaMon = @MaMon";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenMon", tenMon);
                cmd.Parameters.AddWithValue("@MaDM", maDanhMuc);
                cmd.Parameters.AddWithValue("@DonGia", donGia);
                cmd.Parameters.AddWithValue("@MaMon", maMon);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadDanhSachMon();
            ResetForm();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaMon.Text))
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa món này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int maMon = Convert.ToInt32(txtMaMon.Text);

                using (SqlConnection conn = DBConnect.GetConnection())
                {
                    conn.Open();
                    try
                    {
                        string query = "DELETE FROM MonAn WHERE MaMon = @MaMon";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaMon", maMon);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Xóa món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể xóa món này vì đã có hóa đơn sử dụng!\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoadDanhSachMon();
                ResetForm();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtDonGia.Clear();
            if (cboDanhMuc.Items.Count > 0) cboDanhMuc.SelectedIndex = 0;
            txtTenMon.Focus();
        }

        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMonAn.Rows[e.RowIndex];
                txtMaMon.Text = row.Cells["Mã Món"].Value.ToString();
                txtTenMon.Text = row.Cells["Tên Món"].Value.ToString();
                txtDonGia.Text = Convert.ToDecimal(row.Cells["Đơn Giá"].Value).ToString("0.##");
                cboDanhMuc.SelectedValue = row.Cells["MaDanhMuc"].Value;
            }
        }
    }
}