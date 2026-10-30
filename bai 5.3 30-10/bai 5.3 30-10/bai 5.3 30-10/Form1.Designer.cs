namespace CafePOS
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.flpBanAn = new System.Windows.Forms.FlowLayoutPanel();
            this.grpOrder = new System.Windows.Forms.GroupBox();
            this.btnDoiBan = new System.Windows.Forms.Button();
            this.cboBanDich = new System.Windows.Forms.ComboBox();
            this.lblDoiBan = new System.Windows.Forms.Label();
            this.nmSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.cboMonAn = new System.Windows.Forms.ComboBox();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblMonAn = new System.Windows.Forms.Label();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.pnlThanhToan = new System.Windows.Forms.Panel();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblBanHienTai = new System.Windows.Forms.Label();
            this.btnQuanLyMenu = new System.Windows.Forms.Button();
            this.grpOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.pnlThanhToan.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpBanAn
            // 
            this.flpBanAn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpBanAn.AutoScroll = true;
            this.flpBanAn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpBanAn.Location = new System.Drawing.Point(12, 53);
            this.flpBanAn.Name = "flpBanAn";
            this.flpBanAn.Padding = new System.Windows.Forms.Padding(5);
            this.flpBanAn.Size = new System.Drawing.Size(430, 530);
            this.flpBanAn.TabIndex = 0;
            // 
            // grpOrder
            // 
            this.grpOrder.Controls.Add(this.btnDoiBan);
            this.grpOrder.Controls.Add(this.cboBanDich);
            this.grpOrder.Controls.Add(this.lblDoiBan);
            this.grpOrder.Controls.Add(this.nmSoLuong);
            this.grpOrder.Controls.Add(this.btnThemMon);
            this.grpOrder.Controls.Add(this.cboMonAn);
            this.grpOrder.Controls.Add(this.cboDanhMuc);
            this.grpOrder.Controls.Add(this.lblMonAn);
            this.grpOrder.Controls.Add(this.lblDanhMuc);
            this.grpOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOrder.Location = new System.Drawing.Point(455, 53);
            this.grpOrder.Name = "grpOrder";
            this.grpOrder.Size = new System.Drawing.Size(517, 120);
            this.grpOrder.TabIndex = 1;
            this.grpOrder.TabStop = false;
            this.grpOrder.Text = "Gọi món & Đổi bàn";
            // 
            // btnDoiBan
            // 
            this.btnDoiBan.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDoiBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiBan.Location = new System.Drawing.Point(423, 76);
            this.btnDoiBan.Name = "btnDoiBan";
            this.btnDoiBan.Size = new System.Drawing.Size(85, 27);
            this.btnDoiBan.TabIndex = 8;
            this.btnDoiBan.Text = "Đổi bàn";
            this.btnDoiBan.UseVisualStyleBackColor = false;
            this.btnDoiBan.Click += new System.EventHandler(this.btnDoiBan_Click);
            // 
            // cboBanDich
            // 
            this.cboBanDich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanDich.FormattingEnabled = true;
            this.cboBanDich.Location = new System.Drawing.Point(292, 78);
            this.cboBanDich.Name = "cboBanDich";
            this.cboBanDich.Size = new System.Drawing.Size(125, 23);
            this.cboBanDich.TabIndex = 7;
            // 
            // lblDoiBan
            // 
            this.lblDoiBan.AutoSize = true;
            this.lblDoiBan.Location = new System.Drawing.Point(230, 82);
            this.lblDoiBan.Name = "lblDoiBan";
            this.lblDoiBan.Size = new System.Drawing.Size(56, 15);
            this.lblDoiBan.TabIndex = 6;
            this.lblDoiBan.Text = "Bàn đích:";
            // 
            // nmSoLuong
            // 
            this.nmSoLuong.Location = new System.Drawing.Point(347, 30);
            this.nmSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmSoLuong.Name = "nmSoLuong";
            this.nmSoLuong.Size = new System.Drawing.Size(50, 23);
            this.nmSoLuong.TabIndex = 5;
            this.nmSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThemMon
            // 
            this.btnThemMon.BackColor = System.Drawing.Color.SandyBrown;
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMon.Location = new System.Drawing.Point(403, 20);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(105, 41);
            this.btnThemMon.TabIndex = 4;
            this.btnThemMon.Text = "+ Thêm món";
            this.btnThemMon.UseVisualStyleBackColor = false;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // cboMonAn
            // 
            this.cboMonAn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonAn.FormattingEnabled = true;
            this.cboMonAn.Location = new System.Drawing.Point(82, 52);
            this.cboMonAn.Name = "cboMonAn";
            this.cboMonAn.Size = new System.Drawing.Size(240, 23);
            this.cboMonAn.TabIndex = 3;
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(82, 23);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(240, 23);
            this.cboDanhMuc.TabIndex = 2;
            this.cboDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboDanhMuc_SelectedIndexChanged);
            // 
            // lblMonAn
            // 
            this.lblMonAn.AutoSize = true;
            this.lblMonAn.Location = new System.Drawing.Point(12, 55);
            this.lblMonAn.Name = "lblMonAn";
            this.lblMonAn.Size = new System.Drawing.Size(51, 15);
            this.lblMonAn.TabIndex = 1;
            this.lblMonAn.Text = "Món ăn:";
            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Location = new System.Drawing.Point(12, 26);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(65, 15);
            this.lblDanhMuc.TabIndex = 0;
            this.lblDanhMuc.Text = "Danh mục:";
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.AllowUserToAddRows = false;
            this.dgvChiTietHoaDon.AllowUserToDeleteRows = false;
            this.dgvChiTietHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTietHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(455, 179);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.ReadOnly = true;
            this.dgvChiTietHoaDon.RowHeadersVisible = false;
            this.dgvChiTietHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(517, 330);
            this.dgvChiTietHoaDon.TabIndex = 2;
            // 
            // pnlThanhToan
            // 
            this.pnlThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlThanhToan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThanhToan.Controls.Add(this.btnThanhToan);
            this.pnlThanhToan.Controls.Add(this.txtTongTien);
            this.pnlThanhToan.Controls.Add(this.lblTongTien);
            this.pnlThanhToan.Location = new System.Drawing.Point(455, 515);
            this.pnlThanhToan.Name = "pnlThanhToan";
            this.pnlThanhToan.Size = new System.Drawing.Size(517, 68);
            this.pnlThanhToan.TabIndex = 3;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(347, 10);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(155, 45);
            this.btnThanhToan.TabIndex = 2;
            this.btnThanhToan.Text = "THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.ForeColor = System.Drawing.Color.Red;
            this.txtTongTien.Location = new System.Drawing.Point(120, 19);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(202, 29);
            this.txtTongTien.TabIndex = 1;
            this.txtTongTien.Text = "0 VNĐ";
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(23, 23);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(81, 20);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // lblBanHienTai
            // 
            this.lblBanHienTai.AutoSize = true;
            this.lblBanHienTai.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblBanHienTai.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblBanHienTai.Location = new System.Drawing.Point(12, 16);
            this.lblBanHienTai.Name = "lblBanHienTai";
            this.lblBanHienTai.Size = new System.Drawing.Size(232, 25);
            this.lblBanHienTai.TabIndex = 4;
            this.lblBanHienTai.Text = "Đang chọn: Chưa chọn bàn";
            // 
            // btnQuanLyMenu
            // 
            this.btnQuanLyMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuanLyMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyMenu.Location = new System.Drawing.Point(822, 12);
            this.btnQuanLyMenu.Name = "btnQuanLyMenu";
            this.btnQuanLyMenu.Size = new System.Drawing.Size(150, 35);
            this.btnQuanLyMenu.TabIndex = 5;
            this.btnQuanLyMenu.Text = "⚙ Quản lý Thực đơn";
            this.btnQuanLyMenu.UseVisualStyleBackColor = true;
            this.btnQuanLyMenu.Click += new System.EventHandler(this.btnQuanLyMenu_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 595);
            this.Controls.Add(this.btnQuanLyMenu);
            this.Controls.Add(this.lblBanHienTai);
            this.Controls.Add(this.pnlThanhToan);
            this.Controls.Add(this.dgvChiTietHoaDon);
            this.Controls.Add(this.grpOrder);
            this.Controls.Add(this.flpBanAn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Bán Cafe - POS System";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.grpOrder.ResumeLayout(false);
            this.grpOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.pnlThanhToan.ResumeLayout(false);
            this.pnlThanhToan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBanAn;
        private System.Windows.Forms.GroupBox grpOrder;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.ComboBox cboMonAn;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Label lblMonAn;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.NumericUpDown nmSoLuong;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
        private System.Windows.Forms.Panel pnlThanhToan;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblBanHienTai;
        private System.Windows.Forms.Button btnDoiBan;
        private System.Windows.Forms.ComboBox cboBanDich;
        private System.Windows.Forms.Label lblDoiBan;
        private System.Windows.Forms.Button btnQuanLyMenu;
    }
}