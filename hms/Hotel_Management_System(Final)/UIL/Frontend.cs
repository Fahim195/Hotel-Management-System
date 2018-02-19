using CrystalDecisions.CrystalReports.Engine;
using Hotel_Management_System_Final_.BLL;
using Hotel_Management_System_Final_.DAL;
using Hotel_Management_System_Final_.DAL.DAO;
using Hotel_Management_System_Final_.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System_Final_.UIL
{
    public partial class Frontend : Form
    {
        public Frontend()
        {
            InitializeComponent();

            SpecificSearch_TextBox_showpanel10.Visible = false;
            HH.Visible = false;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = false;
            pepH.Visible = false;
            rinfoH.Visible = false;

            Date_label3 .Text =Date_dateTimePicker1.Value.ToString("dd-MMMM-yyyy");
            Home_panel.Visible = false;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = false;
            Search_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible =false;
            SystemAccess_panel10.Visible = false;
            CreateAccess_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            Discount_panel10.Visible = false;
            AdminAccess_Checkin_panel20.Visible = false ;
            DatabaseRestore_or_Backup_panel19.Visible = false;

            RoomBLL aRoomBLL = new RoomBLL();
            DataTable Dtable = aRoomBLL.PredictRoomIDBLL();
            RoomID_label117.Text = Dtable.Rows[0][0].ToString();
        }
        private void Clear_all_Panel_textboxes()
            {
            ClearTextBoxesIn_ADMIN_panel();
            Clear_SeacrchPanelTextBOXES();
            Clear_Payment_TextBoxes();
            Clear_Checkout_Textboxes();
            Clear_Checkin_Textboxes();
            ClearReservationPanelTextbpx();
            UncheckComboBox_Home();
            ClearReporting_Panel_textBoxes();
            Clear_Home_Panel();
            Clear_DataGridviews_of_all_Panels();
            Clear_Discount_panel_textboxes();
            clear_AdminAccess();
            Clear_CreateAccess();
            Clear_Backup_And_DatabaseRecord();

            Hotel_Management_System_crystalReportViewer1.ReportSource = null;
        }
        private void Clear_DataGridviews_of_all_Panels()
        {
            Search_dataGridView1.DataSource = null;
            Payment_ConfirmationdataGridView1.DataSource = null;
            CheckOut_Confirmation_dataGridView1.DataSource = null;
            Checkin_cinfirmationdataGridView1.DataSource = null;
            BookingConfirmation_dataGridView1.DataSource = null;
            Home_dataGridView1.DataSource =null;
            ViewBookingPeriod_dataGridView1.DataSource = null;
        }
        private void Clear_Home_Panel()
        {
            Home_dataGridView1.DataSource = null;
            ViewRecord_byTimePeriodcomboBox1.Text = "";
            ViewRecordOfSpecificDate_dateTimePicker1.Text = "";
        }
        private void Frontend_Load(object sender, EventArgs e)
        {
            Home_panel.Visible = true;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = false;
            Search_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = false;

            SpecificSearch_TextBox_showpanel10.Visible = false;
            HH.Visible = true;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = false;
            pepH.Visible = false;
            rinfoH.Visible = false;

            SystemAccess_panel10.Visible = false;
            CreateAccess_panel10.Visible = false ;
            UpdateUserAccess_panel10.Visible = false;
            Discount_panel10.Visible = false;
            AdminAccess_Checkin_panel20.Visible = false;
            DatabaseRestore_or_Backup_panel19.Visible = false;

            Clear_all_Panel_textboxes();
            Reservation_ValidityCheck();
            HideExtraRow_InDtaaGridview();   
        }

        public void HideExtraRow_InDtaaGridview()
        {
            Home_dataGridView1.AllowUserToAddRows = false;
            CheckOut_Confirmation_dataGridView1.AllowUserToAddRows = false;
            Payment_ConfirmationdataGridView1.AllowUserToAddRows = false;
            Checkin_cinfirmationdataGridView1.AllowUserToAddRows = false;
            ExisingRooms_inAdmin_dataGridView1.AllowUserToAddRows = false;
            ViewBookingPeriod_dataGridView1.AllowUserToAddRows = false;
            BookingConfirmation_dataGridView1.AllowUserToAddRows = false;
            ExisingRooms_inAdmin_dataGridView1.AllowUserToAddRows = false;
            ViewAvailableRooms_forReservation_dataGridView1.AllowUserToAddRows = false;
            View_existing_User_dataGridView1.AllowUserToAddRows = false;
            Search_dataGridView1.AllowUserToAddRows = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Home_panel.Visible = true;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = false;
            Search_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = false;

            SpecificSearch_TextBox_showpanel10.Visible = false;
            HH.Visible = true;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = false;
            pepH.Visible = false;
            rinfoH.Visible = false;
            SystemAccess_panel10.Visible = false;
            CreateAccess_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            Discount_panel10.Visible = false;
            AdminAccess_Checkin_panel20.Visible = false;
            DatabaseRestore_or_Backup_panel19.Visible = false;

            Clear_all_Panel_textboxes(); 
            Reservation_ValidityCheck();
            this.Home_dataGridView1.AllowUserToAddRows = false;


        }
        private void Reservation_ValidityCheck()
        {
             
            string TodaysDate = Date_dateTimePicker1.Value.ToString("yyyy-MM-dd");
            RecordBLL aRecordBLL = new RecordBLL();
            int No_ofValidityExpired= aRecordBLL.Reservation_validityCheckBLL(TodaysDate);
            int ExpiredNumber = aRecordBLL.No_of_Reservation_Expired_BLL(TodaysDate);
            if(ExpiredNumber > 0)
            {
 
                ReservationValidityExpired_label2.Text = ExpiredNumber + " Reservation Expired :";
                ViewReservationExpiredRecord_button1.Enabled = true;
            }
            else
            {
                ReservationValidityExpired_label2.Text = ExpiredNumber + " Reservation Expired :";
                ViewReservationExpiredRecord_button1.Enabled = false;
            } 
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Home_panel.Visible = false;
            Reservation_panel6.Visible = true;
            CheckIn_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = false;
            Search_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = false;

            SpecificSearch_TextBox_showpanel10.Visible = false;
            HH.Visible = false;
            RH.Visible = true;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = false;
            pepH.Visible = false;
            rinfoH.Visible = false;
            SystemAccess_panel10.Visible = false;
            CreateAccess_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            Discount_panel10.Visible = false;
            AdminAccess_Checkin_panel20.Visible = false;
            DatabaseRestore_or_Backup_panel19.Visible = false;

            ViewAvailableRoomsIn_Reservation();
            this.ActiveControl = Name_textBox1;
            Predict_Booking_ID();
            Clear_all_Panel_textboxes();
            this.ActiveControl = Name_textBox1;
            
        }

        //RESERVATION
        public void ViewAvailableRoomsIn_Reservation()
        {
            ReservationBLL aReservationBLL = new ReservationBLL();
            DataTable dTable = aReservationBLL.ViewAvailableRoomsIn_ReservationBLL();
            ViewAvailableRooms_forReservation_dataGridView1.DataSource = dTable;
        }
        private void ViewAvailableRooms_forReservation_dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RoomID_textBox10.Text = ViewAvailableRooms_forReservation_dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            RoomNo_textBox11 .Text = ViewAvailableRooms_forReservation_dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int RoomId = int.Parse(ViewAvailableRooms_forReservation_dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            ReservationBLL aReservationBLL = new ReservationBLL();
            DataTable dTable = aReservationBLL.ViewRoomReservationPeriodBLL(RoomId);
            ViewBookingPeriod_dataGridView1.DataSource = dTable;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SpecificSearch_TextBox_showpanel10.Visible = false;
            HH.Visible = false;
            RH.Visible = false;
            cinH.Visible = true;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = false;
            pepH.Visible = false;
            rinfoH.Visible = false;

            Home_panel.Visible = false;
            Reservation_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = false;
            CheckIn_panel6.Visible = true;
            Search_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = false;
            SystemAccess_panel10.Visible = false;
            CreateAccess_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            Discount_panel10.Visible = false;
            AdminAccess_Checkin_panel20.Visible = false;
            DatabaseRestore_or_Backup_panel19.Visible = false;

            Clear_all_Panel_textboxes();
            this.ActiveControl = NAme_textBox2;


        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SpecificSearch_TextBox_showpanel10.Visible = false;
            HH.Visible = false;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = true;
            sH.Visible = false;
            pH.Visible = false;
            pepH.Visible = false;
            rinfoH.Visible = false;

            Home_panel.Visible = false;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible =false;
            Payment_panel10.Visible = false;
            CheckOut_panel10.Visible = true;
            Search_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = false;
            SystemAccess_panel10.Visible = false;
            CreateAccess_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            Discount_panel10.Visible = false;
            AdminAccess_Checkin_panel20.Visible = false;
            DatabaseRestore_or_Backup_panel19.Visible = false;

            Clear_all_Panel_textboxes();
            this.ActiveControl = name_textBox21;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Check_I_Date_textBox14.ForeColor = Color.Gray;
            Check_o_Date_textBox15.ForeColor = Color.Gray;
            ReserveDate_textBox13.ForeColor = Color.Gray;

            Home_panel.Visible = false;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible = false;
            Payment_panel10.Visible = false;
            CheckOut_panel10.Visible = false; ;
            Search_panel10.Visible = true;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = false;

            SpecificSearch_TextBox_showpanel10.Visible = false;
            HH.Visible = false;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = true;
            pH.Visible = false;
            pepH.Visible = false;
            rinfoH.Visible = false;
            SystemAccess_panel10.Visible = false;
            CreateAccess_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            Discount_panel10.Visible = false;
            AdminAccess_Checkin_panel20.Visible = false;
            DatabaseRestore_or_Backup_panel19.Visible = false;

            Clear_all_Panel_textboxes();
            this.ActiveControl = Book_ID_textBox3;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            CustomReport_panel10.Visible = false;
            SpecificSearch_TextBox_showpanel10.Visible = false;
            HH.Visible = false;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = false;
            pepH.Visible = true;
            rinfoH.Visible = false;

            Home_panel.Visible = false;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = false;
            Search_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = true;
            SystemAccess_panel10.Visible = false;
            CreateAccess_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            Discount_panel10.Visible = false;
            AdminAccess_Checkin_panel20.Visible = false;
            DatabaseRestore_or_Backup_panel19.Visible = false;

            Clear_all_Panel_textboxes();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp_Form1 aSignUp = new SignUp_Form1();
            aSignUp.Show();
            this.Hide();
        }

        private void Uncheck_button1_Click(object sender, EventArgs e)
        {
            UncheckComboBox_Home();
        }
        private void UncheckComboBox_Home()
        {
            CheckIn_checkBox1.Checked = false;
            CheckOut_checkBox1.Checked = false;
            ALL_checkBox2.Checked = false;

        }

        private void ALL_checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (ALL_checkBox2 .Checked)
            {
                CheckIn_checkBox1.Checked = true;
                CheckOut_checkBox1.Checked = true ;
            }
            else
            {
                CheckIn_checkBox1.Checked = false;
                CheckOut_checkBox1.Checked = false;
            }
        }
                                             //RECORD
        private void ViewSpecificRecord_button1_Click(object sender, EventArgs e)
        {
            int CheckIn = 0;
            int CheckOut = 0;
            string DateforSpecificRecodView = ViewRecordOfSpecificDate_dateTimePicker1.Value.ToString("yyyy-MM-dd");
            if (CheckIn_checkBox1.Checked)
            {
                CheckIn = 1;
            }
            if (CheckOut_checkBox1.Checked)
            {
                CheckOut = 1;
            }
            RecordBLL aRecordBLL = new RecordBLL();
            DataTable dTable= aRecordBLL.ViewSpecificRecordinGridview(CheckIn,CheckOut,DateforSpecificRecodView);
            if (dTable !=null)
            {
                Home_dataGridView1.DataSource = dTable;
            }
            else
            {
                MessageBox.Show("Please select");
            }

        }

        private void ViewRecordOfSpecificDate_dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Home_dataGridView1.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string TodaysDate = Date_dateTimePicker1.Value.ToString("yyyy-MM-dd");
            RecordBLL aRecordBLL = new RecordBLL();
            DataTable dTable= aRecordBLL.ReservationExired_List_BLL(TodaysDate);
            Home_dataGridView1.DataSource = dTable;

        }

        private void Home_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void All_InRecordPeriodcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (All_InRecordPeriodcheckBox1.Checked)
            {
                CheckIn_InRecordPeriodcheckBox1.Checked = true;
                CheckOut_InRecordPeriodcheckBox1.Checked = true;
            }
            else
            {
                CheckIn_InRecordPeriodcheckBox1.Checked = false;
                CheckOut_InRecordPeriodcheckBox1.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckIn_InRecordPeriodcheckBox1.Checked = false;
            CheckOut_InRecordPeriodcheckBox1.Checked = false;
            All_InRecordPeriodcheckBox1.Checked = false;
        }

        private void ViewRecord_ofTimePeriodbutton1_Click(object sender, EventArgs e)
        {
            int CheckIN = 0;
            int CheckOUT = 0;
            
            string DateforTimePerod_RecodView = Date_dateTimePicker1.Value.ToString("yyyy-MM-dd");
            if (CheckIn_InRecordPeriodcheckBox1 .Checked)
            {
                CheckIN = 1;
            }
            if (CheckOut_InRecordPeriodcheckBox1.Checked)
            {
                CheckOUT = 1;
            }
            string ComboBoxText = ViewRecord_byTimePeriodcomboBox1.Text;
            RecordBLL aRecordBLL = new RecordBLL();
            DataTable dTAble= aRecordBLL.ViewRecord_OfSpecific_TimePeriod(DateforTimePerod_RecodView, CheckIN, CheckOUT, ComboBoxText);
            if (dTAble != null)
            {
               
                Home_dataGridView1.DataSource =dTAble;
                
            }
            else
            {
                MessageBox.Show("Please select");
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
                                          //RESERVATION
        private void ClearReservationPanelTextbpx_button6_Click(object sender, EventArgs e)
        {
            ClearReservationPanelTextbpx();
        }
        public void ClearReservationPanelTextbpx()
        {
            Name_textBox1.Text = "";
            Age_textBox2.Text = "";
            DOB_dateTimePicker1.Text = "";
            SEX_comboBox1.Text = "";
            Profession_textBox3.Text = "";
            ProfessionAddress_textBox4.Text = "";
            PresentAddress_textBox6.Text = "";
            PermanentAddress_textBox5.Text = "";
            ContactNo_textBox7.Text = "";
            Email_textBox8.Text = "";
            NID_textBox9.Text = "";
            RoomID_textBox10.Text = "";
            RoomNo_textBox11.Text = "";
            ReservationDate_dateTimePicker3.Text = "";
            CheckinDate_dateTimePicker4.Text = "";
            CheckOutDate_dateTimePicker2.Text = "";
            TotalCost_textBox12.Text = "";
            Payment_textBox13.Text = "";
            Due_textBox14.Text = "";
            BookingID_forUpdateoDelete_textBox1.Text = "";
        }
        string Gender;
        private void SaveReservationInfo_button1_Click(object sender, EventArgs e)
        {
            Save_ReservationInformation();
        }
        public void Save_ReservationInformation()
        {
            if (SEX_comboBox1.Text == "Male")
            {
                Gender = "Male";
            }
            else if (SEX_comboBox1.Text == "Female")
            {
                Gender = "Female";
            }
            else if (SEX_comboBox1.Text == "Others")
            {
                Gender = "Others";
            }
            Customer aCustomer = new Customer();
            aCustomer.Id = 0;
            int.TryParse(Booking_label29.Text, out aCustomer.Id);
            aCustomer.Name = Name_textBox1.Text;
            aCustomer.DOB = DOB_dateTimePicker1.Value.ToString("yyyy-MM-dd");
            aCustomer.Age = 0;
            int.TryParse(Age_textBox2.Text, out aCustomer.Age);
            aCustomer.Sex = Gender;
            aCustomer.Profession = Profession_textBox3.Text;
            aCustomer.ProfessionAddress = ProfessionAddress_textBox4.Text;
            aCustomer.PermanentAddress = PermanentAddress_textBox5.Text;
            aCustomer.PresentAddress = PresentAddress_textBox6.Text;
            aCustomer.ContactNo = ContactNo_textBox7.Text;
            aCustomer.Email = Email_textBox8.Text;
            aCustomer.NIDorPassportNo = NID_textBox9.Text;

            Record aRecord = new Record();
            aRecord.RoomID = 0;
            int.TryParse(RoomID_textBox10.Text, out aRecord.RoomID);
            aRecord.RoomNO = RoomNo_textBox11.Text;
            aRecord.BookingDate = ReservationDate_dateTimePicker3.Value.ToString("yyyy-MM-dd");
            aRecord.CheckInDate = CheckinDate_dateTimePicker4.Value.ToString("yyyy-MM-dd");
            aRecord.CheckOutDate = CheckOutDate_dateTimePicker2.Value.ToString("yyyy-MM-dd");
            aRecord.PaymentStatus = Payment_textBox13.Text;

            Cost aCost = new Cost();
            aCost.TotalCost = 0;
            float.TryParse(TotalCost_textBox12.Text, out aCost.TotalCost);
            aCost.Due = 0;
            float.TryParse(Due_textBox14.Text, out aCost.Due);
            aCost.LastPayment = 0;
            float.TryParse(Payment_textBox13.Text, out aCost.LastPayment);

            float Due = float.Parse(Due_textBox14.Text);
            if (Due == 0)
            {
                aRecord.PaymentStatus = " Clear ";
            }
            else if(Due >0) {
                aRecord.PaymentStatus = "Due "+aCost .Due+"";
            }
            else
            {
                aRecord.PaymentStatus = "";
                MessageBox.Show("Error Payment !! Please Check");
            }

            ReservationBLL aReservationBLL = new ReservationBLL();
            bool Result = aReservationBLL.SaveReservationInformation_BLL(aCustomer, aRecord, aCost);
            if (Result)
            {
                
                DataTable dTable = aReservationBLL.Update_ReservationInformationBLL(aCustomer);
                BookingConfirmation_dataGridView1.DataSource = dTable;
                MessageBox.Show("Reservation Confirmed !!");
                ClearReservationPanelTextbpx();
            }
            else
            {
                MessageBox.Show("Please Check Your Information!!");
            }
        }
        public void  Predict_Booking_ID()
        {
            ReservationBLL aReservationBLL = new ReservationBLL();
            DataTable dTable = aReservationBLL.Predict_Booking_ID_BLL();
            int PredictedBookingID = (int)dTable.Rows[0][0] + 1;
            Booking_label29.Text =PredictedBookingID.ToString();
        }

        private void UpdateReseravtioninfo_button4_Click(object sender, EventArgs e)
        {
            if (SEX_comboBox1.Text == "Male")
            {
                Gender = "Male";
            }
            else if (SEX_comboBox1.Text == "Female")
            {
                Gender = "Female";
            }
            else if (SEX_comboBox1.Text == "Others")
            {
                Gender = "Others";
            }
            Customer aCustomer = new Customer();
            aCustomer.Id = 0;
            int.TryParse (BookingID_forUpdateoDelete_textBox1.Text,out aCustomer .Id);
            aCustomer.Name = Name_textBox1.Text;
            aCustomer.DOB = DOB_dateTimePicker1.Value.ToString("yyyy-MM-dd");
            aCustomer.Age = 0;
            int.TryParse(Age_textBox2.Text, out aCustomer.Age);
            aCustomer.Sex = Gender;
            aCustomer.Profession = Profession_textBox3.Text;
            aCustomer.ProfessionAddress = ProfessionAddress_textBox4.Text;
            aCustomer.PermanentAddress = PermanentAddress_textBox5.Text;
            aCustomer.PresentAddress = PresentAddress_textBox6.Text;
            aCustomer.ContactNo = ContactNo_textBox7.Text;
            aCustomer.Email = Email_textBox8.Text;
            aCustomer.NIDorPassportNo = NID_textBox9.Text;

            Record aRecord = new Record();
            aRecord.RoomID = 0;
            int.TryParse(RoomID_textBox10.Text, out aRecord.RoomID);
            aRecord.RoomNO =RoomNo_textBox11.Text;
            aRecord.BookingDate = ReservationDate_dateTimePicker3.Value.ToString("yyyy-MM-dd");
            aRecord.CheckInDate = CheckinDate_dateTimePicker4.Value.ToString("yyyy-MM-dd");
            aRecord.CheckOutDate = CheckOutDate_dateTimePicker2.Value.ToString("yyyy-MM-dd");
            aRecord.PaymentStatus = Payment_textBox13.Text;

            Cost aCost = new Cost();
            aCost.TotalCost = 0;
            float.TryParse(TotalCost_textBox12.Text, out aCost.TotalCost);
            aCost.Due = 0;
            float.TryParse(Due_textBox14.Text, out aCost.Due);
            aCost.LastPayment = 0;
            float.TryParse(Payment_textBox13.Text, out aCost.LastPayment);


            float Due = float.Parse(Due_textBox14.Text);
            if (Due == 0)
            {
                aRecord.PaymentStatus = " Clear ";
            }
            else if (Due > 0)
            {
                aRecord.PaymentStatus = "Due " + aCost.Due + "";
            }
            else
            {
                aRecord.PaymentStatus = "";
                MessageBox.Show("Error Payment !! Please Check");
            }
            ReservationBLL aReservationBLL = new ReservationBLL();
            bool Result = aReservationBLL.Update_ReservationInformationBLL(aCustomer, aRecord, aCost);
            if (Result) { 
            
                MessageBox.Show("Reservation Successfully Updated!!");
                DataTable dTable = aReservationBLL.BookingUpdate_ConfirmationBLL(aCustomer);
                BookingConfirmation_dataGridView1.DataSource = dTable;
                ClearReservationPanelTextbpx();
            }
            else
            {
                MessageBox.Show("Please Check Your Booking ID!!");
            }
        }

        private void GO_button1_Click(object sender, EventArgs e)
        {
            
        }
        private void GetReservationInformation_inTextbox()
        {
            Customer aCustomer = new Customer();
            aCustomer.Id = 0;
            int.TryParse(BookingID_forUpdateoDelete_textBox1.Text, out aCustomer.Id);
            ReservationBLL aReservationBLL = new ReservationBLL();
            DataTable dTable = aReservationBLL.ViewReservationInformationIn_textboxBLL(aCustomer);
            if (dTable == null)
            {
                MessageBox.Show("Please Enter Booking ID to Search !!");
            }
            else
            {
                try
                {
                    Name_textBox1.Text = dTable.Rows[0][0].ToString();
                    Age_textBox2.Text = dTable.Rows[0][1].ToString();
                    SEX_comboBox1.Text = dTable.Rows[0][2].ToString();
                    DOB_dateTimePicker1.Text = dTable.Rows[0][3].ToString();
                    Profession_textBox3.Text = dTable.Rows[0][4].ToString();
                    ProfessionAddress_textBox4.Text = dTable.Rows[0][5].ToString();
                    PermanentAddress_textBox5.Text = dTable.Rows[0][6].ToString();
                    PresentAddress_textBox6.Text = dTable.Rows[0][7].ToString();
                    ContactNo_textBox7.Text = dTable.Rows[0][8].ToString();
                    Email_textBox8.Text = dTable.Rows[0][9].ToString();
                    NID_textBox9.Text = dTable.Rows[0][10].ToString();
                    RoomID_textBox10.Text = dTable.Rows[0][11].ToString();
                    RoomNo_textBox11.Text = dTable.Rows[0][12].ToString();
                    ReservationDate_dateTimePicker3.Text = dTable.Rows[0][13].ToString();
                    CheckinDate_dateTimePicker4.Text = dTable.Rows[0][14].ToString();
                    CheckOutDate_dateTimePicker2.Text = dTable.Rows[0][15].ToString();
                    TotalCost_textBox12.Text = dTable.Rows[0][16].ToString();
                    Due_textBox14.Text = dTable.Rows[0][17].ToString();
                    DUE___textBox1.Text= dTable.Rows[0][17].ToString();

                    DateTime Checkin = (DateTime)dTable.Rows[0][14];
                    DateTime Checkout = (DateTime)dTable.Rows[0][15];
                    NoOfDays_textBox15.Text = (Checkout - Checkin).TotalDays.ToString();
                    this.ActiveControl = Payment_textBox13;
                }
                catch
                {
                    MessageBox.Show("Please Check your Booking Information!!");
                }
            }
        }
         private void BookingCancel_confirmation()
        {
            Customer aCustomer = new Customer();
            aCustomer.Id = 0;
            int.TryParse(BookingID_forUpdateoDelete_textBox1.Text, out aCustomer.Id);
            ReservationBLL aReservationBLL = new ReservationBLL();
            DataTable dtable= aReservationBLL.BookingCancel_ConfirmationBLL(aCustomer );
            BookingConfirmation_dataGridView1.DataSource = dtable;

        }
        private void DeleteReservation_button5_Click(object sender, EventArgs e)
        {
            Customer aCustomer = new Customer();
            aCustomer.Id = 0;
            int.TryParse (BookingID_forUpdateoDelete_textBox1.Text,out aCustomer.Id );
            ReservationBLL aReservationBLL = new ReservationBLL();
            bool Result = aReservationBLL.CancelReservationBLL(aCustomer);
            if (Result )
            {
                BookingCancel_confirmation();
                MessageBox.Show("Reservation Cancelled!!");
                ClearReservationPanelTextbpx();
            }
            else
            {
                MessageBox.Show("Error Reservation Cancellation!!");
            }
        }

        private void NoOfDays_textBox15_TextChanged(object sender, EventArgs e)
        {try
            {
                int Days = int.Parse(NoOfDays_textBox15.Text);
                Room aRoom = new Room();
                aRoom.Id = 0;
                int.TryParse(RoomID_textBox10.Text, out aRoom.Id);
                ReservationBLL aReservationBLL = new ReservationBLL();
                DataTable dTable = aReservationBLL.TotalCost_CalculateDAL(Days, aRoom);
                TotalCost_textBox12.Text = dTable.Rows[0][0].ToString();
            }
            catch
            {

            }
            
        }

        private void Payment_textBox13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float totalcost = float.Parse(TotalCost_textBox12.Text);
                float payment = 0;
                 payment = float.Parse(Payment_textBox13.Text);
                float Due = totalcost - payment;
                Due_textBox14.Text = Due.ToString();
            }

            catch
            {
            }
        }

        private void TotalCost_textBox12_TextChanged(object sender, EventArgs e)
        {
            Due_textBox14.Text = TotalCost_textBox12.Text;
        }

        private void CheckOutDate_dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {                           //Claculate No of Days
            DateTime Checkin = (DateTime)CheckinDate_dateTimePicker4.Value;
            DateTime Checkout = (DateTime)CheckOutDate_dateTimePicker2.Value;
            int difference = Checkout.Date.Subtract(Checkin.Date).Days;
            NoOfDays_textBox15.Text = difference.ToString();
                                    //Check Booking Avility
            Record aRecord = new Record();
            aRecord.CheckInDate = CheckinDate_dateTimePicker4.Value.ToString("yyyy-MM-dd");
            aRecord.CheckOutDate = CheckOutDate_dateTimePicker2.Value.ToString("yyyy-MM-dd");
            ReservationBLL aReservation = new ReservationBLL();
            bool Result = aReservation.RoomBooking_avilityBLL(aRecord);
            if (Result)
            {
                MessageBox.Show("Selected Period Already Reserved!!");
            }
        }

        private void BookingID_forUpdateoDelete_textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateReseravtioninfo_button4.Enabled = true ;
            DeleteReservation_button5.Enabled = true ;
            //SaveReservationInfo_button1.Enabled = false;
        }

        private void BookingID_forUpdateoDelete_textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetReservationInformation_inTextbox();
            }
            
        }

        private void Payment_textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Due_textBox14;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = TotalCost_textBox12;
            }
            if (e.KeyCode == Keys.Enter)
            {
                Save_ReservationInformation();
            }
        }

        private void CheckIn_panel6_Paint(object sender, PaintEventArgs e)
        {

        }
                                        
                                        //Check IN

        private void GO_inCheckin_button1_Click(object sender, EventArgs e)
        {
            Info_in_CheckinPanel_textboxes();
        }
        private void Info_in_CheckinPanel_textboxes()
        {
            Customer aCustomer = new Customer();
            aCustomer.Id = 0;
            int.TryParse(BooingID_InCheckin_textBox1.Text, out aCustomer.Id);
            CheckOutBLL aCheckInBLL = new CheckOutBLL();
            DataTable dTable = aCheckInBLL.ViewCheckIN_InformationIn_textboxBLL(aCustomer);
            if (dTable == null)
            {
                MessageBox.Show("Please Enter Reservation ID!!");
            }
            else
            {
                try
                {
                    NAme_textBox2.Text = dTable.Rows[0][0].ToString();
                    AGe_textBox3.Text = dTable.Rows[0][1].ToString();
                    SEx_textBox4.Text = dTable.Rows[0][2].ToString();
                    DOb_textBox5.Text = dTable.Rows[0][3].ToString();
                    PRofession_textBox7.Text = dTable.Rows[0][4].ToString();
                    PRofessionADdress_.Text = dTable.Rows[0][5].ToString();
                    PArmanentADdress_.Text = dTable.Rows[0][6].ToString();
                    PResentADdress_textBox10.Text = dTable.Rows[0][7].ToString();
                    COntactNO_textBox12.Text = dTable.Rows[0][8].ToString();
                    EMail_textBox13.Text = dTable.Rows[0][9].ToString();
                    NId_textBox14.Text = dTable.Rows[0][10].ToString();
                    ROomId_textBox15.Text = dTable.Rows[0][11].ToString();
                    ROomNO_textBox17.Text = dTable.Rows[0][12].ToString();
                    REservationDate_textBox18.Text = dTable.Rows[0][13].ToString();
                    CHeckinDate_textBox19.Text = dTable.Rows[0][14].ToString();
                    CHeckOutDate_textBox20.Text = dTable.Rows[0][15].ToString();
                    TOtalCost_textBox22.Text = dTable.Rows[0][16].ToString();
                    DUe_textBox23.Text = dTable.Rows[0][17].ToString();
                    DUE___textBox1.Text = dTable.Rows[0][17].ToString();
                    DateTime Checkin = (DateTime)dTable.Rows[0][14];
                    DateTime Checkout = (DateTime)dTable.Rows[0][15];
                    NO_of_daystextBox1.Text = (Checkout - Checkin).TotalDays.ToString();
                    this.ActiveControl = PAyment_textBox24;
                }
                catch
                {
                    MessageBox.Show("Please Check your Bookinng ID!!");
                }

            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Clear_Checkin_Textboxes();
        }
        public void Clear_Checkin_Textboxes()
        {
            BooingID_InCheckin_textBox1.Text = "";
            NAme_textBox2.Text = "";
            AGe_textBox3.Text = "";
            SEx_textBox4.Text = "";
            DOb_textBox5.Text = "";
            PRofession_textBox7.Text = "";
            ProfessionAddress_textBox4.Text = "";
            PermanentAddress_textBox5.Text = "";
            PResentADdress_textBox10.Text = "";
            COntactNO_textBox12.Text = "";
            EMail_textBox13.Text = "";
            NId_textBox14.Text = "";
            ROomId_textBox15.Text = "";
            ROomNO_textBox17.Text = "";
            REservationDate_textBox18.Text = "";
            CHeckinDate_textBox19.Text = "";
            CHeckOutDate_textBox20.Text = "";
            TOtalCost_textBox22.Text = "";
            DUe_textBox23.Text = "";
            NO_of_daystextBox1.Text = "";
            REservationDate_textBox18.Text = "";
            PAyment_textBox24.Text = "";
        }
        private void button4_Click(object sender, EventArgs e) //Save Checkn
        {
            Customer aCustomer = new Customer();
            aCustomer.Id = 0;
            int.TryParse(BooingID_InCheckin_textBox1.Text, out aCustomer.Id);
            aCustomer.Name = NAme_textBox2.Text;
            aCustomer.Age = 0;
            int.TryParse(AGe_textBox3.Text,out aCustomer.Age);
            aCustomer.Sex = SEx_textBox4.Text;
            aCustomer.DOB = DOb_textBox5.Text;
            aCustomer.Profession = PRofession_textBox7.Text;
            aCustomer.ProfessionAddress = PRofessionADdress_.Text;
            aCustomer.PermanentAddress = PArmanentADdress_.Text;
            aCustomer.PresentAddress = PResentADdress_textBox10.Text;
            aCustomer.ContactNo = COntactNO_textBox12.Text;
            aCustomer.Email = EMail_textBox13.Text;
            aCustomer.NIDorPassportNo = NId_textBox14.Text;

            Record aRecord = new Record();
            aRecord.RoomID = 0;
            int.TryParse(ROomId_textBox15.Text,out aRecord.RoomID);
            aRecord.RoomNO = ROomNO_textBox17.Text;
            aRecord.BookingDate = REservationDate_textBox18.Text;
            aRecord.CheckInDate = CHeckinDate_textBox19.Text;
            aRecord.CheckOutDate = CHeckOutDate_textBox20.Text;

            Cost aCost = new Cost();
            aCost.TotalCost = 0;
            float.TryParse(TOtalCost_textBox22.Text, out aCost.TotalCost);
            aCost.Due = 0;
            float.TryParse(DUe_textBox23.Text, out aCost.Due);
            aCost.LastPayment = 0;
            float.TryParse(PAyment_textBox24.Text, out aCost.LastPayment);

            float Due = float.Parse(DUe_textBox23.Text);
            if (Due == 0)
            {
                aRecord.PaymentStatus = " Clear ";
            }
            else if (Due > 0)
            {
                aRecord.PaymentStatus = "Due " + aCost.Due + "";
            }
            else
            {
                aRecord.PaymentStatus = "";
                MessageBox.Show("Error Payment !! Please Check");
            }

            CheckOutBLL aCheckinBLL = new CheckOutBLL();
            bool Result = aCheckinBLL.SaveCheckinInformation_BLL(aCustomer, aRecord, aCost);
            if (Result)
            {
                CheckinConfirmatio_Gridview();
                MessageBox.Show("Checkin Confirmed!!");
                Clear_Checkin_Textboxes();
            }
            else
            {
                MessageBox.Show("Please Check Your Booking ID!!");
            }
        }
        public void CheckinConfirmatio_Gridview()
        {
            Customer aCustomer = new Customer();
            aCustomer.Id = int.Parse(BooingID_InCheckin_textBox1.Text);
            CheckOutBLL aCheckinBLL = new CheckOutBLL();
            DataTable dTable= aCheckinBLL.Checkin_ConfirmationBLL(aCustomer);
            if(dTable ==null)
            {
                MessageBox.Show("Check Booking Id!!");
            }
            else
            {
                Checkin_cinfirmationdataGridView1.DataSource = dTable;
            }
        }

        private void button5_Click(object sender, EventArgs e)           // Update Checkin  
        {
            Customer aCustomer = new Customer();
            aCustomer.Id = 0;
            int.TryParse(BooingID_InCheckin_textBox1.Text, out aCustomer.Id);
            aCustomer.Name = NAme_textBox2.Text;
            aCustomer.Age = 0;
            int.TryParse(AGe_textBox3.Text,out aCustomer.Age);
            aCustomer.Sex = SEx_textBox4.Text;
            aCustomer.DOB = DOb_textBox5.Text;
            aCustomer.Profession = PRofession_textBox7.Text;
            aCustomer.ProfessionAddress = PRofessionADdress_.Text;
            aCustomer.PermanentAddress = PArmanentADdress_.Text;
            aCustomer.PresentAddress = PResentADdress_textBox10.Text;
            aCustomer.ContactNo = COntactNO_textBox12.Text;
            aCustomer.Email = EMail_textBox13.Text;
            aCustomer.NIDorPassportNo = NId_textBox14.Text;

            Record aRecord = new Record();
            aRecord.RoomID = int.Parse(ROomId_textBox15.Text);
            aRecord.RoomNO = ROomNO_textBox17.Text;
            aRecord.BookingDate = REservationDate_textBox18.Text;
            aRecord.CheckInDate = CHeckinDate_textBox19.Text;
            aRecord.CheckOutDate = CHeckOutDate_textBox20.Text;

            Cost aCost = new Cost();
            aCost.TotalCost = 0;
            float.TryParse(TOtalCost_textBox22.Text, out aCost.TotalCost);
            aCost.Due = 0;
            float.TryParse(DUe_textBox23.Text, out aCost.Due);
            aCost.LastPayment = 0;
            float.TryParse(PAyment_textBox24.Text, out aCost.LastPayment);

            float Due = float.Parse(DUe_textBox23.Text);
            if (Due == 0)
            {
                aRecord.PaymentStatus = " Clear ";
            }
            else if (Due > 0)
            {
                aRecord.PaymentStatus = "Due " + aCost.Due + "";
            }
            else
            {
                aRecord.PaymentStatus = "";
                MessageBox.Show("Error Payment !! Please Check");
            }

            CheckOutBLL aCheckinBLL = new CheckOutBLL();
            bool Result = aCheckinBLL.SaveCheckinInformation_BLL(aCustomer, aRecord, aCost);
            if (Result)
            {
                CheckinConfirmatio_Gridview();
                MessageBox.Show("Checkin Successfully Udated!!");
                Clear_Checkin_Textboxes();
            }
            else
            {
                MessageBox.Show("Please Check Your Booking ID!!");
            }
        }

        private void groupBox22_Enter(object sender, EventArgs e)
        {

        }

        private void DUe_textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void due_textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)     //GO button in Checkout
        {
            Infoin_CheckOUT_Textboses();
        }
        public void Infoin_CheckOUT_Textboses()
        {
            Customer aCustomer = new Customer();
            aCustomer.Id = 0;
            int.TryParse(bookingID_textBox1.Text, out aCustomer.Id);
            CheckoutBLL aCheckout = new CheckoutBLL();
            DataTable dTable = aCheckout.ViewCheckOut_InformationIn_textboxBLL(aCustomer);
            if (dTable == null)
            {
                MessageBox.Show("Please Enter Reservation ID!!");
            }
            else
            {
                try
                {
                    name_textBox21.Text = dTable.Rows[0][0].ToString();
                    age_textBox16.Text = dTable.Rows[0][1].ToString();
                    sex_textBox12.Text = dTable.Rows[0][2].ToString();
                    dob_textBox8.Text = dTable.Rows[0][3].ToString();
                    profession_textBox20.Text = dTable.Rows[0][4].ToString();
                    professionadddresstextBox15.Text = dTable.Rows[0][5].ToString();
                    permanentaddress_textBox11.Text = dTable.Rows[0][6].ToString();
                    presentaddress_textBox7.Text = dTable.Rows[0][7].ToString();
                    contactno_textBox19.Text = dTable.Rows[0][8].ToString();
                    emial_textBox14.Text = dTable.Rows[0][9].ToString();
                    nid_textBox10.Text = dTable.Rows[0][10].ToString();
                    roomid_textBox6.Text = dTable.Rows[0][11].ToString();
                    roomno_textBox18.Text = dTable.Rows[0][12].ToString();
                    reservationdate_textBox13.Text = dTable.Rows[0][13].ToString();
                    checkindate_textBox9.Text = dTable.Rows[0][14].ToString();
                    checkoutdate_textBox5.Text = dTable.Rows[0][15].ToString();
                    totalcost_textBox2.Text = dTable.Rows[0][16].ToString();
                    due_textBox3.Text = dTable.Rows[0][17].ToString();
                    DUE___textBox1.Text= dTable.Rows[0][17].ToString();

                    DateTime Checkin = (DateTime)dTable.Rows[0][14];
                    DateTime Checkout = (DateTime)dTable.Rows[0][15];
                    no_of_days_textBox17.Text = (Checkout - Checkin).TotalDays.ToString();
                    this.ActiveControl = payment_textBox4;
                }
                catch
                {
                    MessageBox.Show("Please Check your Reservation ID !!");
                }

            }
        }
         public void Clear_Checkout_Textboxes()
            {
           name_textBox21.Text = "";
            age_textBox16.Text = "";
            sex_textBox12 .Text = "";
            dob_textBox8.Text = "";
            profession_textBox20.Text = "";
            professionadddresstextBox15 .Text = "";
            permanentaddress_textBox11.Text = "";
            presentaddress_textBox7.Text = "";
            contactno_textBox19.Text = "";
            emial_textBox14.Text = "";
            nid_textBox10.Text = "";
            roomid_textBox6.Text = "";
            roomno_textBox18.Text = "";
            reservationdate_textBox13.Text = "";
            checkindate_textBox9.Text = "";
            checkoutdate_textBox5.Text = "";
            totalcost_textBox2.Text = "";
            due_textBox3.Text = "";
            no_of_days_textBox17.Text = "";
            bookingID_textBox1.Text = "";
            payment_textBox4.Text = "";
         }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Clear_Checkout_Textboxes();
        }

        private void button6_Click_1(object sender, EventArgs e)  // Save Checkout
        {
            Customer aCustomer = new Customer();
            aCustomer.Id = 0;
            int.TryParse(bookingID_textBox1.Text, out aCustomer.Id);
            aCustomer.Name = name_textBox21.Text;
            aCustomer.Age = int.Parse(age_textBox16.Text);
            aCustomer.Sex = sex_textBox12.Text;
            aCustomer.DOB = dob_textBox8.Text;
            aCustomer.Profession = profession_textBox20.Text;
            aCustomer.ProfessionAddress = professionadddresstextBox15.Text;
            aCustomer.PermanentAddress = permanentaddress_textBox11.Text;
            aCustomer.PresentAddress = presentaddress_textBox7.Text;
            aCustomer.ContactNo = contactno_textBox19.Text;
            aCustomer.Email = emial_textBox14.Text;
            aCustomer.NIDorPassportNo = nid_textBox10.Text;

            Record aRecord = new Record();
            aRecord.RoomID = int.Parse(roomid_textBox6.Text);
            aRecord.RoomNO = roomno_textBox18.Text;
            aRecord.BookingDate = reservationdate_textBox13.Text;
            aRecord.CheckInDate = checkindate_textBox9.Text;
            aRecord.CheckOutDate = checkoutdate_textBox5.Text;

            Cost aCost = new Cost();
            aCost.TotalCost = 0;
            float.TryParse(totalcost_textBox2.Text, out aCost.TotalCost);
            aCost.Due = 0;
            float.TryParse(due_textBox3.Text, out aCost.Due);
            aCost.LastPayment = 0;
            float.TryParse(payment_textBox4.Text, out aCost.LastPayment);

            float Due = float.Parse(due_textBox3.Text);
            if (Due == 0)
            {
                aRecord.PaymentStatus = " Clear ";
            }
            else if (Due > 0)
            {
                aRecord.PaymentStatus = "Due " + aCost.Due + "";
            }
            else
            {
                aRecord.PaymentStatus = "";
                MessageBox.Show("Error Payment !! Please Check");
            }
            CheckoutBLL aCheckoutBLL = new CheckoutBLL();
            bool Result = aCheckoutBLL.SaveCheckOutInformation_BLL(aCustomer, aRecord, aCost);
            if (Result)
            {
                CheckOutConfirmatio_Gridview();
                MessageBox.Show("CheckOut Successfully Confirmed!!");
                Clear_Checkout_Textboxes();
            }
            else
            {
                MessageBox.Show("Please Check Your Booking ID!!");
            }
        }
        public void CheckOutConfirmatio_Gridview()
        {
            Customer aCustomer = new Customer();
            aCustomer.Id = int.Parse(bookingID_textBox1.Text);
            CheckoutBLL aCheckoutBLL = new CheckoutBLL();
            DataTable dTable = aCheckoutBLL.CheckOut_ConfirmationBLL(aCustomer);
            if (dTable == null)
            {
                MessageBox.Show("Check Booking Id!!");
            }
            else
            {
                CheckOut_Confirmation_dataGridView1.DataSource = dTable;
            }
        }

        private void Update_Checkout_button5_Click(object sender, EventArgs e)
        {
            Customer aCustomer = new Customer();
            aCustomer.Id = 0;
            int.TryParse(bookingID_textBox1.Text, out aCustomer.Id);
            aCustomer.Name = name_textBox21.Text;
            aCustomer.Age = int.Parse(age_textBox16.Text);
            aCustomer.Sex = sex_textBox12.Text;
            aCustomer.DOB = dob_textBox8.Text;
            aCustomer.Profession = profession_textBox20.Text;
            aCustomer.ProfessionAddress = professionadddresstextBox15.Text;
            aCustomer.PermanentAddress = permanentaddress_textBox11.Text;
            aCustomer.PresentAddress = presentaddress_textBox7.Text;
            aCustomer.ContactNo = contactno_textBox19.Text;
            aCustomer.Email = emial_textBox14.Text;
            aCustomer.NIDorPassportNo = nid_textBox10.Text;

            Record aRecord = new Record();
            aRecord.RoomID = int.Parse(roomid_textBox6.Text);
            aRecord.RoomNO = roomno_textBox18.Text;
            aRecord.BookingDate = reservationdate_textBox13.Text;
            aRecord.CheckInDate = checkindate_textBox9.Text;
            aRecord.CheckOutDate = checkoutdate_textBox5.Text;

            Cost aCost = new Cost();
            aCost.TotalCost = 0;
            float.TryParse(totalcost_textBox2.Text, out aCost.TotalCost);
            aCost.Due = 0;
            float.TryParse(due_textBox3.Text, out aCost.Due);
            aCost.LastPayment = 0;
            float.TryParse(payment_textBox4.Text, out aCost.LastPayment);

            float Due = float.Parse(due_textBox3.Text);
            if (Due == 0)
            {
                aRecord.PaymentStatus = " Clear ";
            }
            else if (Due > 0)
            {
                aRecord.PaymentStatus = "Due " + aCost.Due + "";
            }
            else
            {
                aRecord.PaymentStatus = "";
                MessageBox.Show("Error Payment !! Please Check");
            }

            CheckoutBLL aCheckoutBLL = new CheckoutBLL();
            bool Result = aCheckoutBLL.SaveCheckOutInformation_BLL(aCustomer, aRecord, aCost);
            if (Result)
            {
                MessageBox.Show("CheckOut Information Successfully Updated!!");
                CheckOutConfirmatio_Gridview();
                Clear_Checkout_Textboxes();
            }
            else
            {
                MessageBox.Show("Please Check Your Booking ID!!");
            }
        }
                                    
                                      //PAYMENT
       /*Confirm Payment*/ private void PaymentConfirm__button5_Click(object sender, EventArgs e)
        {
            Customer aCustomer = new Customer();
            aCustomer.Id = 0;
            int.TryParse(BookingID__textBox1.Text, out aCustomer.Id);
            aCustomer.Name = Name__textBox21.Text;
            aCustomer .Age= int.Parse (Age__textBox16.Text);
            aCustomer.Sex = Sex__textBox12.Text;
            aCustomer.DOB = Dob__textBox8.Text;
            aCustomer.Profession = Profession__textBox20.Text;
            aCustomer.ProfessionAddress = ProfessionAddress__textBox15.Text;
            aCustomer.PresentAddress = PresentAddress__textBox7.Text;
            aCustomer.PermanentAddress = PermanentAddress__textBox11.Text;
            aCustomer.ContactNo = ContactNo__textBox19.Text;
            aCustomer.Email = Email__textBox14.Text;
            aCustomer.NIDorPassportNo = Nid__textBox10.Text;

            Record aRecord = new Record();
            aRecord.RoomID = int.Parse(RoomID__textBox6.Text);
            aRecord.RoomNO = RoomNo__textBox18.Text;
            aRecord.BookingDate = ReservationDate__textBox13.Text;
            aRecord.CheckInDate = CheckInDate__textBox9.Text;
            aRecord.CheckOutDate = CheckOutDate__textBox5.Text;

            Cost aCost = new Cost();
            aCost.TotalCost = 0;
            float.TryParse(TotalCost__textBox2.Text, out aCost.TotalCost);
            aCost.Due = 0;
            float.TryParse(Due__textBox3.Text, out aCost.Due);
            aCost.LastPayment = 0;
            float.TryParse(Payment__textBox4.Text, out aCost.LastPayment);

            float Due = float.Parse(Due__textBox3.Text);
            if (Due == 0)
            {
                aRecord.PaymentStatus = " Clear ";
            }
            else if (Due > 0)
            {
                aRecord.PaymentStatus = "Due " + aCost.Due + "";
            }
            else
            {
                aRecord.PaymentStatus = "";
                MessageBox.Show("Error Payment !! Please Check");
            }
            PaymentBLL aPaymentBLL = new PaymentBLL();
            bool Result= aPaymentBLL.Confirm_PaymentBLL(aCustomer ,aRecord ,aCost );
            if (Result)
            {
                PaymentConfirmatio_Gridview();
                MessageBox.Show("Payment Successful!!");
                Clear_Payment_TextBoxes();
            }
            else
            {
                MessageBox.Show("Please Check Your Booking ID!!");
            }

        }
        public void PaymentConfirmatio_Gridview()
        {
            Customer aCustomer = new Customer();
            aCustomer.Id = int.Parse(BookingID__textBox1.Text);
            PaymentBLL aPaymentBLL = new PaymentBLL();
            DataTable dTable = aPaymentBLL.Payment_ConfirmationBLL(aCustomer);
            if (dTable == null)
            {
                MessageBox.Show("Check Booking Id!!");
            }
            else
            {
                Payment_ConfirmationdataGridView1.DataSource = dTable;
            }
        }
        private void PaymentGO__button5_Click(object sender, EventArgs e)
        {
            Info_in_PaymentPanel_textBoxes();
        }

        public void Info_in_PaymentPanel_textBoxes()
        {
            Customer aCustomer = new Customer();
            aCustomer.Id = 0;
            int.TryParse(BookingID__textBox1.Text, out aCustomer.Id);
            PaymentBLL aPaymentBLL = new PaymentBLL();
            DataTable dTable = aPaymentBLL.ViewPayment_InformationIn_textboxBLL(aCustomer);
            if (dTable == null)
            {
                MessageBox.Show("Please Enter Reservation ID!!");
            }
            else
            {
                try
                {
                    Name__textBox21.Text = dTable.Rows[0][0].ToString();
                    Age__textBox16.Text = dTable.Rows[0][1].ToString();
                    Sex__textBox12.Text = dTable.Rows[0][2].ToString();
                    Dob__textBox8.Text = dTable.Rows[0][3].ToString();
                    Profession__textBox20.Text = dTable.Rows[0][4].ToString();
                    ProfessionAddress__textBox15.Text = dTable.Rows[0][5].ToString();
                    PermanentAddress__textBox11.Text = dTable.Rows[0][6].ToString();
                    PresentAddress__textBox7.Text = dTable.Rows[0][7].ToString();
                    ContactNo__textBox19.Text = dTable.Rows[0][8].ToString();
                    Email__textBox14.Text = dTable.Rows[0][9].ToString();
                    Nid__textBox10.Text = dTable.Rows[0][10].ToString();
                    RoomID__textBox6.Text = dTable.Rows[0][11].ToString();
                    RoomNo__textBox18.Text = dTable.Rows[0][12].ToString();
                    ReservationDate__textBox13.Text = dTable.Rows[0][13].ToString();
                    CheckInDate__textBox9.Text = dTable.Rows[0][14].ToString();
                    CheckOutDate__textBox5.Text = dTable.Rows[0][15].ToString();
                    TotalCost__textBox2.Text = dTable.Rows[0][16].ToString();
                    Due__textBox3.Text = dTable.Rows[0][17].ToString();
                    DUE___textBox1.Text = dTable.Rows[0][17].ToString();
                    DateTime Checkin = (DateTime)dTable.Rows[0][14];
                    DateTime Checkout = (DateTime)dTable.Rows[0][15];
                    NoofDays__textBox17.Text = (Checkout - Checkin).TotalDays.ToString();
                    this.ActiveControl = Payment__textBox4;
                }
                catch
                {
                    MessageBox.Show("Please Check your Booking ID!!");
                }

            }
        }

        private void Payment__textBox4_TextChanged(object sender, EventArgs e)
        {

            try {
                float totalDue = float.Parse(DUE___textBox1.Text);
                float payment = 0;
                float.TryParse(Payment__textBox4.Text, out payment);
                float Due = totalDue - payment;
                Due__textBox3.Text = Due.ToString();
            }
            catch
            {

            }
        }

        private void payment_textBox4_TextChanged(object sender, EventArgs e)
        {
            try {
                float totalDue = float.Parse(DUE___textBox1.Text);
                float payment = 0;
                 payment = float.Parse(payment_textBox4.Text);
                float Due = totalDue - payment;
                due_textBox3.Text = Due.ToString();
            }
            catch
            {

            }
            
        }

        private void PAyment_textBox24_TextChanged(object sender, EventArgs e)
        {
            try {
                float totaldue = float.Parse(DUE___textBox1.Text);
                float payment =0;
                payment = float.Parse(PAyment_textBox24.Text);
                float Due = totaldue - payment;
                DUe_textBox23.Text = Due.ToString();
            }
            catch
            {

            }
        }

        private void PaymentUpdate__button6_Click(object sender, EventArgs e)
        {
            try
            {
                Customer aCustomer = new Customer();
                aCustomer.Id = 0;
                int.TryParse(BookingID__textBox1.Text, out aCustomer.Id);
                aCustomer.Name = Name__textBox21.Text;
                aCustomer.Age = int.Parse(Age__textBox16.Text);
                aCustomer.Sex = Sex__textBox12.Text;
                aCustomer.DOB = Dob__textBox8.Text;
                aCustomer.Profession = Profession__textBox20.Text;
                aCustomer.ProfessionAddress = ProfessionAddress__textBox15.Text;
                aCustomer.PresentAddress = PresentAddress__textBox7.Text;
                aCustomer.PermanentAddress = PermanentAddress__textBox11.Text;
                aCustomer.ContactNo = ContactNo__textBox19.Text;
                aCustomer.Email = Email__textBox14.Text;
                aCustomer.NIDorPassportNo = Nid__textBox10.Text;

                Record aRecord = new Record();
                aRecord.RoomID = int.Parse(RoomID__textBox6.Text);
                aRecord.RoomNO = RoomNo__textBox18.Text;
                aRecord.BookingDate = ReservationDate__textBox13.Text;
                aRecord.CheckInDate = CheckInDate__textBox9.Text;
                aRecord.CheckOutDate = CheckOutDate__textBox5.Text;

                Cost aCost = new Cost();
                aCost.TotalCost = 0;
                float.TryParse(TotalCost__textBox2.Text, out aCost.TotalCost);
                aCost.Due = 0;
                float.TryParse(Due__textBox3.Text, out aCost.Due);
                aCost.LastPayment = 0;
                float.TryParse(Payment__textBox4.Text, out aCost.LastPayment);

                float Due = float.Parse(Due__textBox3.Text);
                if (Due == 0)
                {
                    aRecord.PaymentStatus = " Clear ";
                }
                else if (Due > 0)
                {
                    aRecord.PaymentStatus = "Due " + aCost.Due + "";
                }
                else
                {
                    aRecord.PaymentStatus = "";
                    MessageBox.Show("Error Payment !! Please Check");
                }
                PaymentBLL aPaymentBLL = new PaymentBLL();
                bool Result = aPaymentBLL.Confirm_PaymentBLL(aCustomer, aRecord, aCost);
                if (Result)
                {
                    PaymentConfirmatio_Gridview();
                    MessageBox.Show(" Payment Updated Successfully!!");
                    Clear_Payment_TextBoxes();


                }
                else
                {
                    MessageBox.Show("Please Check Your Booking ID!!");
                }
            }
            catch
            {

            }
            

        }
        public void Clear_Payment_TextBoxes()
        {
            BookingID__textBox1.Text = "";
            Name__textBox21.Text = "";
            Age__textBox16.Text = "";
            Sex__textBox12.Text = "";
            Dob__textBox8.Text = "";
            Profession__textBox20.Text = "";
            ProfessionAddress__textBox15.Text = "";
            PermanentAddress__textBox11.Text = "";
            PresentAddress__textBox7.Text = "";
            ContactNo__textBox19.Text = "";
            Email__textBox14.Text = "";
            Nid__textBox10.Text = "";
            RoomID__textBox6.Text = "";
            RoomNo__textBox18.Text = "";
            ReservationDate__textBox13.Text = "";
            CheckInDate__textBox9.Text = "";
            CheckOutDate__textBox5.Text = "";
            TotalCost__textBox2.Text = "";
            Due__textBox3.Text = "";
            NoofDays__textBox17.Text ="";
            Payment__textBox4.Text = "";
        }

        private void ClearPaymentTextboxes__button7_Click(object sender, EventArgs e)
        {
            Clear_Payment_TextBoxes();
        }


                               //Search
        private void button5_Click_1(object sender, EventArgs e)
        {
            SerachInformation();
        }
        private void SerachInformation()
        {
            Customer aCustomer = new Customer();
            aCustomer.Name = Nam_textBox1.Text;
            aCustomer.Age = 0;
            int.TryParse(Ag_textBox2.Text, out aCustomer.Age);
            aCustomer.Id = 0;
            int.TryParse(Book_ID_textBox3.Text, out aCustomer.Id);
            aCustomer.PresentAddress = PreAdd_textBox5.Text;
            aCustomer.PermanentAddress = PerAdd_textBox7.Text;
            aCustomer.ProfessionAddress = ProfAdd_textBox6.Text;
            aCustomer.ContactNo = Cont_textBox8.Text;
            aCustomer.Email = Em_textBox12.Text;
            aCustomer.NIDorPassportNo = NiorPass_textBox9.Text;

            Record aRecord = new Record();
            aRecord.BookingDate = ReserveDate_textBox13.Text;
            aRecord.CheckInDate = Check_I_Date_textBox14.Text;
            aRecord.CheckOutDate = Check_o_Date_textBox15.Text;
            aRecord.RoomNO = r_no_textBox10.Text;
            Room aRoom = new Room();
            aRoom.Floor = Floor_textBox11.Text;

            SearchBLL aSearchBLL = new SearchBLL();
            DataTable dTable = aSearchBLL.SearchResultBLL(aCustomer, aRecord, aRoom);
            if (dTable == null)
            {
                MessageBox.Show("Enter Any Keyword To Search!!");
            }
            else
            {
                Search_dataGridView1.DataSource = dTable;
            }
        }

        private void ReserveDate_textBox13_MouseClick(object sender, MouseEventArgs e)
        {
            ReserveDate_textBox13.Text ="";
            ReserveDate_textBox13.ForeColor = Color.Black;
        }

        private void Check_I_Date_textBox14_MouseClick(object sender, MouseEventArgs e)
        {
            Check_I_Date_textBox14.Text = "";
            Check_I_Date_textBox14.ForeColor = Color.Black;
        }

        private void Check_o_Date_textBox15_MouseClick(object sender, MouseEventArgs e)
        {
            Check_o_Date_textBox15.Text = "";
            Check_o_Date_textBox15.ForeColor = Color.Black;
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            Clear_SeacrchPanelTextBOXES();
        }
        private void Clear_SeacrchPanelTextBOXES()
        {
            Book_ID_textBox3.Text = "";
            Nam_textBox1.Text = "";
            Ag_textBox2.Text = ""; ;
            BookingID__textBox1.Text = "";
            PreAdd_textBox5.Text = "";
            PerAdd_textBox7.Text = "";
            ProfAdd_textBox6.Text = "";
            Cont_textBox8.Text = "";
            Em_textBox12.Text = "";
            NiorPass_textBox9.Text = "";
            ReserveDate_textBox13.Text = "";
            Check_I_Date_textBox14.Text = "";
            Check_o_Date_textBox15.Text = "";
            r_no_textBox10.Text = "";
            Floor_textBox11.Text = "";
            Payment__textBox4.Text = "";
          

        }

        private void ClearAdminTextboxes_button10_Click(object sender, EventArgs e)
        {
            ClearTextBoxesIn_ADMIN_panel();
        }
        public void ClearTextBoxesIn_ADMIN_panel()
        {

            RmNo_textBox1.Text = "";
            Rm_Floor_comboBox1.Text = "";
            Rm_Type_comboBox2.Text = "";
            Rm_Type_comboBox2.Text = "";
            RmClass_comboBox3.Text = "";
            RmRent_textBox2.Text = "";
            CreateUserID_textBox1.Text = "";
            CreateUserID_PasswordtextBox2.Text = "";
            UserIDD_textBox2.Text = "";
            Pass_textBox1.Text = "";
            Updateroom_button8.Enabled = false;
            Deleteroom_button9.Enabled = false;
            SAVEroom_button7.Enabled = true;
            this.ActiveControl = RmNo_textBox1;

            
        }
        public void ShowExistingRooms()
        {
            RoomBLL aRoomBLL = new RoomBLL();
            DataTable dTable= aRoomBLL.ExistingRoomsBLL();
            ExisingRooms_inAdmin_dataGridView1.DataSource = dTable;
        }

        private void SAVEroom_button7_Click(object sender, EventArgs e)
        {
            Room aRoom = new Room();
            aRoom.Id = 0;
            int.TryParse(RoomID_label117.Text ,out aRoom.Id);
            aRoom.RoomNo = RmNo_textBox1.Text;
            aRoom.Floor = Rm_Floor_comboBox1.Text;
            aRoom.Type = Rm_Type_comboBox2.Text;
            aRoom.Class = RmClass_comboBox3.Text;
            aRoom.Rent = 0;
            float.TryParse(RmRent_textBox2.Text,out aRoom .Rent);

            RoomBLL aRoomBLL = new RoomBLL();
            bool rEsult = aRoomBLL.SaveRoomsBLL(aRoom);
            if (rEsult)
            {
                ShowExistingRooms();
                MessageBox.Show("Room Information Successfully Saved!!");
                ClearTextBoxesIn_ADMIN_panel();
            }
            else
            {
                MessageBox.Show("Error!Please Check Given Information!!"); 
            }
        }

        private void Updateroom_button8_Click(object sender, EventArgs e)
        {
            Room aRoom = new Room();
            aRoom.Id = 0;
            int.TryParse(RoomID_label117.Text, out aRoom.Id);
            aRoom.RoomNo = RmNo_textBox1.Text;
            aRoom.Floor = Rm_Floor_comboBox1.Text;
            aRoom.Type = Rm_Type_comboBox2.Text;
            aRoom.Class = RmClass_comboBox3.Text;
            aRoom.Rent = 0;
            float.TryParse(RmRent_textBox2.Text, out aRoom.Rent);

            RoomBLL aRoomBLL = new RoomBLL();
            bool rEsult = aRoomBLL.UpdateRoomInfoLBL(aRoom);
            if (rEsult)
            {
                ShowExistingRooms();
                MessageBox.Show("Room Information Successfully Updated!!");
                ClearTextBoxesIn_ADMIN_panel();
            }
            else
            {
                MessageBox.Show("Error!Please Check Given Information!!");
            }
        }

        private void Deleteroom_button9_Click(object sender, EventArgs e)
        {
            Room aRoom = new Room();
            aRoom.Id = 0;
            int.TryParse(RoomID_label117.Text, out aRoom.Id);
            RoomBLL aRoomBLL = new RoomBLL();
            bool result= aRoomBLL.DeleteRoomsDAL(aRoom);
            if (result)
            {
                ShowExistingRooms();
                MessageBox.Show("Room Successfully Deleted!!");
                ClearTextBoxesIn_ADMIN_panel();
            }
            else
            {
                MessageBox.Show("ERROR!! Check Room ID!");
            }
        }

        private void Rm_Floor_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ExisingRooms_inAdmin_dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RoomID_label117.Text = ExisingRooms_inAdmin_dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            RmNo_textBox1.Text = ExisingRooms_inAdmin_dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            Rm_Floor_comboBox1.Text = ExisingRooms_inAdmin_dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Rm_Type_comboBox2 .Text = ExisingRooms_inAdmin_dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            RmClass_comboBox3.Text= ExisingRooms_inAdmin_dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            RmRent_textBox2.Text= ExisingRooms_inAdmin_dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            Updateroom_button8.Enabled = true;
            Deleteroom_button9.Enabled = true;
            SAVEroom_button7.Enabled = false;
        }

        private void BookingID__textBox1_TextChanged(object sender, EventArgs e)
        {
            Payment_ConfirmationdataGridView1.DataSource = null;
        }

        private void BookingID__textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter )
            {
                Info_in_PaymentPanel_textBoxes();
            }

        }

        private void bookingID_textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Infoin_CheckOUT_Textboses();
            }
        }

        private void Cencel_Checkout_button7_Click(object sender, EventArgs e)
        {
            Cost aCost = new Cost();
            aCost.LastPayment = float.Parse(payment_textBox4.Text);
            aCost.Due = 0;
            float.TryParse(due_textBox3.Text, out aCost.Due);

            int ReservationId = int.Parse(bookingID_textBox1.Text);
            CheckoutBLL aCheckOutBll = new CheckoutBLL();
            bool result = aCheckOutBll.Cancel_checkOutBLL(ReservationId,aCost);
            if (result)
            {
                MessageBox.Show("Check Out Cancelled Successfully");
            }
            else
            {
                MessageBox.Show("Error !! Check Reservation ID ");
            }
        }

        private void Cancel_Payment_button7_Click(object sender, EventArgs e)
        {
            Cost aCost = new Cost();
            aCost.LastPayment = 0;
            float.TryParse(Payment__textBox4.Text, out aCost.LastPayment);
            aCost.Due = 0;
            float.TryParse(Due__textBox3.Text ,out  aCost.Due);
            int ReservationId = int.Parse(BookingID__textBox1.Text);
            PaymentBLL aPaymentBLL = new PaymentBLL();
            bool result = aPaymentBLL .Payment_Cancel(ReservationId, aCost);
            if (result)
            {
                MessageBox.Show("Payment Cancelled Successfully");
            }
            else
            {
                MessageBox.Show("Error !! Check Reservation ID ");
            }
        }

        private void BooingID_InCheckin_textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Info_in_CheckinPanel_textboxes();
            }
            
        }

        private void BooingID_InCheckin_textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Checkin_cinfirmationdataGridView1.DataSource = null;
        }

        private void Cencel_Checkin_button7_Click(object sender, EventArgs e)
        {
            Cost aCost = new Cost();
            aCost.LastPayment = 0;
            float.TryParse(PAyment_textBox24.Text, out aCost.LastPayment);
            aCost.Due = 0; 
            float.TryParse(DUe_textBox23.Text, out aCost.Due);
            int ReservationId = int.Parse(BooingID_InCheckin_textBox1.Text);
            CheckOutBLL aCheckOutBll = new CheckOutBLL();
            bool result = aCheckOutBll.Cancel_checkInBLL(ReservationId,aCost);
            if(result)
            {
                MessageBox.Show("Check In Cancelled Successfully");
            }
            else
            {
                MessageBox.Show("Error !! Check Reservation ID ");
            }
        }


        //REPORTING
        public string ReportType;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReportType_comboBox1.Text == "Customer Billing Slip ")
            {
                ReportType = "Customer Billing Slip ";
                SpecificSearch_TextBox_showpanel10.Visible = true;
                CustomReport_panel10.Visible = false;
            }
            else if (ReportType_comboBox1.Text == "Specific Customer Details")
            {
                ReportType = "Specific Customer Details";
                SpecificSearch_TextBox_showpanel10.Visible = true;
                CustomReport_panel10.Visible = false;
            }
            else if (ReportType_comboBox1.Text == "All Room Details ")
            {
                ReportType = "All Room Details ";
                SpecificSearch_TextBox_showpanel10.Visible =false;
                CustomReport_panel10.Visible = false;
            }
            else if (ReportType_comboBox1.Text == "Report of  This  Week ")
            {
                ReportType = "Report of  This  Week ";
                SpecificSearch_TextBox_showpanel10.Visible = false;
                CustomReport_panel10.Visible = false;
            }
            else if (ReportType_comboBox1.Text == "Report of Current Month ")
            {
                ReportType = "Report of Current Month";
                SpecificSearch_TextBox_showpanel10.Visible = false;
                CustomReport_panel10.Visible = false;
            }
            else if (ReportType_comboBox1.Text == "Report of  Last 15 Days")
            {
                ReportType = "Report of  Last 15 Days";
                SpecificSearch_TextBox_showpanel10.Visible = false;
                CustomReport_panel10.Visible = false;
            }
            else
            {
                ReportType = "Customized  Report";
                SpecificSearch_TextBox_showpanel10.Visible = false;
                CustomReport_panel10.Visible =true;
            }
        }
                    
                        /*View Report Button*/

        private void button7_Click(object sender, EventArgs e)
        {
            ViewReport();
        }
        private void ViewReport()
        {
            if (ReportType_comboBox1.Text == "Customer Billing Slip ")
            {
                ReportDocument RepDoc = new ReportDocument();
                Customer aCustomer = new Customer();
                aCustomer.Id = 0;
                int.TryParse(ReservationID_Reporting_textBox1.Text, out aCustomer.Id);
                ReportingBLL aReportingBLL = new ReportingBLL();
                DataTable dTable = aReportingBLL.Customer_Billing_SlipBLL(aCustomer, ReportType);
                CustomerBilling_SlipCrystalReport1 aBilling = new CustomerBilling_SlipCrystalReport1();
                aBilling.SetDataSource(dTable);
                Hotel_Management_System_crystalReportViewer1.ReportSource = aBilling;
                ClearReporting_Panel_textBoxes();
            }
            if (ReportType_comboBox1.Text == "Specific Customer Details")
            {
                ReportDocument RepDoc = new ReportDocument();
                Customer aCustomer = new Customer();
                aCustomer.Id = 0;
                int.TryParse(ReservationID_Reporting_textBox1.Text, out aCustomer.Id);
                ReportingBLL aReportingBLL = new ReportingBLL();
                DataTable dTable = aReportingBLL.Specific_Customer_DetailsBLL(aCustomer, ReportType);
                Customer_Detaisls_CrystalReport1 cDetails = new Customer_Detaisls_CrystalReport1();
              
                cDetails.SetDataSource(dTable);
                Hotel_Management_System_crystalReportViewer1.ReportSource = cDetails;
                ClearReporting_Panel_textBoxes();
            }
            if (ReportType_comboBox1.Text == "All Room Details ")
            {
                ReportDocument RepDoc = new ReportDocument();
                ReportingBLL aReportingBLL = new ReportingBLL();
                DataTable dTable = aReportingBLL.AllRoomDetaisBLL();
                All_Room_DetailsCrystalReport1 allRoom = new All_Room_DetailsCrystalReport1();
                
                allRoom.SetDataSource(dTable);
                Hotel_Management_System_crystalReportViewer1.ReportSource = allRoom;
                ClearReporting_Panel_textBoxes();
            }
            if (ReportType_comboBox1.Text == "Report of  This  Week ")
            {
                string TodayDate = Date_dateTimePicker1.Value.ToString("yyyy-MM-dd");
                ReportDocument RepDoc = new ReportDocument();
                ReportingBLL aReportingBLL = new ReportingBLL();
                DataTable dTable = aReportingBLL.Current_week_reportBLL(TodayDate);
                Current_Week_Reocrd_CrystalReport1 rWeek = new Current_Week_Reocrd_CrystalReport1(); 
                rWeek.SetDataSource(dTable);
                Hotel_Management_System_crystalReportViewer1.ReportSource = rWeek;
                ClearReporting_Panel_textBoxes();
            }
            if (ReportType_comboBox1.Text == "Report of Current Month ")
            {
                string TodayDate = Date_dateTimePicker1.Value.ToString("yyyy-MM-dd");
                ReportDocument RepDoc = new ReportDocument();
                ReportingBLL aReportingBLL = new ReportingBLL();
                DataTable dTable = aReportingBLL.Current_Month_reportBLL(TodayDate);
                Current_Month_Record_CrystalReport1 rCMonth = new Current_Month_Record_CrystalReport1();
                
                rCMonth.SetDataSource(dTable);
                Hotel_Management_System_crystalReportViewer1.ReportSource = rCMonth;
                ClearReporting_Panel_textBoxes();
            }
            if (ReportType_comboBox1.Text == "Report of  Last 15 Days")
            {
                string TodayDate = Date_dateTimePicker1.Value.ToString("yyyy-MM-dd");
                ReportDocument RepDoc = new ReportDocument();
                ReportingBLL aReportingBLL = new ReportingBLL();
                DataTable dTable = aReportingBLL.Last_15Days_reportBLL(TodayDate);
                Last_15_Days_Report_CrystalReport1 cr15Days = new Last_15_Days_Report_CrystalReport1(); 
                cr15Days.SetDataSource(dTable);
                Hotel_Management_System_crystalReportViewer1.ReportSource =cr15Days;
                ClearReporting_Panel_textBoxes();
            }
            if (ReportType_comboBox1.Text == "Customized  Report")
            {
                Customer aCustomer = new Customer();
                aCustomer.FromDate = FromDate_dateTimePicker1.Value.ToString("yyyy-MM-dd");
                aCustomer.ToDate = ToDate_dateTimePicker2.Value.ToString("yyyy-MM-dd");
            }
        }
        public void ClearReporting_Panel_textBoxes()
        {
            ReportType_comboBox1.Text = "";
            ReservationID_Reporting_textBox1.Text = "";
            ReportingBLL aReportingBLL = new ReportingBLL();
        }

        private void RmNo_textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = RmRent_textBox2;
            }
        }

        private void ReportType_comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ViewReport();
            }
        }

        private void ReservationID_Reporting_textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ViewReport();
            }
        }

        private void RmRent_textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = RmNo_textBox1;
            }

        }

        private void Book_ID_textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Nam_textBox1;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SerachInformation();
            }
        }

        private void Nam_textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Ag_textBox2;
            }
            if (e.KeyCode == Keys.Up )
            {
                this.ActiveControl = Book_ID_textBox3;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SerachInformation();
            }

        }

        private void Ag_textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = PreAdd_textBox5;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Nam_textBox1;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SerachInformation();
            }
        }

        private void PreAdd_textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = PerAdd_textBox7;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Ag_textBox2;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SerachInformation();
            }
        }

        private void PerAdd_textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = ProfAdd_textBox6;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = PreAdd_textBox5;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SerachInformation();
            }
        }

        private void ProfAdd_textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Cont_textBox8;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = PerAdd_textBox7;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SerachInformation();
            }
        }

        private void Cont_textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Em_textBox12;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = ProfAdd_textBox6;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SerachInformation();
            }
        }

        private void Em_textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = NiorPass_textBox9;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Cont_textBox8;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SerachInformation();
            }
        }

        private void NiorPass_textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Floor_textBox11;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Em_textBox12;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SerachInformation();
            }
        }

        private void Floor_textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = r_no_textBox10;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = NiorPass_textBox9;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SerachInformation();
            }
        }

        private void r_no_textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = ReserveDate_textBox13;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Floor_textBox11;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SerachInformation();
            }
        }

        private void ReserveDate_textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Check_I_Date_textBox14;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = r_no_textBox10;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SerachInformation();
            }
        }

        private void Check_I_Date_textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Check_o_Date_textBox15;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = ReserveDate_textBox13;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SerachInformation();
            }
        }
        private void Check_o_Date_textBox15_KeyDown(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Check_I_Date_textBox14;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SerachInformation();
            }
        }

        private void Name__textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Age__textBox16;
            }
        }

        private void Age__textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl =Sex__textBox12;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl =Name__textBox21;
            }
        }

        private void Sex__textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl =Dob__textBox8;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Age__textBox16;
            }
        }
        private void Dob__textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl =Profession__textBox20;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Sex__textBox12;
            }
        }
        private void Profession__textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = ProfessionAddress__textBox15;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Dob__textBox8;
            }
        }

        private void ProfessionAddress__textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = PermanentAddress__textBox11;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Profession__textBox20;
            }
        }

        private void PermanentAddress__textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = PresentAddress__textBox7;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = ProfessionAddress__textBox15;
            }
        }

        private void PresentAddress__textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = ContactNo__textBox19;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = PermanentAddress__textBox11;
            }
        }

        private void ContactNo__textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Email__textBox14;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = PresentAddress__textBox7;
            }
        }

        private void Email__textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Nid__textBox10;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = ContactNo__textBox19;
            }
        }

        private void Nid__textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = RoomID__textBox6;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Email__textBox14;
            }
        }

        private void RoomID__textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = RoomNo__textBox18;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Nid__textBox10;
            }
        }

        private void RoomNo__textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = ReservationDate__textBox13;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = RoomID__textBox6;
            }
        }

        private void ReservationDate__textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = CheckInDate__textBox9;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = RoomNo__textBox18;
            }
        }

        private void CheckInDate__textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = CheckOutDate__textBox5;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = ReservationDate__textBox13;
            }
        }

        private void CheckOutDate__textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = NoofDays__textBox17;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = CheckInDate__textBox9;
            }
        }

        private void NoofDays__textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = TotalCost__textBox2;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = CheckOutDate__textBox5;
            }
        }

        private void TotalCost__textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Due__textBox3;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = NoofDays__textBox17;
            }
        }

        private void Due__textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Payment__textBox4;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = TotalCost__textBox2;
            }
        }

        private void Payment__textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Due__textBox3;
            }
        }


        private void name_textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = age_textBox16;
            }
        }

        private void age_textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = sex_textBox12;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = name_textBox21;
            }
        }

        private void sex_textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = dob_textBox8;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = age_textBox16;
            }
        }

        private void dob_textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = profession_textBox20;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = sex_textBox12;
            }
        }

        private void profession_textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = professionadddresstextBox15;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = dob_textBox8;
            }
        }

        private void professionadddresstextBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = permanentaddress_textBox11;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = profession_textBox20;
            }
        }

        private void permanentaddress_textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = presentaddress_textBox7;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = professionadddresstextBox15;
            }
        }

        private void presentaddress_textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = contactno_textBox19;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = permanentaddress_textBox11;
            }
        }

        private void contactno_textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = emial_textBox14;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = presentaddress_textBox7;
            }
        }

        private void emial_textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = nid_textBox10;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = contactno_textBox19;
            }
        }

        private void nid_textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = roomid_textBox6;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = emial_textBox14;
            }
        }

        private void roomid_textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = roomno_textBox18;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = nid_textBox10;
            }
        }

        private void roomno_textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = reservationdate_textBox13;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = roomid_textBox6;
            }
        }

        private void reservationdate_textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = checkindate_textBox9;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = roomno_textBox18;
            }
        }

        private void checkindate_textBox9_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void checkindate_textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = checkoutdate_textBox5;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = reservationdate_textBox13;
            }
        }

        private void checkoutdate_textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = no_of_days_textBox17;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = checkindate_textBox9;

            }
        }

        private void no_of_days_textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = totalcost_textBox2;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = checkoutdate_textBox5;
            }
        }

        private void totalcost_textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = due_textBox3;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = no_of_days_textBox17;
            }
        }

        private void due_textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = payment_textBox4;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = totalcost_textBox2;
            }
        }

        private void payment_textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = due_textBox3;
            }
        }

        private void NAme_textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = AGe_textBox3;
            }
            
        }

        private void AGe_textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void AGe_textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = SEx_textBox4;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = NAme_textBox2;
            }
        }

        private void SEx_textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = DOb_textBox5;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = AGe_textBox3;
            }
        }

        private void DOb_textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = PRofession_textBox7;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = SEx_textBox4;
            }
        }

        private void PRofession_textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = PRofessionADdress_;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = DOb_textBox5;
            }
        }

        private void PRofessionADdress__KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = PArmanentADdress_;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = PRofession_textBox7;
            }
        }

        private void PArmanentADdress__KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = PResentADdress_textBox10;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = PRofessionADdress_;
            }
        }

        private void PResentADdress_textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = COntactNO_textBox12;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = PArmanentADdress_;
            }
        }

        private void COntactNO_textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = EMail_textBox13;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = PResentADdress_textBox10;
            }
        }

        private void EMail_textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = NId_textBox14;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = COntactNO_textBox12;
            }
        }

        private void NId_textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = ROomId_textBox15;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = EMail_textBox13;
            }
        }

        private void ROomId_textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = ROomNO_textBox17;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = NId_textBox14;
            }
        }

        private void ROomNO_textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = REservationDate_textBox18;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = ROomId_textBox15;
            }
        }

        private void REservationDate_textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = CHeckinDate_textBox19;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = ROomNO_textBox17;
            }
        }

        private void CHeckinDate_textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = CHeckOutDate_textBox20;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = REservationDate_textBox18;
            }
        }

        private void CHeckOutDate_textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = NO_of_daystextBox1;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = CHeckinDate_textBox19;
            }
        }

        private void NO_of_daystextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = TOtalCost_textBox22;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = CHeckOutDate_textBox20;
            }
        }

        private void TOtalCost_textBox22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = DUe_textBox23;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = NO_of_daystextBox1;
            }
        }

        private void DUe_textBox23_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = PAyment_textBox24;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = TOtalCost_textBox22;
            }
        }

        private void PAyment_textBox24_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = DUe_textBox23;
            }
        }

        private void Name_textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = DOB_dateTimePicker1;
            }
        }

        private void DOB_dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Age_textBox2;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Name_textBox1;
            }
        }

        private void Age_textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Profession_textBox3;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = DOB_dateTimePicker1;
            }
        }

        private void Profession_textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = ProfessionAddress_textBox4;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Age_textBox2;
            }
        }

        private void ProfessionAddress_textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = PermanentAddress_textBox5;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Age_textBox2;
            }
        }

        private void PermanentAddress_textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = PresentAddress_textBox6;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = ProfessionAddress_textBox4;
            }
        }

        private void PresentAddress_textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = ContactNo_textBox7;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = ProfessionAddress_textBox4;
            }
        }

        private void ContactNo_textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Email_textBox8;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = PresentAddress_textBox6;
            }
        }

        private void Email_textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = NID_textBox9;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = ContactNo_textBox7;
            }
        }

        private void NID_textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                this.ActiveControl = RoomID_textBox10;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = ContactNo_textBox7;
            }
        }

        private void RoomID_textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                this.ActiveControl = RoomNo_textBox11;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = NID_textBox9;
            }
        }

        private void RoomNo_textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = ReservationDate_dateTimePicker3;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = RoomID_textBox10;
            }
        }

        private void ReservationDate_dateTimePicker3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = CheckinDate_dateTimePicker4;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = RoomNo_textBox11;
            }
        }

        private void CheckinDate_dateTimePicker4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = CheckOutDate_dateTimePicker2;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = ReservationDate_dateTimePicker3;
            }
        }

        private void CheckOutDate_dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = NoOfDays_textBox15;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = ReservationDate_dateTimePicker3;
            }
        }

        private void NoOfDays_textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = TotalCost_textBox12;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = CheckOutDate_dateTimePicker2;
            }
        }

        private void TotalCost_textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Payment_textBox13;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = NoOfDays_textBox15;
            }
        }

        private void Due_textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = TotalCost_textBox12;
            }
        }

        private void BookingID__textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Payment_ConfirmationdataGridView1.DataSource = null;
        }

        private void bookingID_textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            CheckOut_Confirmation_dataGridView1.DataSource = null;
        }

        private void ViewRecord_byTimePeriodcomboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Home_dataGridView1.DataSource =null;
        }

        private void roomInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpecificSearch_TextBox_showpanel10.Visible = false;
            HH.Visible = false;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = false;
            pepH.Visible = false;
            rinfoH.Visible = true;

            Home_panel.Visible = false;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = false;
            Search_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = false;
            ShowExistingRooms();
            Clear_all_Panel_textboxes();
            AdminAccess_Checkin_panel20.Visible = true;
            this.ActiveControl = AdminAccess_UserName_textBox1;

            Room_Input_radioButton4.Checked = true;
            Backup_orRestoreDatabase_radioButton1.Checked = false;
            CreateAcces_radioButton5.Checked = false;
            DeleteORupdateradioButton6.Checked = false;

            label147.Text = "";
        }

        private void systemAccessSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void createAccessIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAcces_radioButton5.Checked = true;
            Backup_orRestoreDatabase_radioButton1.Checked = false;
            Room_Input_radioButton4.Checked = false;
            DeleteORupdateradioButton6.Checked = false;

            SpecificSearch_TextBox_showpanel10.Visible = false;
            HH.Visible = false;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = false;
            pepH.Visible = false;
            rinfoH.Visible = true;

            Home_panel.Visible = false;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = false;
            Search_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = false;
            ShowExistingRooms();
            Clear_all_Panel_textboxes();
            AdminAccess_Checkin_panel20.Visible = true;
        }
        private void View_existingUserAccess(SystemAccess aSystemAccess)
        {
            SystemAccessBLL aSystemBLL = new SystemAccessBLL();
            DataTable dTable = aSystemBLL.View_Existing_UserAccessBLL(aSystemAccess);
            View_existing_User_dataGridView1.DataSource = dTable;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            SystemAccess aSystemAccess = new SystemAccess();
            aSystemAccess.Username = CreateUserID_textBox1.Text;
            aSystemAccess.Password = CreateUserID_PasswordtextBox2.Text;
            SystemAccessBLL aSystemBLL = new SystemAccessBLL();
            bool result= aSystemBLL.Save_new_AccessBLL(aSystemAccess);
            if (result )
            {
                View_existingUserAccess(aSystemAccess);
                MessageBox.Show("New User ID created Successfully!!!");
                Clear_all_Panel_textboxes();

            }
        }
       
        
        private void button10_Click(object sender, EventArgs e)
        {
            CreateUserID_textBox1.Text = "";
            CreateUserID_PasswordtextBox2.Text = "";
            Designation_textBox1.Text = "";
        }

        private void updateOrDeleteAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpecificSearch_TextBox_showpanel10.Visible = false;
            HH.Visible = false;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = false;
            pepH.Visible = false;
            rinfoH.Visible = true;

            Home_panel.Visible = false;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = false;
            Search_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = false;
            ShowExistingRooms();
            Clear_all_Panel_textboxes();
            AdminAccess_Checkin_panel20.Visible = true;
            DeleteORupdateradioButton6.Checked = true;
            Backup_orRestoreDatabase_radioButton1.Checked =false;
            Room_Input_radioButton4.Checked = false;
            CreateAcces_radioButton5.Checked = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string EncriptedPassword = EncryptPassword(Pass_textBox1.Text);
            SystemAccess aSystemAccess = new SystemAccess();
            aSystemAccess.Username = UserIDD_textBox2.Text;
            aSystemAccess.Password = EncriptedPassword;
            aSystemAccess.UserType = comboBox1.Text;
            SystemAccessBLL aSystemBLL = new SystemAccessBLL();
            bool result = aSystemBLL. Delete_UserAccessBLL(aSystemAccess);
            if (result)
            {
                View_existingUserAccess(aSystemAccess);
                MessageBox.Show("New User ID created Successfully!!!");
                Clear_all_Panel_textboxes();

            }
        }

        private void View_existing_User_dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string DecryptedPassword = DecryptPassword(View_existing_User_dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            UserIDD_textBox2.Text = View_existing_User_dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Pass_textBox1.Text = DecryptedPassword;
            Designation_textBox1.Text = View_existing_User_dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
        private void Clear_CreateAccess()
        {
            UserIDD_textBox2.Text = "";
            Pass_textBox1.Text = "";
            comboBox1.Text = "";
            Designation_textBox1.Text = "";
        }
        private void button12_Click(object sender, EventArgs e)
        {
            Clear_CreateAccess();
        }
        public string Designation;

        public string DecryptPassword(string Pass)
        {

            byte[] data = Convert.FromBase64String(Pass);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    string res = UTF8Encoding.UTF8.GetString(results);
                    return res;
                }
            }
            
        }
        private void UpdateUser_access_Info_button9_Click(object sender, EventArgs e)
        {
            string DecryptedPassword = EncryptPassword(Pass_textBox1.Text);
            SystemAccess aSystemAccess = new SystemAccess();
            aSystemAccess.Username = UserIDD_textBox2.Text;
            aSystemAccess.Password = DecryptedPassword;
            aSystemAccess.UserType = Designation_textBox1.Text;
            SystemAccessBLL aSystemBLL = new SystemAccessBLL();
            bool result = aSystemBLL.Update_UserAccess_BLL(aSystemAccess);
            if (result)
            {
                View_existingUserAccess(aSystemAccess);
                MessageBox.Show("New User ID Ipdated Successfully!!!");
                Clear_all_Panel_textboxes();

            }

        }

        private void label130_Click(object sender, EventArgs e)
        {

        }

        private void label133_Click(object sender, EventArgs e)
        {

        }

        private void GO_Discount_button9_Click(object sender, EventArgs e)
        {
            Cost aCost = new Cost();
            aCost.Id = 0;
            int.TryParse (RtextBox1.Text,out aCost .Id);
            PaymentBLL aPaymentBLL = new PaymentBLL();
            DataTable dTable = aPaymentBLL.Get_CustomerDetails_For_DiscountBLL(aCost);
            if (dTable ==null )
            {
                MessageBox.Show("Please Insert Reservation ID!!");
            }
            else
            {
                try
                {
                    Discount_RID_textBox2.Text = dTable.Rows[0][0].ToString();
                    DiscountCustomer_NametextBox3.Text = dTable.Rows[0][1].ToString();
                    Discount_Customer_TotalBill_textBox4.Text = dTable.Rows[0][2].ToString();
                    DUE___textBox1.Text = dTable.Rows[0][2].ToString();
                    Discount_Due_textBox5.Text = dTable.Rows[0][3].ToString();
                    RtextBox1.Text = "";

                    this.ActiveControl = Discount_AmmounttextBox6;
                }
                catch
                {
                    MessageBox.Show("Error ");
                }
                
            }
        }

        private void Discount_AmmounttextBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float all = float.Parse(DUE___textBox1.Text);
                float discount = 0;
                 discount = float.Parse(Discount_AmmounttextBox6.Text);
                float Totals = all - discount;
                Discount_Customer_TotalBill_textBox4.Text = Totals.ToString();
            }
            catch 
           {

            }
        }

        private void SaveDiscount_button9_Click(object sender, EventArgs e)
        {
            Cost aCost = new Cost();
            aCost.Id = 0;
            int.TryParse(Discount_RID_textBox2.Text,out aCost.Id);
            aCost.TotalCost = 0;
            float.TryParse(Discount_Customer_TotalBill_textBox4.Text,out aCost.TotalCost);
            aCost.Due = 0;
            float.TryParse(Discount_Due_textBox5.Text,out aCost.Due);
            aCost.Discount = 0;
            float.TryParse(Discount_AmmounttextBox6.Text ,out aCost.Discount);

            PaymentBLL aPaymentBLL = new PaymentBLL();
            bool res = aPaymentBLL.Save_Customer_DiscountBLL(aCost);
            if (res)
            {
                Clear_Discount_panel_textboxes();
                MessageBox.Show("Discount successfully Confirmed!!");
            }
            else
            {
                MessageBox.Show("Error!! Please Check Information!!");
            }
        }

        private void Cancel_Discount_button9_Click(object sender, EventArgs e)
        {
            Cost aCost = new Cost();
            aCost.Id = 0;
            int.TryParse(Discount_RID_textBox2.Text, out aCost.Id);
            aCost.TotalCost = 0;
            float.TryParse(Discount_Customer_TotalBill_textBox4.Text, out aCost.TotalCost);
            aCost.Due = 0;
            float.TryParse(Discount_Due_textBox5.Text, out aCost.Due);
            aCost.Discount = 0;
            float.TryParse(Discount_AmmounttextBox6.Text, out aCost.Discount);

            PaymentBLL aPaymentBLL = new PaymentBLL();
            bool res = aPaymentBLL.Save_Customer_DiscountBLL(aCost);
            if (res)
            {
                Clear_Discount_panel_textboxes();
                MessageBox.Show("Discount successfully Cancelled!!");
            }
            else
            {
                MessageBox.Show("Error!! Please Check Information!!");
            }

        }

        private void Update_Discountbutton9_Click(object sender, EventArgs e)
        {
            Cost aCost = new Cost();
            aCost.Id = 0;
            int.TryParse(Discount_RID_textBox2.Text, out aCost.Id);
            aCost.TotalCost = 0;
            float.TryParse(Discount_Customer_TotalBill_textBox4.Text, out aCost.TotalCost);
            aCost.Due = 0;
            float.TryParse(Discount_Due_textBox5.Text, out aCost.Due);
            aCost.Discount = 0;
            float.TryParse(Discount_AmmounttextBox6.Text, out aCost.Discount);

            PaymentBLL aPaymentBLL = new PaymentBLL();
            bool res = aPaymentBLL.Save_Customer_DiscountBLL(aCost);
            if (res)
            {
                Clear_Discount_panel_textboxes();
                MessageBox.Show("Discount successfully Updated!!");
            }
            else
            {
                MessageBox.Show("Error!! Please Check Information!!");
            }
        }
       
        private void discountToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SpecificSearch_TextBox_showpanel10.Visible = false;
            HH.Visible = false;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = true;
            pepH.Visible = false;
            rinfoH.Visible = false;

            Home_panel.Visible = false;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = false;
            Search_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = false;
            SystemAccess_panel10.Visible = false;
            CreateAccess_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            Discount_panel10.Visible = true;
            AdminAccess_Checkin_panel20.Visible = false;
            DatabaseRestore_or_Backup_panel19.Visible = false;

            this.ActiveControl = RtextBox1;
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpecificSearch_TextBox_showpanel10.Visible = false;
            HH.Visible = false;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = true;
            pepH.Visible = false;
            rinfoH.Visible = false;

            Home_panel.Visible = false;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = true;
            Search_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = false;
            SystemAccess_panel10.Visible = false;
            CreateAccess_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            Discount_panel10.Visible =false ;
            AdminAccess_Checkin_panel20.Visible = false;
            DatabaseRestore_or_Backup_panel19.Visible = false;

            Clear_all_Panel_textboxes();
            this.ActiveControl = Name__textBox21;
        }

        private void RtextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clear_Discount_button9_Click(object sender, EventArgs e)
        {
            Clear_Discount_panel_textboxes();
        }
        private void Clear_Discount_panel_textboxes()
        {
            RtextBox1.Text = "";
            Discount_RID_textBox2.Text = "";
            DiscountCustomer_NametextBox3.Text = "";
            Discount_Customer_TotalBill_textBox4.Text = "";
            Discount_Due_textBox5.Text = "";
            Discount_AmmounttextBox6.Text = "";
            DUE___textBox1.Text = "";
        }

        private void Discount_RID_textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Down)
            {
                this.ActiveControl = DiscountCustomer_NametextBox3;
            }
        }

        private void DiscountCustomer_NametextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Discount_RID_textBox2;
            }
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = DiscountCustomer_NametextBox3;
            }
        }

        private void Discount_Customer_TotalBill_textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = DiscountCustomer_NametextBox3;
            }
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Discount_Due_textBox5;
            }
        }

        private void Discount_Due_textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Discount_Customer_TotalBill_textBox4;
            }
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Discount_AmmounttextBox6;
            }
        }

        private void Discount_AmmounttextBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Discount_Due_textBox5;
            }
          
        }

        private void label146_Click(object sender, EventArgs e)
        {

        }

        private void groupBox42_Enter(object sender, EventArgs e)
        {

        }

        private void AdminAccess_Checkin_panel20_Paint(object sender, PaintEventArgs e)
        {

        }
        private void showRoomINput_Panel()
        {
            SpecificSearch_TextBox_showpanel10.Visible = false;
            HH.Visible = false;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = false;
            pepH.Visible = false;
            rinfoH.Visible = true;

            Home_panel.Visible = false;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = false;
            Search_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            Admin_panel10.Visible = true;
            REPORT_panel10.Visible = false;
            AdminAccess_Checkin_panel20.Visible = false;
            DatabaseRestore_or_Backup_panel19.Visible = false;

            ShowExistingRooms();
            Clear_all_Panel_textboxes();
            this.ActiveControl = RmNo_textBox1;
        }
        private void showCreate_access_PAnel(SystemAccess aSystemAccess)
        {
            HH.Visible = false;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = false;
            pepH.Visible = false;
            rinfoH.Visible = true;

            Home_panel.Visible = false;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = false;
            Search_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = false;
            SystemAccess_panel10.Visible = true;
            CreateAccess_panel10.Visible = true;
            UpdateUserAccess_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            AdminAccess_Checkin_panel20.Visible = false;
            DatabaseRestore_or_Backup_panel19.Visible = false;

            View_existingUserAccess(aSystemAccess);
            Clear_all_Panel_textboxes();
        }
        private  void Show_Update_Access(SystemAccess aSystemAccess)
        {
            HH.Visible = false;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = false;
            pepH.Visible = false;
            rinfoH.Visible = true;

            Home_panel.Visible = false;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = false;
            Search_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = false;
            SystemAccess_panel10.Visible = true;
            CreateAccess_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = true;
            AdminAccess_Checkin_panel20.Visible = false;
            DatabaseRestore_or_Backup_panel19.Visible = false;

            View_existingUserAccess(aSystemAccess);
            Clear_all_Panel_textboxes();
           
        }
        string hash = "f0xle@rn";
        public string EncryptPassword(string Password)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(Password);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    string EncryptedPassword = Convert.ToBase64String(results, 0, results.Length);
                    return EncryptedPassword;
                }
            }
        }
        private void AdminAccess_SignIN_20button9_Click(object sender, EventArgs e)
        {

            if (Owner_RadioButton.Checked != true || Manager_radioButton2.Checked != true)
            {
                label147.Text = "Please Select Access Type !!";
            }
            SystemAccess aSystemAccess = new SystemAccess();
            string EncryptedPassword = EncryptPassword(AdminAccess_Password_textBox2.Text);
            aSystemAccess.Username = AdminAccess_UserName_textBox1.Text;
            aSystemAccess.Password = EncryptedPassword;
            if (Owner_RadioButton.Checked == true)
            {
                aSystemAccess.UserType = "Admin";
                SignInBLL aSignINBLL = new SignInBLL();
                bool result = aSignINBLL.Check_AccessID_and_PasswordBLKL(aSystemAccess);
                if (result)
                {
                    if (Room_Input_radioButton4.Checked == true)
                    {
                        showRoomINput_Panel();
                    }
                    if (CreateAcces_radioButton5.Checked == true)
                    {
                        showCreate_access_PAnel(aSystemAccess);
                    }
                    if (DeleteORupdateradioButton6.Checked == true)
                    {
                        Show_Update_Access(aSystemAccess);
                    }
                    if (Backup_orRestoreDatabase_radioButton1.Checked == true)
                    {
                        Show_Backup_Restore_Record_PAnel();  
                    }
                    else
                    {
                        label147.Text = "Unauthorised User ID or Password !!";
                    }
                }
                else
                {
                    label147.Text = "Unauthorised User ID or Password !!";
                }
            }
            else if (Manager_radioButton2.Checked == true)
            {
                aSystemAccess.UserType = "Manager";
                SignInBLL aSignINBLL = new SignInBLL();
                bool result = aSignINBLL.Check_AccessID_and_PasswordBLKL(aSystemAccess);
                if (result)
                {
                    if (CreateAcces_radioButton5.Checked == true)
                    {
                        showCreate_access_PAnel(aSystemAccess);
                    }
                    if (DeleteORupdateradioButton6.Checked == true)
                    {
                        Show_Update_Access(aSystemAccess);
                    }
                    if (Backup_orRestoreDatabase_radioButton1.Checked == true)
                    {
                        Show_Backup_Restore_Record_PAnel();
                    }
                    else
                    {
                        label147.Text = "Unauthorised User ID or Password !!";
                    }
                }
                else
                {
                    label147.Text = "Unauthorised User ID or Password !!";
                }
            }

        }

        public void clear_AdminAccess()
        {
            Owner_RadioButton.Checked = false;
            Manager_radioButton2.Checked = false;
            AdminAccess_UserName_textBox1.Text = "";
            AdminAccess_Password_textBox2.Text = "";

            label147.Text = "";
        }

        private void AdminAccess_Password_textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = AdminAccess_UserName_textBox1;
            }
            if (e.KeyCode==Keys.Enter )
            {

                if (Owner_RadioButton.Checked != true || Manager_radioButton2.Checked != true)
                {
                    label147.Text = "Please Select Access Type !!";
                }
                SystemAccess aSystemAccess = new SystemAccess();
                string EncryptedPassword = EncryptPassword(AdminAccess_Password_textBox2.Text);
                aSystemAccess.Username = AdminAccess_UserName_textBox1.Text;
                aSystemAccess.Password = EncryptedPassword;
                if (Owner_RadioButton.Checked == true)
                {
                    aSystemAccess.UserType = "Admin";
                    SignInBLL aSignINBLL = new SignInBLL();
                    bool result = aSignINBLL.Check_AccessID_and_PasswordBLKL(aSystemAccess);
                    if (result)
                    {
                        if (Room_Input_radioButton4.Checked == true)
                        {
                            showRoomINput_Panel();
                        }
                        if (CreateAcces_radioButton5.Checked == true)
                        {
                            showCreate_access_PAnel(aSystemAccess);
                        }
                        if (DeleteORupdateradioButton6.Checked == true)
                        {
                            Show_Update_Access(aSystemAccess);
                        }
                        if (Backup_orRestoreDatabase_radioButton1.Checked == true)
                        {
                            Show_Backup_Restore_Record_PAnel();
                        }
                        else
                        {
                            label147.Text = "Unauthorised User ID or Password !!";
                        }
                    }
                    else
                    {
                        label147.Text = "Unauthorised User ID or Password !!";
                    }
                }
                else if (Manager_radioButton2.Checked == true)
                {
                    aSystemAccess.UserType = "Manager";
                    SignInBLL aSignINBLL = new SignInBLL();
                    bool result = aSignINBLL.Check_AccessID_and_PasswordBLKL(aSystemAccess);
                    if (result)
                    {
                        if (CreateAcces_radioButton5.Checked == true)
                        {
                            showCreate_access_PAnel(aSystemAccess);
                        }
                        if (DeleteORupdateradioButton6.Checked == true)
                        {
                            Show_Update_Access(aSystemAccess);
                        }
                        if (Backup_orRestoreDatabase_radioButton1.Checked == true)
                        {
                            Show_Backup_Restore_Record_PAnel();
                        }
                        else
                        {
                            label147.Text = "Unauthorised User ID or Password !!";
                        }
                    }
                    else
                    {
                        label147.Text = "Unauthorised User ID or Password !!";
                    }
                }
            }
            
        }
        //public void UserAccess()
        //{
        //    admin
        //}
        private void AdminAccess_UserName_textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {

                if (Owner_RadioButton.Checked != true || Manager_radioButton2.Checked != true)
                {
                    label147.Text = "Please Select Access Type !!";
                }
                SystemAccess aSystemAccess = new SystemAccess();
                string EncryptedPassword = EncryptPassword(AdminAccess_Password_textBox2.Text);
                aSystemAccess.Username = AdminAccess_UserName_textBox1.Text;
                aSystemAccess.Password = EncryptedPassword;
                if (Owner_RadioButton.Checked == true)
                {
                    aSystemAccess.UserType = "Admin";
                    SignInBLL aSignINBLL = new SignInBLL();
                    bool result = aSignINBLL.Check_AccessID_and_PasswordBLKL(aSystemAccess);
                    if (result)
                    {
                        if (Room_Input_radioButton4.Checked == true)
                        {
                            showRoomINput_Panel();
                        }
                        if (CreateAcces_radioButton5.Checked == true)
                        {
                            showCreate_access_PAnel(aSystemAccess);
                        }
                        if (DeleteORupdateradioButton6.Checked == true)
                        {
                            Show_Update_Access(aSystemAccess);
                        }
                        if (Backup_orRestoreDatabase_radioButton1.Checked==true)
                        {
                            Show_Backup_Restore_Record_PAnel();
                        }
                        else
                        {
                            label147.Text = "Unauthorised User ID or Password !!";
                        }
                    }
                    else
                    {
                        label147.Text = "Unauthorised User ID or Password !!";
                    }
                }
                else if (Manager_radioButton2.Checked == true)
                {
                    aSystemAccess.UserType = "Manager";
                    SignInBLL aSignINBLL = new SignInBLL();
                    bool result = aSignINBLL.Check_AccessID_and_PasswordBLKL(aSystemAccess);
                    if (result)
                    {
                        if (CreateAcces_radioButton5.Checked == true)
                        {
                            showCreate_access_PAnel(aSystemAccess);
                        }
                        if (DeleteORupdateradioButton6.Checked == true)
                        {
                            Show_Update_Access(aSystemAccess);
                        }
                        if (Backup_orRestoreDatabase_radioButton1.Checked == true)
                        {
                            Show_Backup_Restore_Record_PAnel();
                        }
                        else
                        {
                            label147.Text = "Unauthorised User ID or Password !!";
                        }
                    }
                    else
                    {
                        label147.Text = "Unauthorised User ID or Password !!";
                    }
                }
            }
            if (e.KeyCode == Keys.Down )
            {
                this.ActiveControl = AdminAccess_Password_textBox2;
            }
        }
        public int Discpunt_Amount;
        private void button9_Click(object sender, EventArgs e) //500taka
        {
            Discpunt_Amount = int.Parse(button9.Text);
            Discount_AmmounttextBox6.Text = Discpunt_Amount.ToString();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Discpunt_Amount = int.Parse(button11.Text);
            Discount_AmmounttextBox6.Text = Discpunt_Amount.ToString();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Discpunt_Amount = int.Parse(button13.Text);
            Discount_AmmounttextBox6.Text = Discpunt_Amount.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Discpunt_Amount = int.Parse(button14.Text);
            Discount_AmmounttextBox6.Text = Discpunt_Amount.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Discpunt_Amount = int.Parse(button15.Text);
            Discount_AmmounttextBox6.Text = Discpunt_Amount.ToString();
        }

        private void restoreOrBackupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            SpecificSearch_TextBox_showpanel10.Visible = false;
            Backup_orRestoreDatabase_radioButton1.Checked = true;
            Room_Input_radioButton4.Checked = false;
            CreateAcces_radioButton5.Checked = false;
            DeleteORupdateradioButton6.Checked = false;

            HH.Visible = false;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = false;
            pepH.Visible = false;
            rinfoH.Visible = true;

            Home_panel.Visible = false;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = false;
            Search_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = false; 
            DatabaseRestore_or_Backup_panel19.Visible = false;
            AdminAccess_Checkin_panel20.Visible = true;
            Clear_all_Panel_textboxes();
            this.ActiveControl = AdminAccess_UserName_textBox1;
            
            label147.Text = "";
        }
        public void Show_Backup_Restore_Record_PAnel()
        {
            HH.Visible = false;
            RH.Visible = false;
            cinH.Visible = false;
            coutH.Visible = false;
            sH.Visible = false;
            pH.Visible = false;
            pepH.Visible = false;
            rinfoH.Visible = true;

            Home_panel.Visible = false;
            Reservation_panel6.Visible = false;
            CheckIn_panel6.Visible = false;
            CheckOut_panel10.Visible = false;
            Payment_panel10.Visible = false;
            Search_panel10.Visible = false;
            UpdateUserAccess_panel10.Visible = false;
            Admin_panel10.Visible = false;
            REPORT_panel10.Visible = false;
            SpecificSearch_TextBox_showpanel10.Visible = false;
            DatabaseRestore_or_Backup_panel19.Visible = true;
            Discount_panel10.Visible = false;
            SystemAccess_panel10.Visible = false;
            AdminAccess_Checkin_panel20.Visible =false;

            Clear_all_Panel_textboxes();

        }
        public void Clear_Backup_And_DatabaseRecord()
        {
            ServerAddress_textBox1.Text = "";
            Database_NameS_comboBox2.Text = "";
            DB_Backup_LocationtextBox2.Text = "";
            Database_Restore_BAckupPAthtextBox3.Text = "";
        }
        private void GetDataSourrce_button17_Click(object sender, EventArgs e)
        {
            string userName = System.Environment.UserName;
            string path = File.ReadAllText(@"C:\Users\" + userName + @"\Documents\DataSource.txt");
            ServerAddress_textBox1.Text = path;
        }

        private void Connect_to_dtaabase_button16_Click(object sender, EventArgs e)
        {
            if (ServerAddress_textBox1.Text=="")
            {
                Alert_label156.ForeColor=Color.Red;
                Alert_label156.Text = "Error Loading Database!!";
            }
            else
            {
                SqlConnection connection = DBconnection.OpneMasterConnction();
                Alert_label156.ForeColor = Color.Navy;
                Alert_label156.Text = " Connected To SQL Server ";
                try
                {
                    Restore_or_BackupBLL arestorBLL = new Restore_or_BackupBLL();
                    SqlDataReader reader = arestorBLL.DatabasesToComboboxBLL();
                    Database_NameS_comboBox2.Items.Clear();
                    while (reader.Read())
                    {
                        Database_NameS_comboBox2.Items.Add(reader[0].ToString());
                    }
                }
                catch
                {
                    label156.Text = "Error Loading Database!!";
                }
            }
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fdlg = new FolderBrowserDialog();
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    DB_Backup_LocationtextBox2.Text = fdlg.SelectedPath;
                }
            }
            catch
            {
                label156.Text = "Error Backup Location selection!!";
            }
        }

        private void Backup_button19_Click(object sender, EventArgs e)
        {
            string database = Database_NameS_comboBox2.Text;
            string dataBase_Path = DB_Backup_LocationtextBox2.Text;
            Restore_or_BackupBLL arestorBLL = new Restore_or_BackupBLL();
            bool res = arestorBLL.BackupDatabaseBLL(database, dataBase_Path);
            if (res)
            {
                MessageBox.Show(database+" Backup Successfull ");
                Clear_Backup_And_DatabaseRecord();
            }
            else
            {
                label156.Text = "Error Please Check DataSource \n & Database Name Information !!";
            }
        }

        private void RestorePathbutton21_Click(object sender, EventArgs e)
        {
            try {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Backup Files(*.bak)|*.bak|All Files(*.*)|*.* ";
                dlg.FilterIndex = 0;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Database_Restore_BAckupPAthtextBox3.Text = dlg.FileName;
                }
                
            }
            catch
            {
                label156.Text = "Error Selecting File to be RRestored";
            }



            
        }

        private void RestoreDatabase_button20_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Database_NameS_comboBox2.Text != "" && Database_Restore_BAckupPAthtextBox3.Text != ""))
                {
                    string database = Database_NameS_comboBox2.Text;
                    string dataBase_Path = Database_Restore_BAckupPAthtextBox3.Text;
                    Restore_or_BackupBLL arestorBLL = new Restore_or_BackupBLL();
                    bool res = arestorBLL.RestoreDatbaseBLL(database, dataBase_Path);
                    if (res)
                    {
                        MessageBox.Show(database + " Restore Successfull ");
                        Clear_Backup_And_DatabaseRecord();
                    }
                    else
                    {
                        MessageBox.Show(database + " Restore Successfull ");
                        Clear_Backup_And_DatabaseRecord();
                    }
                }
                else

                {
                    label156.Text = "Error Please Check DataSource \n & Database Name !!";
                }
                
            }
            catch
            {
                label156.Text = "Error Please Check DataSource \n  & Database Name !!";
            }
        }
    }
    }
    
    

