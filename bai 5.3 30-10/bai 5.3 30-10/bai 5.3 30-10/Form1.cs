using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CafePOS
{
    public partial class FormMain : Form
    {
        private int currentMaBan = -1;
        private string currentTenBan = "";
        private decimal tongTienHienTai = 0;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadBanAn();
            LoadDanhMuc();
            LoadDanhSachBanDoi();
        }

        #region 1. Sơ đồ bàn động
        public void LoadBanAn()
        {
            flpBanAn.Controls.Clear();

            using (SqlConnection conn = DBConnect.GetConnection())
            {
                string query = "SELECT MaBan, TenBan, TrangThai FROM BanAn";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dtBan = new DataTable();
                da.Fill(dtBan);

                foreach (DataRow row in dtBan.Rows)
                {
                    Button btn = new Button();
                    btn.Width = 95;
                    btn.Height = 95;
                    btn.Margin = new Padding(5);
                    btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

                    int maBan = Convert.ToInt32(row["MaBan"]);
                    string tenBan = row["TenBan"]?.ToString() ?? "";
                    string trangThai = row["TrangThai"]?.ToString() ?? "Trống";

                    btn.Text = $"{tenBan}\n({trangThai})";
                    btn.Tag = maBan;

                    if (trangThai == "Trống")
                    {
                        btn.BackColor = Color.LightGreen;
                        btn.ForeColor = Color.Black;
                    }
                    else
                    {
                        btn.BackColor = Color.Salmon;
                        btn.ForeColor = Color.White;
                    }

                    btn.Click += BtnBan_Click;
                    flpBanAn.Controls.Add(btn);
                }
            }
        }

        private void BtnBan_Click(object? sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn != null && btn.Tag != null)
            {
                currentMaBan = (int)btn.Tag;
                currentTenBan = btn.Text.Split('\n')[0];
                lblBanHienTai.Text = $"Đang chọn: {currentTenBan}";

                LoadHoaDonCuaBan(currentMaBan);
            }
        }
        #endregion

        #region 2. Nạp Thực Đơn & Danh Mục
        private void LoadDanhMuc()
        {
            using (SqlConnection conn = DBConnect.GetConnection())
            {
                string query = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboDanhMuc.DisplayMember = "TenDanhMuc";
                cboDanhMuc.ValueMember = "MaDanhMuc";
                cboDanhMuc.DataSource = dt;

                if (cboDanhMuc.SelectedValue != null && int.TryParse(cboDanhMuc.SelectedValue.ToString(), out int maDM))
                {
                    LoadMonAnTheoDanhMuc(maDM);
                }
            }
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDanhMuc.SelectedValue != null && int.TryParse(cboDanhMuc.SelectedValue.ToString(), out int maDM))
            {
                LoadMonAnTheoDanhMuc(maDM);
            }
        }

        private void LoadMonAnTheoDanhMuc(int maDanhMuc)
        {
            using (SqlConnection conn = DBConnect.GetConnection())
            {
                string query = "SELECT MaMon, TenMon, DonGia FROM MonAn WHERE MaDanhMuc = @MaDM";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDM", maDanhMuc);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMonAn.DisplayMember = "TenMon";
                cboMonAn.ValueMember = "MaMon";
                cboMonAn.DataSource = dt;
            }
        }

        private void LoadDanhSachBanDoi()
        {
            using (SqlConnection conn = DBConnect.GetConnection())
            {
                string query = "SELECT MaBan, TenBan FROM BanAn";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboBanDich.DisplayMember = "TenBan";
                cboBanDich.ValueMember = "MaBan";
                cboBanDich.DataSource = dt;
            }
        }
        #endregion

        #region 3. Hóa Đơn & Chi Tiết
        private int GetUncheckBillIDByTableID(int maBan)
        {
            using (SqlConnection conn = DBConnect.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaHoaDon FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = 0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaBan", maBan);

                object? result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                return -1;
            }
        }

        private void LoadHoaDonCuaBan(int maBan)
        {
            int maHoaDon = GetUncheckBillIDByTableID(maBan);

            using (SqlConnection conn = DBConnect.GetConnection())
            {
                string query = @"
                    SELECT m.TenMon AS [Tên Món], 
                           ct.SoLuong AS [Số Lượng], 
                           ct.DonGia AS [Đơn Giá], 
                           (ct.SoLuong * ct.DonGia) AS [Thành Tiền]
                    FROM ChiTietHoaDon ct
                    JOIN MonAn m ON ct.MaMon = m.MaMon
                    WHERE ct.MaHoaDon = @MaHoaDon";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvChiTietHoaDon.DataSource = dt;

                if (dgvChiTietHoaDon.Columns.Count > 0)
                {
                    dgvChiTietHoaDon.Columns["Đơn Giá"].DefaultCellStyle.Format = "N0";
                    dgvChiTietHoaDon.Columns["Thành Tiền"].DefaultCellStyle.Format = "N0";
                }

                tongTienHienTai = 0;
                foreach (DataRow row in dt.Rows)
                {
                    tongTienHienTai += Convert.ToDecimal(row["Thành Tiền"]);
                }

                CultureInfo culture = new CultureInfo("vi-VN");
                txtTongTien.Text = tongTienHienTai.ToString("c0", culture);
            }
        }
        #endregion

        #region 4. Gọi món
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (currentMaBan == -1)
            {
                MessageBox.Show("Vui lòng click chọn 1 bàn trước khi gọi món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMonAn.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maMon = Convert.ToInt32(cboMonAn.SelectedValue);
            int soLuong = (int)nmSoLuong.Value;

            using (SqlConnection conn = DBConnect.GetConnection())
            {
                conn.Open();

                string sqlGia = "SELECT DonGia FROM MonAn WHERE MaMon = @MaMon";
                SqlCommand cmdGia = new SqlCommand(sqlGia, conn);
                cmdGia.Parameters.AddWithValue("@MaMon", maMon);
                decimal donGia = Convert.ToDecimal(cmdGia.ExecuteScalar());

                int maHoaDon = GetUncheckBillIDByTableID(currentMaBan);

                if (maHoaDon == -1)
                {
                    string sqlTaoHoaDon = @"
                        INSERT INTO HoaDon (MaBan, GioVao, TrangThai) 
                        VALUES (@MaBan, GETDATE(), 0);
                        SELECT SCOPE_IDENTITY();
                        
                        UPDATE BanAn SET TrangThai = N'Có khách' WHERE MaBan = @MaBan;";

                    SqlCommand cmdTaoHD = new SqlCommand(sqlTaoHoaDon, conn);
                    cmdTaoHD.Parameters.AddWithValue("@MaBan", currentMaBan);
                    maHoaDon = Convert.ToInt32(cmdTaoHD.ExecuteScalar());
                }

                string sqlCheck = "SELECT SoLuong FROM ChiTietHoaDon WHERE MaHoaDon = @MaHD AND MaMon = @MaMon";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@MaHD", maHoaDon);
                cmdCheck.Parameters.AddWithValue("@MaMon", maMon);
                object? objSL = cmdCheck.ExecuteScalar();

                if (objSL != null)
                {
                    string sqlUpdateCT = @"
                        UPDATE ChiTietHoaDon 
                        SET SoLuong = SoLuong + @SoLuong, DonGia = @DonGia 
                        WHERE MaHoaDon = @MaHD AND MaMon = @MaMon";
                    SqlCommand cmdUpdateCT = new SqlCommand(sqlUpdateCT, conn);
                    cmdUpdateCT.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmdUpdateCT.Parameters.AddWithValue("@DonGia", donGia);
                    cmdUpdateCT.Parameters.AddWithValue("@MaHD", maHoaDon);
                    cmdUpdateCT.Parameters.AddWithValue("@MaMon", maMon);
                    cmdUpdateCT.ExecuteNonQuery();
                }
                else
                {
                    string sqlInsertCT = @"
                        INSERT INTO ChiTietHoaDon (MaHoaDon, MaMon, SoLuong, DonGia)
                        VALUES (@MaHD, @MaMon, @SoLuong, @DonGia)";
                    SqlCommand cmdInsertCT = new SqlCommand(sqlInsertCT, conn);
                    cmdInsertCT.Parameters.AddWithValue("@MaHD", maHoaDon);
                    cmdInsertCT.Parameters.AddWithValue("@MaMon", maMon);
                    cmdInsertCT.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmdInsertCT.Parameters.AddWithValue("@DonGia", donGia);
                    cmdInsertCT.ExecuteNonQuery();
                }
            }

            LoadBanAn();
            LoadHoaDonCuaBan(currentMaBan);
            nmSoLuong.Value = 1;
        }
        #endregion

        #region 5. Đổi bàn
        private void btnDoiBan_Click(object sender, EventArgs e)
        {
            if (currentMaBan == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idHoaDonHienTai = GetUncheckBillIDByTableID(currentMaBan);
            if (idHoaDonHienTai == -1)
            {
                MessageBox.Show("Bàn này hiện không có hóa đơn để đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maBanDich = Convert.ToInt32(cboBanDich.SelectedValue);
            if (maBanDich == currentMaBan)
            {
                MessageBox.Show("Bàn đích phải khác bàn hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idHoaDonBanDich = GetUncheckBillIDByTableID(maBanDich);

            using (SqlConnection conn = DBConnect.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    if (idHoaDonBanDich == -1)
                    {
                        string sql = @"
                            UPDATE HoaDon SET MaBan = @MaBanDich WHERE MaHoaDon = @MaHD;
                            UPDATE BanAn SET TrangThai = N'Có khách' WHERE MaBan = @MaBanDich;
                            UPDATE BanAn SET TrangThai = N'Trống' WHERE MaBan = @MaBanNguon;";

                        SqlCommand cmd = new SqlCommand(sql, conn, trans);
                        cmd.Parameters.AddWithValue("@MaBanDich", maBanDich);
                        cmd.Parameters.AddWithValue("@MaBanNguon", currentMaBan);
                        cmd.Parameters.AddWithValue("@MaHD", idHoaDonHienTai);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string sqlGop = @"
                            UPDATE ctDich
                            SET ctDich.SoLuong = ctDich.SoLuong + ctNguon.SoLuong
                            FROM ChiTietHoaDon ctDich
                            JOIN ChiTietHoaDon ctNguon ON ctDich.MaMon = ctNguon.MaMon
                            WHERE ctDich.MaHoaDon = @MaHDDich AND ctNguon.MaHoaDon = @MaHDNguon;

                            INSERT INTO ChiTietHoaDon (MaHoaDon, MaMon, SoLuong, DonGia)
                            SELECT @MaHDDich, MaMon, SoLuong, DonGia 
                            FROM ChiTietHoaDon 
                            WHERE MaHoaDon = @MaHDNguon 
                              AND MaMon NOT IN (SELECT MaMon FROM ChiTietHoaDon WHERE MaHoaDon = @MaHDDich);

                            DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHDNguon;
                            DELETE FROM HoaDon WHERE MaHoaDon = @MaHDNguon;

                            UPDATE BanAn SET TrangThai = N'Trống' WHERE MaBan = @MaBanNguon;";

                        SqlCommand cmdGop = new SqlCommand(sqlGop, conn, trans);
                        cmdGop.Parameters.AddWithValue("@MaHDDich", idHoaDonBanDich);
                        cmdGop.Parameters.AddWithValue("@MaHDNguon", idHoaDonHienTai);
                        cmdGop.Parameters.AddWithValue("@MaBanNguon", currentMaBan);
                        cmdGop.ExecuteNonQuery();
                    }

                    trans.Commit();
                    MessageBox.Show("Chuyển bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    currentMaBan = maBanDich;
                    lblBanHienTai.Text = $"Đang chọn: {cboBanDich.Text}";
                    LoadBanAn();
                    LoadHoaDonCuaBan(currentMaBan);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi khi chuyển bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region 6. Thanh toán
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (currentMaBan == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHoaDon = GetUncheckBillIDByTableID(currentMaBan);
            if (maHoaDon == -1)
            {
                MessageBox.Show("Bàn này hiện không có hóa đơn để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"Xác nhận thanh toán cho {currentTenBan}?\nTổng số tiền: {txtTongTien.Text}",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = DBConnect.GetConnection())
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string sqlUpdateHoaDon = @"
                            UPDATE HoaDon 
                            SET GioRa = GETDATE(), 
                                TongTien = @TongTien, 
                                TrangThai = 1 
                            WHERE MaHoaDon = @MaHD";

                        SqlCommand cmdHD = new SqlCommand(sqlUpdateHoaDon, conn, transaction);
                        cmdHD.Parameters.AddWithValue("@TongTien", tongTienHienTai);
                        cmdHD.Parameters.AddWithValue("@MaHD", maHoaDon);
                        cmdHD.ExecuteNonQuery();

                        string sqlUpdateBan = "UPDATE BanAn SET TrangThai = N'Trống' WHERE MaBan = @MaBan";
                        SqlCommand cmdBan = new SqlCommand(sqlUpdateBan, conn, transaction);
                        cmdBan.Parameters.AddWithValue("@MaBan", currentMaBan);
                        cmdBan.ExecuteNonQuery();

                        transaction.Commit();

                        MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadBanAn();
                        LoadHoaDonCuaBan(currentMaBan);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        private void btnQuanLyMenu_Click(object sender, EventArgs e)
        {
            FormQuanLyMon f = new FormQuanLyMon();
            f.ShowDialog();

            LoadDanhMuc();
            if (currentMaBan != -1)
            {
                LoadHoaDonCuaBan(currentMaBan);
            }
        }
    }
}