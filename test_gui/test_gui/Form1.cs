using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace test_gui
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int nRgihtRect,
            int nBottomRect,
            int WidthEllipse,
            int nHeightEllipse
            );
    

        public int total_price = 0;
        public int additional_price = 0;
        public double fortjeneste = Properties.Settings.Default.prosent;
        public int lyd_bilde_price = Properties.Settings.Default.lyd_bilde_price;
        public int servering_price = Properties.Settings.Default.servering_price;
        public int toast_master_price = Properties.Settings.Default.toast_master_price;
        public int leker_opplegg_price = Properties.Settings.Default.leker_opplegg_price;
        public int regge_price = Properties.Settings.Default.regge_price;
        public int pynt_price = Properties.Settings.Default.pynt_price;
        public int servise_price = Properties.Settings.Default.servise_price;
        public int transport_price = Properties.Settings.Default.transport_price;
        public int fotograf_price = Properties.Settings.Default.fotograf_price;
        public int balpanne_price = Properties.Settings.Default.balpanne_price;
        public int over_15_price = Properties.Settings.Default.over_15_price;
        public int under_15_price = Properties.Settings.Default.under_15_price;
        public int reise_utgifter = Properties.Settings.Default.reise_utgifter;
        public int personell_price = Properties.Settings.Default.personell_price;


        public int guests = 0;
        public int hours = 0;
        public int reise = 0;
        public int old_guests = 0;
        public int old_hours = 0;
        public int old_reise = 0;
        bool guests_updated = false;
        bool hours_updated = false;
        bool reise_updated = false;

        

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            txt_box_fortjeneste.Text = fortjeneste.ToString();

            txt_lyd.Text = Properties.Settings.Default.lyd_bilde_price.ToString();
            txt_servering.Text = Properties.Settings.Default.servering_price.ToString();
            txt_toast_master.Text = Properties.Settings.Default.toast_master_price.ToString();
            txt_leker.Text = Properties.Settings.Default.leker_opplegg_price.ToString();
            txt_rigge.Text = Properties.Settings.Default.regge_price.ToString();
            txt_pynt.Text = Properties.Settings.Default.pynt_price.ToString();
            txt_servise.Text = Properties.Settings.Default.servise_price.ToString();
            txt_transport.Text = Properties.Settings.Default.transport_price.ToString();
            txt_fotograf.Text = Properties.Settings.Default.fotograf_price.ToString();
            txt_balpanne.Text = Properties.Settings.Default.balpanne_price.ToString();
            txt_over15.Text = Properties.Settings.Default.over_15_price.ToString();
            txt_under15.Text = Properties.Settings.Default.under_15_price.ToString();
            txt_reiseutgifter.Text = Properties.Settings.Default.reise_utgifter.ToString();
            txt_personell.Text = Properties.Settings.Default.personell_price.ToString();
            panel5.Visible = false;
        }

        private void add_total(int price)
        {
            total_price += price;
            lbl_total_price.Text = total_price.ToString();
        }
        private void remove_total(int price)
        {
            total_price -= price;
            lbl_total_price.Text = total_price.ToString();
        }

        private void update_total()
        {
            double new_price = 100 * total_price / (100 - fortjeneste);
            price_fortjeneste.Text = Math.Round(new_price, 0).ToString();
        }

        private void btn_status(CheckBox box, int price)
        {
            if(box.Checked)
            {
                add_total(price);
            }
            else
            {
                remove_total(price);
            }
            update_total();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboard(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void btnAnalytics(object sender, EventArgs e)
        {
            panel5.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void lyfogbilde_CheckedChanged(object sender, EventArgs e)
        {
            btn_status(btn_lydogbilde, lyd_bilde_price);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txt_box_guests.Text, out int _guests))
            {
                if(guests_updated)
                {
                    if(old_guests>15)
                    {
                        remove_total(over_15_price);
                    }
                    else
                    {
                        remove_total(under_15_price);
                    }
                    guests_updated = false;
                }
                btn_guests.Checked = false;
                _guests = Convert.ToInt32(txt_box_guests.Text);
                guests = _guests;
                /*
                if (guests > 15)
                {
                    add_total(12400);
                }
                else
                {
                    add_total(10000);
                }
                */
                old_guests = guests;
            }
            update_total();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void totalPriceLabel(object sender, EventArgs e)
        {

        }

        private void servering_CheckedChanged(object sender, EventArgs e)
        {
            btn_status(btn_catering, servering_price);
        }

        private void btn_toastmaster_CheckedChanged(object sender, EventArgs e)
        {
            btn_status(btn_toastmaster, toast_master_price);
        }

        private void btn_leker_opplegg_CheckedChanged(object sender, EventArgs e)
        {
            btn_status(btn_leker_opplegg, leker_opplegg_price);
        }

        private void btn_rigge_CheckedChanged(object sender, EventArgs e)
        {
            btn_status(btn_rigge, regge_price);
        }

        private void btn_pynt_dekor_CheckedChanged(object sender, EventArgs e)
        {
            btn_status(btn_pynt_dekor, pynt_price);
        }

        private void btn_servise_CheckedChanged(object sender, EventArgs e)
        {
            btn_status(btn_servise, servise_price);
        }

        private void btn_transport_CheckedChanged(object sender, EventArgs e)
        {
            btn_status(btn_transport, transport_price);
        }

        private void btn_photo_CheckedChanged(object sender, EventArgs e)
        {
            btn_status(btn_photo, fotograf_price);
        }

        private void btn_balpanne_CheckedChanged(object sender, EventArgs e)
        {
            btn_status(btn_balpanne, balpanne_price);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            Close();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txt_box_fortjeneste_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txt_box_fortjeneste.Text, out double _fortjeneste))
            {
                fortjeneste = _fortjeneste;
                update_total();
                Properties.Settings.Default.prosent = Convert.ToInt32(_fortjeneste);
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(btn_guests.Checked)
            {
                if (guests_updated == false)
                {
                    if (guests > 15) { add_total(over_15_price); }
                    else if (guests <= 15) { add_total(under_15_price); }
                    guests_updated = true;
                }
                
            }
            update_total();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(btn_hours.Checked)
            {
                if (hours_updated == false)
                {
                    add_total(hours * personell_price);
                    hours_updated = true;
                }
                
            }
            update_total();
        }

        private void txt_box_hours_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txt_box_hours.Text, out int _hours))
            {
                if (hours_updated)
                {
                    remove_total(old_hours * personell_price);
                    hours_updated = false;
                }
                btn_hours.Checked = false;
                _hours = Convert.ToInt32(txt_box_hours.Text);
                hours = _hours;
                /*
                if (guests > 15)
                {
                    add_total(12400);
                }
                else
                {
                    add_total(10000);
                }
                */
                old_hours = hours;
            }
            update_total();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_box_reise_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txt_box_reise.Text, out int _reise))
            {
                if (reise_updated)
                {
                    remove_total(old_reise * reise_utgifter);
                    reise_updated = false;
                }
                btn_reise.Checked = false;
                _reise = Convert.ToInt32(txt_box_reise.Text);
                reise = _reise;
                /*
                if (guests > 15)
                {
                    add_total(12400);
                }
                else
                {
                    add_total(10000);
                }
                */
                old_reise = reise;
            }
            update_total();
        }

        private void btn_reise_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_reise.Checked)
            {
                if(reise_updated == false)
                {
                    add_total(reise * reise_utgifter);
                    reise_updated = true;
                }
                
            }
            update_total();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            //Create the dynamic TextBox.
            TextBox textbox = new TextBox();
            int count = panel3.Controls.OfType<TextBox>().ToList().Count;
            textbox.Location = new System.Drawing.Point(420 + 80, -45 + 35 * count);
            textbox.Size = new System.Drawing.Size(50, 20);
            textbox.Name = "txt_" + (count + 1);
            panel3.Controls.Add(textbox);

            //Create the dynamic Button to remove the TextBox.
            Button button = new Button();
            button.Location = new System.Drawing.Point(350 + 80, -50 + 35 * count);
            button.Size = new System.Drawing.Size(60, 30);
            button.Name = "btnDelete_" + (count + 1);
            button.Text = "Delete";
            button.Font = new Font("Nirmala UI",10, FontStyle.Bold);
            button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            button.Click += new System.EventHandler(this.btnDelete_Click);
            panel3.Controls.Add(button);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Reference the Button which was clicked.
            Button button = (sender as Button);

            //Determine the Index of the Button.
            int index = int.Parse(button.Name.Split('_')[1]);

            //Find the TextBox using Index and remove it.
            panel3.Controls.Remove(panel3.Controls.Find("txt_" + index, true)[0]);

            //Remove the Button.
            panel3.Controls.Remove(button);

            //Rearranging the Location controls.
            foreach (Button btn in panel3.Controls.OfType<Button>())
            {
                try
                    { 
                        int controlIndex = int.Parse(btn.Name.Split('_')[1]);
                        if (controlIndex > index)
                        {
                            TextBox txt = (TextBox)panel3.Controls.Find("txt_" + controlIndex, true)[0];
                            btn.Top = btn.Top - 35;
                            txt.Top = txt.Top - 35;
                        }
                    }
                catch { }
            }
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            int sum = 0;
            foreach (Button btn in panel3.Controls.OfType<Button>())
            {
                try
                {
                    int controlIndex = int.Parse(btn.Name.Split('_')[1]);
                    TextBox txt = (TextBox)panel3.Controls.Find("txt_" + controlIndex, true)[0];
                    sum += Convert.ToInt32(txt.Text);
                }
                catch { }
            }
            additional_price = sum;
            lbl_total_price.Text = (total_price + sum).ToString();

            double new_price = 100 * (total_price + sum) / (100 - fortjeneste);
            price_fortjeneste.Text = Math.Round(new_price, 0).ToString();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            lyd_bilde_price = Convert.ToInt32(txt_lyd.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {   
            Properties.Settings.Default.lyd_bilde_price = servering_price;
            Properties.Settings.Default.servering_price = Convert.ToInt32(txt_servering.Text);
            Properties.Settings.Default.toast_master_price = Convert.ToInt32(txt_toast_master.Text);
            Properties.Settings.Default.leker_opplegg_price = Convert.ToInt32(txt_leker.Text);
            Properties.Settings.Default.regge_price = Convert.ToInt32(txt_rigge.Text);
            Properties.Settings.Default.pynt_price = Convert.ToInt32(txt_pynt.Text);
            Properties.Settings.Default.servise_price = Convert.ToInt32(txt_servise.Text);
            Properties.Settings.Default.transport_price = Convert.ToInt32(txt_transport.Text);
            Properties.Settings.Default.fotograf_price = Convert.ToInt32(txt_fotograf.Text);
            Properties.Settings.Default.balpanne_price = Convert.ToInt32(txt_balpanne.Text);
            Properties.Settings.Default.over_15_price = Convert.ToInt32(txt_over15.Text);
            Properties.Settings.Default.under_15_price = Convert.ToInt32(txt_under15.Text);
            Properties.Settings.Default.reise_utgifter = Convert.ToInt32(txt_reiseutgifter.Text);
            Properties.Settings.Default.personell_price = Convert.ToInt32(txt_personell.Text);
            Properties.Settings.Default.Save();

            lyd_bilde_price = Properties.Settings.Default.lyd_bilde_price;
            servering_price = Properties.Settings.Default.servering_price;
            toast_master_price = Properties.Settings.Default.toast_master_price;
            leker_opplegg_price = Properties.Settings.Default.leker_opplegg_price;
            regge_price = Properties.Settings.Default.regge_price;
            pynt_price = Properties.Settings.Default.pynt_price;
            servise_price = Properties.Settings.Default.servise_price;
            transport_price = Properties.Settings.Default.transport_price;
            fotograf_price = Properties.Settings.Default.fotograf_price;
            balpanne_price = Properties.Settings.Default.balpanne_price;
            over_15_price = Properties.Settings.Default.over_15_price;
            under_15_price = Properties.Settings.Default.under_15_price;
            reise_utgifter = Properties.Settings.Default.reise_utgifter;
            personell_price = Properties.Settings.Default.personell_price;

        }

        private void txt_servering_TextChanged(object sender, EventArgs e)
        {
            servering_price = Convert.ToInt32(txt_servering.Text);
        }

        private void txt_toast_master_TextChanged(object sender, EventArgs e)
        {
            toast_master_price = Convert.ToInt32(txt_toast_master.Text);
        }

        private void txt_leker_TextChanged(object sender, EventArgs e)
        {
            leker_opplegg_price= Convert.ToInt32(txt_leker.Text);
        }

        private void txt_rigge_TextChanged(object sender, EventArgs e)
        {
            regge_price = Convert.ToInt32(txt_rigge.Text);
        }

        private void label18_Click_1(object sender, EventArgs e)
        {

        }
    }
}
