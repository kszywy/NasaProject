namespace Nasa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Pobranie wybranej daty z MonthCalendar
            DateTime selectedDate = e.Start; // albo e.End jeœli chcesz ostatni dzieñ zakresu

            // Wywo³anie metody w innej klasie, np. Database
            DBConnection db = new DBConnection();
            db.GetEventByDateSpace(selectedDate);
        }
    }
}
