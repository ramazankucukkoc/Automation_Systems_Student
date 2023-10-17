using Newtonsoft.Json;
using Student_Follower.Entities;
using Student_Follower.Entities.Student;
using Student_Follower.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Student_Follower.Forms.Students
{
    public partial class StudentDataAnalysis : Form
    {
        private readonly StudentApiService studentApiService;
        public string FormName;
        public StudentDataAnalysis(string formName)
        {
            FormName = formName;
            this.studentApiService = new StudentApiService();
            InitializeComponent();

        }
        public StudentDataAnalysis()
        {
            this.studentApiService = new StudentApiService();
            InitializeComponent();
        }
        private void StudentDataAnalysis_Load(object sender, EventArgs e)
        {
            GetAllChart1();
            GetAllChart2();
            GetAllChart3();
        }
        private async Task GetAllChart1()
        {

            ResponseStatusCode responseStatusCode = await studentApiService.GetResponse("GetAllMath");
            if (responseStatusCode.StatusCode == 200)
            {

                List<StudentCourseMath> datalist = JsonConvert.DeserializeObject<List<StudentCourseMath>>(responseStatusCode.Content).Where(x => x.CourseId == 2).Take(5).ToList();

                chart1.Series["Veri"].Points.DataBindXY(datalist, "StudentName", datalist, "Average");
                chart1.ChartAreas[0].AxisY.Maximum = 100;
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            }
            else
            {
                GenericApiService.ErrorService(responseStatusCode);
            }
        }
        private async Task GetAllChart2()
        {

            ResponseStatusCode responseStatusCode = await studentApiService.GetResponse("GetAllMath");
            if (responseStatusCode.StatusCode == 200)
            {

                List<StudentCourseMath> datalist = JsonConvert.DeserializeObject<List<StudentCourseMath>>(responseStatusCode.Content).Where(x => x.CourseId == 1).Take(5).ToList();
                chart2.Series["Veri"].Points.DataBindXY(datalist, "StudentName", datalist, "Average");
                chart2.ChartAreas[0].AxisY.Maximum = 100;
                chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            }
            else
            {
                GenericApiService.ErrorService(responseStatusCode);
            }
        }
        private async Task GetAllChart3()
        {

            ResponseStatusCode responseStatusCode = await studentApiService.GetResponse("GetAllMath");
            if (responseStatusCode.StatusCode == 200)
            {

                List<StudentCourseMath> datalist = JsonConvert.DeserializeObject<List<StudentCourseMath>>(responseStatusCode.Content).Where(x => x.CourseId == 3).Take(5).ToList();

                chart3.Series["Veri"].Points.DataBindXY(datalist, "StudentName", datalist, "Average");
                chart3.ChartAreas[0].AxisY.Maximum = 100;
                chart3.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            }
            else
            {
                GenericApiService.ErrorService(responseStatusCode);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (FormName == "PersonelIslemleri")
            {
                this.Close();
                PersonelIslemleri form4 = new PersonelIslemleri();
                form4.Show();
            }
            else
            {
                this.Close();
                Ogrenciİslemeleri form3 = new Ogrenciİslemeleri();
                form3.Show();
            }

        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePozisyon = new Point(e.X, e.Y);

            // Hangi sütunun üzerine gelindiğini kontrol edin
            HitTestResult sonuc = chart1.HitTest(mousePozisyon.X, mousePozisyon.Y);
            if (sonuc.ChartElementType == ChartElementType.DataPoint)
            {
                // Sütun üzerine gelindiğinde değeri alın ve gösterin
                DataPoint sütun = chart1.Series["Veri"].Points[sonuc.PointIndex];
                string etiket = sütun.YValues[0].ToString();
                string xEkseniDegeri = chart1.Series["Veri"].Points[sonuc.PointIndex].AxisLabel;
                MessageBox.Show($"{xEkseniDegeri} : Başarı Puanı: {etiket}");
            }
        }
        private void chart2_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePozisyon = new Point(e.X, e.Y);

            // Hangi sütunun üzerine gelindiğini kontrol edin
            HitTestResult sonuc = chart2.HitTest(mousePozisyon.X, mousePozisyon.Y);
            if (sonuc.ChartElementType == ChartElementType.DataPoint)
            {
                // Sütun üzerine gelindiğinde değeri alın ve gösterin
                DataPoint sütun = chart2.Series["Veri"].Points[sonuc.PointIndex];
                string etiket = sütun.YValues[0].ToString();
                string xEkseniDegeri = chart2.Series["Veri"].Points[sonuc.PointIndex].AxisLabel;
                MessageBox.Show($"{xEkseniDegeri} : Başarı Puanı: {etiket}");
            }
        }

        private void chart3_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePozisyon = new Point(e.X, e.Y);

            // Hangi sütunun üzerine gelindiğini kontrol edin
            HitTestResult sonuc = chart3.HitTest(mousePozisyon.X, mousePozisyon.Y);
            if (sonuc.ChartElementType == ChartElementType.DataPoint)
            {
                // Sütun üzerine gelindiğinde değeri alın ve gösterin
                DataPoint sütun = chart3.Series["Veri"].Points[sonuc.PointIndex];
                string etiket = sütun.YValues[0].ToString();
                string xEkseniDegeri = chart2.Series["Veri"].Points[sonuc.PointIndex].AxisLabel;
                MessageBox.Show($"{xEkseniDegeri} : Başarı Puanı: {etiket}");
            }
        }
    }
}
