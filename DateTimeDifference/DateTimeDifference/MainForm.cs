using System;
using System.Drawing;
using System.Windows.Forms;

namespace DateTimeDifference
{
    public partial class MainForm : Form
    {
        Point moveStart; // точка для перемещения
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            string DateC;
            txbResult.Text = DateC = Convert.ToString(((dateTimePicker2.Value - dateTimePicker1.Value).Days));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myPath =
new System.Drawing.Drawing2D.GraphicsPath();
            // создаем эллипс с высотой и шириной формы
            myPath.AddEllipse(0, 0, this.Width, this.Height);
            // создаем с помощью элипса ту область формы, которую мы хотим видеть
            Region myRegion = new Region(myPath);
            // устанавливаем видимую область
            this.Region = myRegion;
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moveStart = new Point(e.X, e.Y);
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши
            if ((e.Button & MouseButtons.Left) != 0)
            {
                // получаем новую точку положения формы
                Point deltaPos = new Point(e.X - moveStart.X, e.Y - moveStart.Y);
                // устанавливаем положение формы
                this.Location = new Point(this.Location.X + deltaPos.X,
                this.Location.Y + deltaPos.Y);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Exit?", "Закрытие программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
            {
                this.Close();
            }
        }
    }
}
