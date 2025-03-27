using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;

namespace KryptoGraph
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private Timer priceUpdateTimer;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;

            // Lisää tapahtumankäsittelijä kryptojen lisäämisnapille
            buttonAddCrypto.Click += buttonAddCrypto_Click;

            // Lisää tapahtumankäsittelijä valintalaatikon muutoksille
            checkedListBoxCryptos.ItemCheck += CheckedListBoxCryptos_ItemCheck;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Alustetaan ajastin (päivitetään hinnat 30 sekunnin välein)
            priceUpdateTimer = new Timer();
            priceUpdateTimer.Interval = 30000; // 30 sekuntia
            priceUpdateTimer.Tick += async (s, ev) => await UpdateChart();
            priceUpdateTimer.Start();

            // Ladataan ensimmäinen valittu kryptovaluutta
            checkedListBoxCryptos.SetItemChecked(0, true);
            _ = UpdateChart(); // Haetaan aloitustiedot
        }

        // Käsittelee, kun käyttäjä valitsee tai poistaa krypton listasta
        private async void CheckedListBoxCryptos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            await Task.Delay(100); // Pieni viive UI-päivitykselle

            string symbol = checkedListBoxCryptos.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                await UpdateChart(); // ✅ Lisää krypto
            }
            else
            {
                RemoveCryptoFromChart(symbol); // ✅ Poista krypto
            }

            await UpdatePriceTracker(); // Päivitä hintaseuranta
        }

        // Päivittää kaavion ja hinnat kaikille valituille kryptovaluutoille
        private async Task UpdateChart()
        {
            chart1.Series.Clear(); // Tyhjennetään vanhat tiedot

            var checkedCryptos = checkedListBoxCryptos.CheckedItems.Cast<string>().ToList();

            foreach (var symbol in checkedCryptos)
            {
                var priceData = await FetchBinanceKlines(symbol);
                if (priceData != null)
                {
                    AddToChart(priceData, symbol);
                }
            }

            await UpdatePriceTracker(); // Päivitä hintatracker
        }

        // Hakee historialliset hintatiedot Binance API:sta
        private async Task<List<(DateTime, double)>> FetchBinanceKlines(string symbol)
        {
            try
            {
                string url = $"https://api.binance.com/api/v3/klines?symbol={symbol}&interval=1m&limit=1440";
                string json = await client.GetStringAsync(url);
                dynamic data = JsonConvert.DeserializeObject(json);

                var prices = new List<(DateTime, double)>();
                foreach (var entry in data)
                {
                    DateTime time = DateTimeOffset.FromUnixTimeMilliseconds((long)entry[0]).DateTime;
                    double price = Convert.ToDouble(entry[4].ToString(), CultureInfo.InvariantCulture);
                    prices.Add((time, price));
                }

                return prices;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Virhe haettaessa tietoja kryptolle {symbol}: " + ex.Message);
                return null;
            }
        }

        // Lisää uusi krypto listaan ja päivittää kaavion
        private void buttonAddCrypto_Click(object sender, EventArgs e)
        {
            string newSymbol = textBoxCrypto.Text.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(newSymbol))
            {
                MessageBox.Show("Anna kelvollinen kryptovaluutan symboli.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!checkedListBoxCryptos.Items.Contains(newSymbol)) // Vältetään duplikaatit
            {
                checkedListBoxCryptos.Items.Add(newSymbol, true);
                _ = UpdateChart();
            }
            else
            {
                MessageBox.Show("Tämä kryptovaluutta on jo listassa.", "Varoitus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            textBoxCrypto.Clear(); // Tyhjennä tekstikenttä
        }

        // Poistaa krypton kaaviosta
        private void RemoveCryptoFromChart(string symbol)
        {
            if (chart1.Series.Any(s => s.Name == symbol))
            {
                chart1.Series.Remove(chart1.Series[symbol]);
            }

            string chartAreaName = $"ChartArea_{symbol}";

            if (chart1.ChartAreas.Any(ca => ca.Name == chartAreaName))
            {
                chart1.ChartAreas.Remove(chart1.ChartAreas[chartAreaName]);
            }

            chart1.Refresh();
        }

        // Lisää krypton hintatiedot kaavioon
        private void AddToChart(List<(DateTime, double)> data, string symbol)
        {
            if (chart1.Series.IndexOf(symbol) != -1)
            {
                chart1.Series.Remove(chart1.Series[symbol]);
            }

            var series = new Series
            {
                Name = symbol,
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime
            };

            foreach (var point in data)
            {
                series.Points.AddXY(point.Item1, point.Item2); // ✅ Käytä Item1 (aika) ja Item2 (hinta)
            }

            chart1.Series.Add(series);

            string chartAreaName = $"ChartArea_{symbol}";

            if (!chart1.ChartAreas.Any(ca => ca.Name == chartAreaName))
            {
                var newChartArea = new ChartArea(chartAreaName);
                newChartArea.AxisX.LabelStyle.Format = "HH:mm";
                newChartArea.AxisX.MajorGrid.Enabled = false;
                newChartArea.AxisY.MajorGrid.Enabled = false;
                newChartArea.AxisY.LabelStyle.Format = "0.########";
                chart1.ChartAreas.Add(newChartArea);
            }

            series.ChartArea = chartAreaName;

            foreach (var chartArea in chart1.ChartAreas)
            {
                chartArea.RecalculateAxesScale();
            }
        }

        // 🔹 **Tunnistaa kryptovaluutan valuutan nimen perusteella**
        private string GetCurrencyFromSymbol(string symbol)
        {
            string[] knownCurrencies = { "USDT", "EUR", "USD", "GBP", "JPY", "BUSD", "USDC" };

            foreach (var currency in knownCurrencies)
            {
                if (symbol.EndsWith(currency))
                {
                    return currency;
                }
            }

            return "Tuntematon"; // Jos ei tunnisteta
        }

        // 🔹 **Päivittää hintaseurannan (ListBox)**
        private async Task UpdatePriceTracker()
        {
            // Kopioidaan valitut kryptot listaan ennen silmukointia, jotta CheckedItems ei muutu kesken iteraation
            var checkedCryptos = checkedListBoxCryptos.CheckedItems.Cast<string>().ToList();

            // Päivitetään hinnat taustasäikeessä, jotta UI ei jäädy
            await Task.Run(async () =>
            {
                var newItems = new List<string>(); // Uusi lista, jotta vältetään UI:n suora muokkaus silmukan aikana

                foreach (var symbol in checkedCryptos)
                {
                    var priceData = await FetchBinanceKlines(symbol);
                    if (priceData == null || priceData.Count == 0)
                        continue;

                    string currency = GetCurrencyFromSymbol(symbol);
                    double latestPrice = priceData.Last().Item2;

                    newItems.Add($"{symbol}: {latestPrice} {currency}");
                }

                // Päivitetään UI-pääsäikeessä
                Invoke(new Action(() =>
                {
                    listBoxPriceTracker.Items.Clear();
                    foreach (var item in newItems)
                    {
                        listBoxPriceTracker.Items.Add(item);
                    }
                }));
            });
        }

    }
}
