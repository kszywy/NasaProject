using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            listViewSpace.View = View.Details;
            listViewSpace.FullRowSelect = true;
            listViewSpace.GridLines = true;

            // Dodawanie kolumn
            listViewSpace.Columns.Add("ID", 50);
            listViewSpace.Columns.Add("Event ID", 150);
            listViewSpace.Columns.Add("Typ", 100);
            listViewSpace.Columns.Add("Początek", 150);
            listViewSpace.Columns.Add("Szczyt", 150);
            listViewSpace.Columns.Add("Koniec", 150);
            listViewSpace.Columns.Add("Klasa", 50);
            listViewSpace.Columns.Add("Lokalizacja", 50);
            listViewSpace.Columns.Add("Aktywny region", 50);
            listViewSpace.Columns.Add("Instrumenty", 200);
            listViewSpace.Columns.Add("Notatka", 300);
            listViewSpace.Columns.Add("Data", 100);

            listViewEarth.View = View.Details;
            listViewEarth.FullRowSelect = true;
            listViewEarth.GridLines = true;

            // Dodawanie kolumn
            listViewEarth.Columns.Add("ID", 50);
            listViewEarth.Columns.Add("Kraj", 100);
            listViewEarth.Columns.Add("Lokacja", 100);
            listViewEarth.Columns.Add("Strefa czasowa", 100);
            listViewEarth.Columns.Add("Data", 100);
            listViewEarth.Columns.Add("Temperatura", 100);
            listViewEarth.Columns.Add("Opis pogody", 100);
            listViewEarth.Columns.Add("Wiatr (km/h)", 50);
            listViewEarth.Columns.Add("Ciśnienie", 100);
            listViewEarth.Columns.Add("Wilgotność", 100);
            listViewEarth.Columns.Add("Zachmurzenie", 50);
            listViewEarth.Columns.Add("Temperatura odczuwalna", 100);
        }

        private async void calendar_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            // Pobranie wybranej daty z kalendarza formularza
            this.selectedDate = DateOnly.FromDateTime(e.Start);

            // Zakomentowane aby nie nie wykorzystywało dziennego limitu zapytań - poza tym działa
            var imageUrl = await APIConnection.GetImageUrlFromAPOD(selectedDate);
            APODPicture.ImageLocation = imageUrl;

            Filter.FilterAll(selectedDate);
            UpdateSpaceListView();
            UpdateEarthListView();

            textBoxHighestTemp.Text = Filter.GetEarthWeatherCombined().Max(p => p.TemperatureCelsius.ToString());
        }



        private void UpdateSpaceListView()
        {
            listViewSpace.BeginUpdate();

            listViewSpace.Items.Clear();

            // 3. Przejdź przez listę przefiltrowanych rekordów
            foreach (var item in Filter.GetSpaceWeatherCombined())
            {
                // Pierwszy element (Główny tekst wiersza - ID)
                ListViewItem row = new ListViewItem(item.IdSpace.ToString());

                // Kolejne kolumny (SubItems)
                row.SubItems.Add(item.EventId ?? "");
                row.SubItems.Add(item.EventType ?? "N/A");
                row.SubItems.Add(item.BeginTime ?? "N/A");
                row.SubItems.Add(item.PeakTime ?? "N/A");
                row.SubItems.Add(item.EndTime ?? "N/A");
                row.SubItems.Add(item.ClassType ?? "N/A");
                row.SubItems.Add(item.SourceLocation ?? "N/A");
                row.SubItems.Add(item.ActiveRegion ?? "N/A");
                row.SubItems.Add(item.Instruments ?? "N/A");
                row.SubItems.Add(item.Note ?? "N/A");
                row.SubItems.Add(item.Date.ToString("yyyy-MM-dd"));

                // Dodaj wiersz do kontrolki
                listViewSpace.Items.Add(row);
            }

            // 4. Odblokuj odświeżanie
            listViewSpace.EndUpdate();
        }

        private void UpdateEarthListView()
        {
            listViewEarth.BeginUpdate();

            listViewEarth.Items.Clear();

            foreach (var item in Filter.GetEarthWeatherCombined())
            {
                System.Diagnostics.Debug.WriteLine(item);
                ListViewItem row = new ListViewItem(item.IdEarth.ToString());

                row.SubItems.Add(item.Country ?? "");
                row.SubItems.Add(item.LocationName ?? "N/A");
                row.SubItems.Add(item.Timezone ?? "N/A");
                row.SubItems.Add(item.Date.ToString("yyyy-MM-dd"));
                row.SubItems.Add(item.TemperatureCelsius.ToString() ?? "N/A");
                row.SubItems.Add(item.ConditionText ?? "N/A");
                row.SubItems.Add(item.WindKph.ToString() ?? "N/A");
                row.SubItems.Add(item.PressureMb.ToString() ?? "N/A");
                row.SubItems.Add(item.Humidity.ToString() ?? "N/A");
                row.SubItems.Add(item.Cloud.ToString() ?? "N/A");
                row.SubItems.Add(item.FeelsLikeCelsius.ToString() ?? "N/A");

                listViewEarth.Items.Add(row);
            }

            listViewEarth.EndUpdate();
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

            if (!(radioButtonExportJSON.Checked || radioButtonExportXML.Checked || radioButtonExportSQL.Checked))
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
            else if (radioButtonExportXML.Checked)
            {
                saveFileDialog.Filter = "Pliki XML (*.xml)|*.xml";
                saveFileDialog.DefaultExt = "xml";
                saveFileDialog.Title = "Eksportuj dane do XML";
            }
            else
            {
                saveFileDialog.Filter = "Pliki SQL (*.sql)|*.sql";
                saveFileDialog.DefaultExt = "sql";
                saveFileDialog.Title = "Eksportuj dane do SQL";
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Pobieramy pełną ścieżkę wybraną przez użytkownika
                string filePath = saveFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);

                try
                {
                    // Określamy format dla metody eksportującej
                    string format = radioButtonExportJSON.Checked ? "JSON" : (radioButtonExportXML.Checked ? "XML" : "SQL");

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
            if (!(radioButtonImportJSON.Checked || radioButtonImportXML.Checked || radioButtonImportSQL.Checked))
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
            else if (radioButtonImportXML.Checked)
            {
                openFileDialog.Filter = "Pliki XML (*.xml)|*.xml";
                openFileDialog.DefaultExt = "xml";
                openFileDialog.Title = "Importuj dane z XML";
            }
            else
            {
                openFileDialog.Filter = "Pliki SQL (*.sql)|*.sql";
                openFileDialog.DefaultExt = "sql";
                openFileDialog.Title = "Importuj dane z SQL";
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string format = radioButtonImportJSON.Checked ? "JSON" : (radioButtonImportXML.Checked ? "XML" : "SQL");

                    //Import.LoadFromFile(format, filePath);
                    //Import.ImportData();
                    Create.InitializeAll();
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

        private void WeatherForm_Load(object sender, EventArgs e)
        {

        }
    }
}
