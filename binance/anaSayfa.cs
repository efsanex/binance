using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Binance.API.Csharp.Client;
using Newtonsoft.Json;

namespace binance
{
    public partial class anaSayfa : Form
    {
        private static ApiClient apiClient = new ApiClient("api", "secret");
        private static BinanceClient binanceClient = new BinanceClient(apiClient, false);

        public anaSayfa()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            coinTxt_1.Text = Properties.Settings.Default.coinTxt_1;
            coinLbl_1.Text = Properties.Settings.Default.coinTxt_1;
            alisTxt_1.Text = Properties.Settings.Default.alisTxt_1.ToString();
            alisLbl_1.Text = Properties.Settings.Default.alisTxt_1.ToString();
            adetTxt_1.Text = Properties.Settings.Default.adetTxt_1.ToString();
            adetLbl_1.Text = Properties.Settings.Default.adetTxt_1.ToString();

            coinTxt_2.Text = Properties.Settings.Default.coinTxt_2;
            coinLbl_2.Text = Properties.Settings.Default.coinTxt_2;
            alisTxt_2.Text = Properties.Settings.Default.alisTxt_2.ToString();
            alisLbl_2.Text = Properties.Settings.Default.alisTxt_2.ToString();
            adetTxt_2.Text = Properties.Settings.Default.adetTxt_2.ToString();
            adetLbl_2.Text = Properties.Settings.Default.adetTxt_2.ToString();

            coinTxt_3.Text = Properties.Settings.Default.coinTxt_3;
            coinLbl_3.Text = Properties.Settings.Default.coinTxt_3;
            alisTxt_3.Text = Properties.Settings.Default.alisTxt_3.ToString();
            alisLbl_3.Text = Properties.Settings.Default.alisTxt_3.ToString();
            adetTxt_3.Text = Properties.Settings.Default.adetTxt_3.ToString();
            adetLbl_3.Text = Properties.Settings.Default.adetTxt_3.ToString();

            coinTxt_4.Text = Properties.Settings.Default.coinTxt_4;
            coinLbl_4.Text = Properties.Settings.Default.coinTxt_4;
            alisTxt_4.Text = Properties.Settings.Default.alisTxt_4.ToString();
            alisLbl_4.Text = Properties.Settings.Default.alisTxt_4.ToString();
            adetTxt_4.Text = Properties.Settings.Default.adetTxt_4.ToString();
            adetLbl_4.Text = Properties.Settings.Default.adetTxt_4.ToString();

