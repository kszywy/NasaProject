using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Nasa
{
    public partial class WeatherForm : Form
    {
        // Klasa do obsługi API APOD
        private readonly APODConnection APIConnection;
        // Obiekt do obsługi połączenia z bazą danych
        private readonly DbConnection db;
        // Obiekt do obsługi tworzenia bazy danych
        private DbCreator Create;
        // Obiekt do obłusgi importu do bazy danych
        private DbImporter Import;
        // Obiekt do obsługi eksport z bazy danych
        private DbExporter Export;
        // Obiekt do obsługi filtrowania bazy danych
        private DbFilter Filter;

        public DateOnly selectedDate;

        public WeatherForm()
        {
            InitializeComponent();

            APIConnection = new APODConnection();
            db = new DbConnection();
            Create = new DbCreator(db);
            Import = new DbImporter(db);
            Export = new DbExporter(db);
            Filter = new DbFilter(db);
        }

        private async void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Pobranie wybranej daty z kalendarza formularza
            this.selectedDate = DateOnly.FromDateTime(e.Start);

            // Zakomentowane aby nie nie wykorzystywało dziennego limitu zapytań - poza tym działa
            //var imageUrl = await APIConnection.GetImageUrlFromAPOD(selectedDate);
            //APODPicture.ImageLocation = imageUrl;


        }

        private async void buttonTest_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Wartość zmiennej: " + APIConnection.GetAPODUrl(selectedDate));
            string? ttt = await APIConnection.GetImageUrlFromAPOD(selectedDate);
            System.Diagnostics.Debug.WriteLine("Wartość zmiennej: " + ttt);
        }

        private void APODPicture_Click(object sender, EventArgs e)
        {
            string url = APODPicture.ImageLocation;
            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie udało się otworzyć linku: " + ex.Message);
                }
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (!(radioButtonExportJSON.Checked || radioButtonExportXML.Checked))
            {
                MessageBox.Show("Wybierz format pliku!");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (radioButtonExportJSON.Checked)
            {
                saveFileDialog.Filter = "Pliki JSON (*.json)|*.json";
                saveFileDialog.DefaultExt = "json";
                saveFileDialog.Title = "Eksportuj dane do JSON";
            }
            else
            {
                saveFileDialog.Filter = "Pliki XML (*.xml)|*.xml";
                saveFileDialog.DefaultExt = "xml";
                saveFileDialog.Title = "Eksportuj dane do XML";
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Pobieramy pełną ścieżkę wybraną przez użytkownika
                string filePath = saveFileDialog.FileName;

                string fileName = Path.GetFileName(filePath);

                try
                {
                    // Określamy format dla metody eksportującej
                    string format = radioButtonExportJSON.Checked ? "JSON" : "XML";

                    // Wywołanie Twojej metody eksportującej
                    Export.ExportData(format, filePath);

                    MessageBox.Show($"Plik {fileName} został zapisany pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas eksportu: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (!(radioButtonImportJSON.Checked || radioButtonImportXML.Checked))
            {
                MessageBox.Show("Wybierz format pliku!");
                return;
            }

            Create.CreateDates();

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (radioButtonImportJSON.Checked)
            {
                openFileDialog.Filter = "Pliki JSON (*.json)|*.json";
                openFileDialog.DefaultExt = "json";
                openFileDialog.Title = "Importuj dane z JSON";
            }
            else
            {
                openFileDialog.Filter = "Pliki XML (*.xml)|*.xml";
                openFileDialog.DefaultExt = "xml";
                openFileDialog.Title = "Importuj dane z XML";
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string format = radioButtonImportJSON.Checked ? "JSON" : "XML";

                    //Import.LoadFromFile(format, filePath);
                    //Import.ImportData();

                    Import.ImportData(format, filePath);

                    MessageBox.Show($"Dane zostały zapisane do bazy!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas importu: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonPurgeDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                Create.PurgeDatabase();
                MessageBox.Show($"Usunięto zawartość bazy danych!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas operacji: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonCreateDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                Create.InitializeAll();
                MessageBox.Show($"Pomyślnie utworzono bazę danych!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas operacji: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
