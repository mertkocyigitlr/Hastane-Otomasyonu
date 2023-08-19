using PDKS6.Formlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDKS6
{
    public partial class Form1 : Form
    {


        //Fields 
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        
        
        //Constructor
        public Form1()
        {
            InitializeComponent();
            random = new Random();

        }

        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }


        private void ActivateButton(object btnSender)
        { 
        
            if(btnSender!= null)
            {
               if (currentButton != (Button)btnSender) 
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif ", 12.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3) ; 


                }
            }
        }


        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }


        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }


        private void btnDepartman_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formlar.FormDepartman(), sender);
        }

        private void btnPersonelEkle_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formlar.FormPersonelEkle(), sender);
        }

        private void btnPersonelListele_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formlar.FormPersonelListele(), sender);
        }

        private void btnİzinHareketleri_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formlar.İzinHareketleri(), sender);
        }

        private void BtnMesaiEkle(object sender, EventArgs e)
        {
            OpenChildForm(new Formlar.MesaiEkle(), sender);
        }

        private void btnMaas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formlar.MaaşZamları(), sender);
        }


        

        private void btnMesaiİslemleri_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formlar.Mesaiİşlemleri(), sender);
        }



        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGirisCıkıs_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formlar.FromGirisCıkıs(), sender);
        }
    }
}