            coinTxt_5.Text = Properties.Settings.Default.coinTxt_5;
            coinLbl_5.Text = Properties.Settings.Default.coinTxt_5;
            alisTxt_5.Text = Properties.Settings.Default.alisTxt_5.ToString();
            alisLbl_5.Text = Properties.Settings.Default.alisTxt_5.ToString();
            adetTxt_5.Text = Properties.Settings.Default.adetTxt_5.ToString();
            adetLbl_5.Text = Properties.Settings.Default.adetTxt_5.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            binanceWorker.RunWorkerAsync();
        }
        public DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixtime).ToLocalTime();
            return dtDateTime;
        }

        private void binanceWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                while(true)
                {
                    var serverTime = binanceClient.GetServerTime().Result;
                    label9.Text = UnixTimeToDateTime(serverTime.ServerTime).ToString();

                    var tickerPrices = binanceClient.GetAllPrices().Result;

                    List<coinler> coinler_ = new List<coinler>();
                    coinler_.Clear();
                    foreach (var coin in tickerPrices)
                    {
                        coinler_.Add(new coinler()
                        {
                            coinAdi = coin.Symbol.ToString(),
                            coinFiyati = (decimal)coin.Price,
                        });
                    }

                    coinler coin_1 = coinler_.Find(x => x.coinAdi == coinLbl_1.Text);
                    if (coin_1 != null)
                    {
                        anlikLbl_1.Text = coin_1.coinFiyati.ToString("F3");
                        decimal alisToplam1 = Convert.ToDecimal(adetLbl_1.Text) * Convert.ToDecimal(alisLbl_1.Text);
                        decimal toplamFiyat_1 = coin_1.coinFiyati * Convert.ToDecimal(adetLbl_1.Text);
                        toplamFiyatiLbl_1.Text = toplamFiyat_1.ToString("F3");
                        if (alisToplam1 > toplamFiyat_1)
                        {
                            degisimLibl_1.ForeColor = Color.Red;
                            degisimLibl_1.Text = (alisToplam1 - toplamFiyat_1).ToString("F3");
                            yuzdeLbl_1.Text = "% " + (((alisToplam1 - toplamFiyat_1) / toplamFiyat_1) * 100).ToString("F3");
                            yuzdeLbl_1.ForeColor = Color.Red;
                        }
                        if (alisToplam1 < toplamFiyat_1)
                        {
                            degisimLibl_1.ForeColor = Color.Green;
                            degisimLibl_1.Text = (toplamFiyat_1 - alisToplam1).ToString("F3");
                            yuzdeLbl_1.Text = "% " + (((toplamFiyat_1 - alisToplam1) / alisToplam1) * 100).ToString("F3");
                            yuzdeLbl_1.ForeColor = Color.Green;
                        }
                    }

                    coinler coin_2 = coinler_.Find(x => x.coinAdi == coinLbl_2.Text);
                    if (coin_2 != null)
                    {
                        anlikLbl_2.Text = coin_2.coinFiyati.ToString("F3");
                        decimal alisToplam2 = Convert.ToDecimal(adetLbl_2.Text) * Convert.ToDecimal(alisLbl_2.Text);
                        decimal toplamFiyat_2 = coin_2.coinFiyati * Convert.ToDecimal(adetLbl_2.Text);
                        toplamFiyatiLbl_2.Text = toplamFiyat_2.ToString("F3");
                        if (alisToplam2 > toplamFiyat_2)
                        {
                            degisimLibl_2.ForeColor = Color.Red;
                            degisimLibl_2.Text = (alisToplam2 - toplamFiyat_2).ToString("F3");
                            yuzdeLbl_2.Text = "% " + (((alisToplam2 - toplamFiyat_2) / toplamFiyat_2) * 100).ToString("F3");
                            yuzdeLbl_2.ForeColor = Color.Red;
                        }
                        if (alisToplam2 < toplamFiyat_2)
                        {
                            degisimLibl_1.ForeColor = Color.Green;
                            degisimLibl_1.Text = (toplamFiyat_2 - alisToplam2).ToString("F3");
                            yuzdeLbl_2.Text = "% " + (((toplamFiyat_2 - alisToplam2) / alisToplam2) * 100).ToString("F3");
                            yuzdeLbl_2.ForeColor = Color.Green;
                        }
                    }

                    coinler coin_3 = coinler_.Find(x => x.coinAdi == coinLbl_3.Text);
                    if (coin_3 != null)
                    {
                        anlikLbl_3.Text = coin_3.coinFiyati.ToString("F3");
                        decimal alisToplam3 = Convert.ToDecimal(adetLbl_3.Text) * Convert.ToDecimal(alisLbl_3.Text);
                        decimal toplamFiyat_3 = coin_3.coinFiyati * Convert.ToDecimal(adetLbl_3.Text);
                        toplamFiyatiLbl_3.Text = toplamFiyat_3.ToString("F3");
                        if (alisToplam3 > toplamFiyat_3)
                        {
                            degisimLibl_3.ForeColor = Color.Red;
                            degisimLibl_3.Text = (alisToplam3 - toplamFiyat_3).ToString("F3");
                            yuzdeLbl_3.Text = "% " + (((alisToplam3 - toplamFiyat_3) / toplamFiyat_3) * 100).ToString("F3");
                            yuzdeLbl_3.ForeColor = Color.Red;
                        }
                        if (alisToplam3 < toplamFiyat_3)
                        {
                            degisimLibl_1.ForeColor = Color.Green;
                            degisimLibl_1.Text = (toplamFiyat_3 - alisToplam3).ToString("F3");
                            yuzdeLbl_1.Text = "% " + (((toplamFiyat_3 - alisToplam3) / alisToplam3) * 100).ToString("F3");
                            yuzdeLbl_1.ForeColor = Color.Green;
                        }
                    }

                    coinler coin_4 = coinler_.Find(x => x.coinAdi == coinLbl_4.Text);
                    if (coin_4 != null)
                    {
                        anlikLbl_4.Text = coin_4.coinFiyati.ToString("F3");
                        decimal alisToplam4 = Convert.ToDecimal(adetLbl_4.Text) * Convert.ToDecimal(alisLbl_4.Text);
                        decimal toplamFiyat_4 = coin_4.coinFiyati * Convert.ToDecimal(adetLbl_4.Text);
                        toplamFiyatiLbl_4.Text = toplamFiyat_4.ToString("F3");
                        if (alisToplam4 > toplamFiyat_4)
                        {
                            degisimLibl_4.ForeColor = Color.Red;
                            degisimLibl_4.Text = (alisToplam4 - toplamFiyat_4).ToString("F3");
                            yuzdeLbl_4.Text = "% " + (((alisToplam4 - toplamFiyat_4) / toplamFiyat_4) * 100).ToString("F3");
                            yuzdeLbl_4.ForeColor = Color.Red;
                        }
                        if (alisToplam4 < toplamFiyat_4)
                        {
                            degisimLibl_4.ForeColor = Color.Green;
                            degisimLibl_4.Text = (toplamFiyat_4 - alisToplam4).ToString("F3");
                            yuzdeLbl_4.Text = "% " + (((toplamFiyat_4 - alisToplam4) / alisToplam4) * 100).ToString("F3");
                            yuzdeLbl_4.ForeColor = Color.Green;
                        }
                    }

                    coinler coin_5 = coinler_.Find(x => x.coinAdi == coinLbl_5.Text);
                    if (coin_5 != null)
                    {
                        anlikLbl_5.Text = coin_5.coinFiyati.ToString("F3");
                        decimal alisToplam5 = Convert.ToDecimal(adetLbl_5.Text) * Convert.ToDecimal(alisLbl_5.Text);
                        decimal toplamFiyat_5 = coin_5.coinFiyati * Convert.ToDecimal(adetLbl_5.Text);
                        toplamFiyatiLbl_5.Text = toplamFiyat_5.ToString("F3");
                        if (alisToplam5 > toplamFiyat_5)
                        {
                            degisimLibl_5.ForeColor = Color.Red;
                            degisimLibl_5.Text = (alisToplam5 - toplamFiyat_5).ToString("F3");
                            yuzdeLbl_5.Text = "% " + (((alisToplam5 - toplamFiyat_5) / toplamFiyat_5) * 100).ToString("F3");
                            yuzdeLbl_5.ForeColor = Color.Red;
                        }
                        if (alisToplam5 < toplamFiyat_5)
                        {
                            degisimLibl_5.ForeColor = Color.Green;
                            degisimLibl_5.Text = (toplamFiyat_5 - alisToplam5).ToString("F3");
                            yuzdeLbl_5.Text = "% " + (((toplamFiyat_5 - alisToplam5) / alisToplam5) * 100).ToString("F3");
                            yuzdeLbl_5.ForeColor = Color.Green;
                        }
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void kaydet_1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.coinTxt_1 = coinTxt_1.Text;
            coinLbl_1.Text = coinTxt_1.Text;
            Properties.Settings.Default.alisTxt_1 = Convert.ToDecimal(alisTxt_1.Text);
            alisLbl_1.Text = alisTxt_1.Text;
            Properties.Settings.Default.adetTxt_1 = Convert.ToDecimal(adetTxt_1.Text);
            adetLbl_1.Text = adetTxt_1.Text;
            Properties.Settings.Default.Save();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.coinTxt_2 = coinTxt_2.Text;
            coinLbl_2.Text = coinTxt_2.Text;
            Properties.Settings.Default.alisTxt_2 = Convert.ToDecimal(alisTxt_2.Text);
            alisLbl_2.Text = alisTxt_2.Text;
            Properties.Settings.Default.adetTxt_2 = Convert.ToDecimal(adetTxt_2.Text);
            adetLbl_2.Text = adetTxt_2.Text;
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.coinTxt_3 = coinTxt_3.Text;
            coinLbl_3.Text = coinTxt_3.Text;
            Properties.Settings.Default.alisTxt_3 = Convert.ToDecimal(alisTxt_3.Text);
            alisLbl_3.Text = alisTxt_3.Text;
            Properties.Settings.Default.adetTxt_3 = Convert.ToDecimal(adetTxt_3.Text);
            adetLbl_3.Text = adetTxt_3.Text;
            Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.coinTxt_4 = coinTxt_4.Text;
            coinLbl_4.Text = coinTxt_4.Text;
            Properties.Settings.Default.alisTxt_4 = Convert.ToDecimal(alisTxt_4.Text);
            alisLbl_4.Text = alisTxt_4.Text;
            Properties.Settings.Default.adetTxt_4 = Convert.ToDecimal(adetTxt_4.Text);
            adetLbl_4.Text = adetTxt_4.Text;
            Properties.Settings.Default.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.coinTxt_5 = coinTxt_5.Text;
            coinLbl_5.Text = coinTxt_5.Text;
            Properties.Settings.Default.alisTxt_5 = Convert.ToDecimal(alisTxt_5.Text);
            alisLbl_5.Text = alisTxt_5.Text;
            Properties.Settings.Default.adetTxt_5 = Convert.ToDecimal(adetTxt_5.Text);
            adetLbl_5.Text = adetTxt_5.Text;
            Properties.Settings.Default.Save();
        }
    }
}
