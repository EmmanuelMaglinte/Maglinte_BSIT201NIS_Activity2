using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lesson2Activity
{
    public partial class Form1 : Form
    {
        PictureBox pictureBox;
        Button btnBrowse, btnAdd, btnSubmit, btnNew;

        TextBox txtStudentName, txtStudentNumber, txtYearLevel, txtScholar;
        ComboBox cbProgram;
        DateTimePicker dtpEnrolled;

        TextBox txtCourseNumber, txtCourseCode, txtCourseDesc;
        TextBox txtUnitLec, txtUnitLab, txtTime, txtDay;

        DataGridView dgv;

        TextBox txtTotalUnits;
        TextBox txtLabFee, txtMiscFee, txtCiscoFee, txtExamFee;
        TextBox txtTuitionFee, txtTotalFees;

        const double TuitionPerUnit = 1500;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Lesson 2 Activity";
            this.Size = new Size(1100, 900);
            this.StartPosition = FormStartPosition.CenterScreen;

            
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(0, 900);

            // =======================
            // TITLE
            // =======================
            Label lblTitle = new Label()
            {
                Text = "Lesson 2 Activity",
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point((this.ClientSize.Width / 2) - 120, 10)
            };
            this.Controls.Add(lblTitle);

            // =======================
            // MAIN CONTAINER: Header Group (holds picture + student info + buttons)
            // =======================
            GroupBox gbHeader = new GroupBox()
            {
                Text = "Lesson Activity",
                Location = new Point(20, 50),
                Size = new Size(1030, 220)
            };
            this.Controls.Add(gbHeader);

            // PICTURE SECTION (inside header)
            pictureBox = new PictureBox()
            {
                Location = new Point(15, 25),
                Size = new Size(200, 150),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            gbHeader.Controls.Add(pictureBox);

            btnBrowse = new Button()
            {
                Text = "Browse",
                Location = new Point(60, 180),
                Width = 100
            };
            btnBrowse.Click += BtnBrowse_Click;
            gbHeader.Controls.Add(btnBrowse);

            // STUDENT INFO (inside header) - arranged vertically to match reference
            int leftX = 240;
            int y = 30;
            int labelWidth = 110;
            int fieldWidth = 360;
            int vSpacing = 30;

            // Student Name
            Label lblStudName = new Label() { Text = "Student Name:", Location = new Point(leftX, y + 5), AutoSize = true };
            gbHeader.Controls.Add(lblStudName);
            txtStudentName = new TextBox() { Location = new Point(leftX + labelWidth, y), Width = fieldWidth };
            gbHeader.Controls.Add(txtStudentName);
            y += vSpacing;

            // Program
            Label lblProgram = new Label() { Text = "Program:", Location = new Point(leftX, y + 5), AutoSize = true };
            gbHeader.Controls.Add(lblProgram);
            cbProgram = new ComboBox() { Location = new Point(leftX + labelWidth, y), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cbProgram.Items.AddRange(new string[] { "BSIT", "BSCS", "BSIS" });
            gbHeader.Controls.Add(cbProgram);
            y += vSpacing;

            // Student Number
            Label lblStudNo = new Label() { Text = "Student Number:", Location = new Point(leftX, y + 5), AutoSize = true };
            gbHeader.Controls.Add(lblStudNo);
            txtStudentNumber = new TextBox() { Location = new Point(leftX + labelWidth, y), Width = fieldWidth };
            gbHeader.Controls.Add(txtStudentNumber);
            y += vSpacing;

            // Year Level
            Label lblYear = new Label() { Text = "Year Level:", Location = new Point(leftX, y + 5), AutoSize = true };
            gbHeader.Controls.Add(lblYear);
            txtYearLevel = new TextBox() { Location = new Point(leftX + labelWidth, y), Width = 80 };
            gbHeader.Controls.Add(txtYearLevel);

            // Date Enrolled (aligned on same row, shifted right)
            Label lblDate = new Label() { Text = "Date Enrolled:", Location = new Point(leftX + labelWidth + 100, y + 5), AutoSize = true };
            gbHeader.Controls.Add(lblDate);
            dtpEnrolled = new DateTimePicker() { Location = new Point(leftX + labelWidth + 220, y), Width = 200 };
            gbHeader.Controls.Add(dtpEnrolled);
            y += vSpacing;

            // Scholar
            Label lblScholar = new Label() { Text = "Scholar:", Location = new Point(leftX, y + 5), AutoSize = true };
            gbHeader.Controls.Add(lblScholar);
            txtScholar = new TextBox() { Location = new Point(leftX + labelWidth, y), Width = 200 };
            gbHeader.Controls.Add(txtScholar);

            // Buttons on right inside header
            btnSubmit = new Button()
            {
                Text = "Submit",
                Location = new Point(gbHeader.Width - 150, 40),
                Size = new Size(110, 40)
            };
            btnSubmit.Click += BtnSubmit_Click;
            gbHeader.Controls.Add(btnSubmit);

            btnNew = new Button()
            {
                Text = "New / Cancel",
                Location = new Point(gbHeader.Width - 150, 100),
                Size = new Size(110, 40)
            };
            btnNew.Click += BtnNew_Click;
            gbHeader.Controls.Add(btnNew);

            // =======================
            // COURSE INPUT SECTION (left column below header)
            // =======================
            GroupBox gbCourse = new GroupBox()
            {
                Text = "Course Details",
                Location = new Point(20, 290),
                Size = new Size(480, 240)
            };
            this.Controls.Add(gbCourse);

            int cy = 25;
            txtCourseNumber = AddGBTextBox(gbCourse, "Course No:", 10, cy);
            cy += 34;
            txtCourseCode = AddGBTextBox(gbCourse, "Course Code:", 10, cy);
            cy += 34;
            txtCourseDesc = AddGBTextBox(gbCourse, "Course Desc:", 10, cy);
            cy += 34;
            txtUnitLec = AddGBTextBox(gbCourse, "Unit Lec:", 10, cy);
            cy += 34;
            txtUnitLab = AddGBTextBox(gbCourse, "Unit Lab:", 10, cy);
            cy += 34;
            txtTime = AddGBTextBox(gbCourse, "Time:", 10, cy);
            cy += 34;
            txtDay = AddGBTextBox(gbCourse, "Day:", 10, cy);

            btnAdd = new Button()
            {
                Text = "Add",
                Location = new Point(gbCourse.Width - 120, gbCourse.Height - 45),
                Width = 90
            };
            btnAdd.Click += BtnAdd_Click;
            gbCourse.Controls.Add(btnAdd);

            // =======================
            // CREDIT / FEE INPUT (right column, beside course details)
            // =======================
            GroupBox gbCredits = new GroupBox()
            {
                Text = "Credit & Fees Info",
                Location = new Point(520, 290),
                Size = new Size(530, 240)
            };
            this.Controls.Add(gbCredits);

            int fx = 15;
            int fy = 25;
            int flabelW = 150;
            int ffieldW = 160;
            int fspacing = 30;

            // Left column within credits group
            Label lblCreditUnits = new Label() { Text = "Credit Units:", Location = new Point(fx, fy + 5), AutoSize = true };
            gbCredits.Controls.Add(lblCreditUnits);
            TextBox txtCreditUnits = new TextBox() { Location = new Point(fx + flabelW, fy), Width = ffieldW };
            gbCredits.Controls.Add(txtCreditUnits);

            fy += fspacing;
            Label lblTotalUnits = new Label() { Text = "Total Number of Units:", Location = new Point(fx, fy + 5), AutoSize = true };
            gbCredits.Controls.Add(lblTotalUnits);
            txtTotalUnits = new TextBox() { Location = new Point(fx + flabelW, fy), Width = ffieldW, ReadOnly = true };
            gbCredits.Controls.Add(txtTotalUnits);

            fy += fspacing;
            Label lblLab = new Label() { Text = "Laboratory Fee:", Location = new Point(fx, fy + 5), AutoSize = true };
            gbCredits.Controls.Add(lblLab);
            txtLabFee = new TextBox() { Location = new Point(fx + flabelW, fy), Width = ffieldW, Text = "0" };
            gbCredits.Controls.Add(txtLabFee);

            fy += fspacing;
            Label lblTuition = new Label() { Text = "Total Tuition Fee:", Location = new Point(fx, fy + 5), AutoSize = true };
            gbCredits.Controls.Add(lblTuition);
            txtTuitionFee = new TextBox() { Location = new Point(fx + flabelW, fy), Width = ffieldW, ReadOnly = true };
            gbCredits.Controls.Add(txtTuitionFee);

            // Right column within credits group
            int rx = fx;
            int rcol = 270;
            int ry = 25;

            Label lblMisc = new Label() { Text = "Total Miscellaneous Fee:", Location = new Point(rcol + rx, ry + 5), AutoSize = true };
            gbCredits.Controls.Add(lblMisc);
            txtMiscFee = new TextBox() { Location = new Point(rcol + rx + flabelW - 120, ry), Width = ffieldW, Text = "0" };
            gbCredits.Controls.Add(txtMiscFee);

            ry += fspacing;
            Label lblCisco = new Label() { Text = "Cisco Lab. Fee:", Location = new Point(rcol + rx, ry + 5), AutoSize = true };
            gbCredits.Controls.Add(lblCisco);
            txtCiscoFee = new TextBox() { Location = new Point(rcol + rx + flabelW - 120, ry), Width = ffieldW, Text = "0" };
            gbCredits.Controls.Add(txtCiscoFee);

            ry += fspacing;
            Label lblExam = new Label() { Text = "Exam Booklet Fee:", Location = new Point(rcol + rx, ry + 5), AutoSize = true };
            gbCredits.Controls.Add(lblExam);
            txtExamFee = new TextBox() { Location = new Point(rcol + rx + flabelW - 120, ry), Width = ffieldW, Text = "0" };
            gbCredits.Controls.Add(txtExamFee);

            ry += fspacing;
            Label lblTotal = new Label() { Text = "Total Tuition and Fees:", Location = new Point(rcol + rx, ry + 5), AutoSize = true };
            gbCredits.Controls.Add(lblTotal);
            txtTotalFees = new TextBox() { Location = new Point(rcol + rx + flabelW - 120, ry), Width = ffieldW, ReadOnly = true };
            gbCredits.Controls.Add(txtTotalFees);

            // =======================
            // DATAGRID (spanning below course and credits)
            // =======================
            dgv = new DataGridView()
            {
                Location = new Point(20, 550),
                Size = new Size(1030, 220),
                AllowUserToAddRows = false,
                ReadOnly = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgv.Columns.Add("No", "#");
            dgv.Columns.Add("CourseCode", "Course Code");
            dgv.Columns.Add("CourseDesc", "Course Desc");
            dgv.Columns.Add("UnitLec", "Unit Lec");
            dgv.Columns.Add("UnitLab", "Unit Lab");
            dgv.Columns.Add("CreditUnits", "Credit Units");
            dgv.Columns.Add("Time", "Time");
            dgv.Columns.Add("Day", "Day");

            this.Controls.Add(dgv);

            // =======================
            // BOTTOM FEES SUMMARY (below datagrid)
            // =======================
            GroupBox gbFees = new GroupBox()
            {
                Text = "Fees Summary",
                Location = new Point(20, 785),
                Size = new Size(1030, 80)
            };
            this.Controls.Add(gbFees);

            // Keep the same fields but repositioned in the summary area
            Label lblSumTuition = new Label() { Text = "Total Tuition Fee:", Location = new Point(15, 25), AutoSize = true };
            gbFees.Controls.Add(lblSumTuition);
            TextBox txtSumTuition = new TextBox() { Location = new Point(140, 22), Width = 140, ReadOnly = true, Text = txtTuitionFee.Text };
            gbFees.Controls.Add(txtSumTuition);

            Label lblSumMisc = new Label() { Text = "Total Miscellaneous Fee:", Location = new Point(320, 25), AutoSize = true };
            gbFees.Controls.Add(lblSumMisc);
            TextBox txtSumMisc = new TextBox() { Location = new Point(490, 22), Width = 140, ReadOnly = true, Text = txtMiscFee.Text };
            gbFees.Controls.Add(txtSumMisc);

            Label lblSumUnits = new Label() { Text = "Total Number of Units:", Location = new Point(660, 25), AutoSize = true };
            gbFees.Controls.Add(lblSumUnits);
            TextBox txtSumUnits = new TextBox() { Location = new Point(820, 22), Width = 140, ReadOnly = true, Text = txtTotalUnits.Text };
            gbFees.Controls.Add(txtSumUnits);

            // Initialize numeric fields default values preserved
            txtTotalUnits.ReadOnly = true;
            txtTuitionFee.ReadOnly = true;
            txtTotalFees.ReadOnly = true;

            this.Load += Form1_Load;
        }

        // =======================
        // HELPER METHODS
        // =======================
        private TextBox AddLabeledTextBox(string label, int x, int y)
        {
            AddLabel(label, x, y);
            TextBox txt = new TextBox()
            {
                Location = new Point(x + 120, y),
                Width = 200
            };
            this.Controls.Add(txt);
            return txt;
        }

        private void AddLabel(string text, int x, int y)
        {
            Label lbl = new Label()
            {
                Text = text,
                Location = new Point(x, y + 5),
                AutoSize = true
            };
            this.Controls.Add(lbl);
        }

        private TextBox AddGBTextBox(GroupBox gb, string label, int x, int y)
        {
            Label lbl = new Label()
            {
                Text = label,
                Location = new Point(x, y + 5),
                AutoSize = true
            };
            gb.Controls.Add(lbl);

            TextBox txt = new TextBox()
            {
                Location = new Point(x + 120, y),
                Width = 200
            };
            gb.Controls.Add(txt);
            return txt;
        }

        // =======================
        // FUNCTIONALITY
        // =======================
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox.Image = Image.FromFile(ofd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to load image: " + ex.Message);
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            double lec, lab;
            if (!double.TryParse(txtUnitLec.Text, out lec) ||
                !double.TryParse(txtUnitLab.Text, out lab))
            {
                MessageBox.Show("Enter valid numbers for units.");
                return;
            }

            double credit = lec + lab;

            int rowNum = dgv.Rows.Count + 1;

            dgv.Rows.Add(rowNum, txtCourseCode.Text, txtCourseDesc.Text,
                lec, lab, credit, txtTime.Text, txtDay.Text);

            UpdateTotals();
        }

        private void UpdateTotals()
        {
            double totalUnits = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                var cellVal = row.Cells["CreditUnits"].Value ?? row.Cells[5].Value;
                double parsed;
                if (cellVal != null && double.TryParse(cellVal.ToString(), out parsed))
                    totalUnits += parsed;
            }

            txtTotalUnits.Text = totalUnits.ToString("0.##");
            double tuition = totalUnits * TuitionPerUnit;
            txtTuitionFee.Text = tuition.ToString("0.##");

            double lab = Parse(txtLabFee.Text);
            double misc = Parse(txtMiscFee.Text);
            double cisco = Parse(txtCiscoFee.Text);
            double exam = Parse(txtExamFee.Text);

            txtTotalFees.Text = (tuition + lab + misc + cisco + exam).ToString("0.##");
        }

        private double Parse(string text)
        {
            double val;
            double.TryParse(text, out val);
            return val;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentName.Text))
            {
                MessageBox.Show("Student Name is required.");
                return;
            }

            MessageBox.Show("Enrollment Submitted Successfully!");
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            // Clear all textboxes, reset combo/date, clear grid and picture
            ClearControlsRecursive(this);

            if (cbProgram != null)
                cbProgram.SelectedIndex = -1;

            if (dtpEnrolled != null)
                dtpEnrolled.Value = DateTime.Now;

            if (dgv != null)
                dgv.Rows.Clear();

            if (pictureBox != null)
                pictureBox.Image = null;

            // Reset numeric fee fields
            if (txtLabFee != null) txtLabFee.Text = "0";
            if (txtMiscFee != null) txtMiscFee.Text = "0";
            if (txtCiscoFee != null) txtCiscoFee.Text = "0";
            if (txtExamFee != null) txtExamFee.Text = "0";
            if (txtTotalUnits != null) txtTotalUnits.Text = "";
            if (txtTuitionFee != null) txtTuitionFee.Text = "";
            if (txtTotalFees != null) txtTotalFees.Text = "";
        }

        private void ClearControlsRecursive(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox tb)
                    tb.Clear();
                else if (c is ComboBox cb)
                    cb.SelectedIndex = -1;
                else if (c is DateTimePicker dtp)
                    dtp.Value = DateTime.Now;
                else if (c is PictureBox pb)
                    pb.Image = null;

                // Recurse for container controls (GroupBox, Panel, etc.)
                if (c.HasChildren)
                    ClearControlsRecursive(c);
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
        }
    }
}

