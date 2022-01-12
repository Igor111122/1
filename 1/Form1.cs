using System;
using MaterialSkin.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : MaterialForm
    {

       string BitcoinPrice2,EthereumPrice2,TetherPrice2, LitecoinPrice2,RipplePrice2,DogecoinPrice2,SolanaPrice2,MoneroPrice2, CardanoPrice2,TravalaPrice2,TerraPrice2;
       string Bitcoin_24h_Chg2,Ethereum_24h_Chg2,Tether_24h_Chg2,Litecoin_24h_Chg2,Ripple_24h_Chg2,Dogecoin_24h_Chg2,Solana_24h_Chg2,Monero_24h_Chg2,Cardano_24h_Chg2,Travala_24h_Chg2,Terra_24h_Chg2;

        public Form1()
        {
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue800, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue800, MaterialSkin.Accent.Orange700, MaterialSkin.TextShade.WHITE);
            InitializeComponent();
        }

        string Price_coin(string url) {

            string responseString = string.Empty;
            WebClient webClient = new WebClient();
            responseString = webClient.DownloadString(url);
            int indexofprice = responseString.IndexOf("price") + 8;
            return responseString.Substring(indexofprice, responseString.Length - 7 - indexofprice);
        }

        string Price_change_coin(string url)
        {
            WebClient webClient = new WebClient();
            string responseString = string.Empty;
            responseString = webClient.DownloadString(url);
            int indexofprice = responseString.IndexOf("priceChangePercent") + 21;

            return responseString.Substring(indexofprice, 5);
        }


        void update_price() {

            BitcoinPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=BTCUSDC");
            EthereumPrice2= Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=ETHUSDC");
            TetherPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=USDCUSDT");
            LitecoinPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=LTCUSDC");
            RipplePrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=XRPUSDC");
            DogecoinPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=DOGEUSDT");
            SolanaPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=SOLUSDC");
            MoneroPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=XMRUSDT");
            CardanoPrice2= Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=ADAUSDC");
            TravalaPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=AVAUSDT");
            TerraPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=LUNAUSDT");


        }


        void update_24h_Chg()
        {

            Bitcoin_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=BTCUSDC");
            Ethereum_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=ETHUSDC");
            Tether_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=USDCUSDT");
            Litecoin_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=LTCUSDC");
            Ripple_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=XRPUSDC");
            Dogecoin_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=DOGEUSDT");
            Solana_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=SOLUSDC");
            Monero_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=XMRUSDT");
            Cardano_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=ADAUSDC");
            Travala_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=AVAUSDT");
            Terra_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=LUNAUSDT");



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread myThread = new Thread(new ThreadStart(update_price));
            myThread.Start();

            Thread myThread2 = new Thread(new ThreadStart(update_24h_Chg));
            myThread2.Start();

            BitcoinPrice.Text = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=BTCUSDC");
            EthereumPrice.Text = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=ETHUSDC");
            TetherPrice.Text = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=USDCUSDT");
            LitecoinPrice.Text = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=LTCUSDC");
            RipplePrice.Text = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=XRPUSDC");
            DogecoinPrice.Text = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=DOGEUSDT");
            SolanaPrice.Text = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=SOLUSDC");
            MoneroPrice.Text = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=XMRUSDT");
            CardanoPrice.Text = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=ADAUSDC");
            TravalaPrice.Text = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=AVAUSDT");
            TerraPrice.Text = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=LUNAUSDT");

            Bitcoin_24h_Chg.Text = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=BTCUSDC");
            Ethereum_24h_Chg.Text = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=ETHUSDC");
            Tether_24h_Chg.Text = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=USDCUSDT");
            Litecoin_24h_Chg.Text = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=LTCUSDC");
            Ripple_24h_Chg.Text = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=XRPUSDC");
            Dogecoin_24h_Chg.Text = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=DOGEUSDT");
            Solana_24h_Chg.Text = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=SOLUSDC");
            Monero_24h_Chg.Text = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=XMRUSDT");
            Cardano_24h_Chg.Text = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=ADAUSDC");
            Travala_24h_Chg.Text = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=AVAUSDT");
            Terra_24h_Chg.Text = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=LUNAUSDT");

            if (Bitcoin_24h_Chg.Text[0] == '-')
            {
                Bitcoin_24h_Chg.ForeColor = Color.Red;
            }
            else {
                Bitcoin_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Ethereum_24h_Chg.Text[0] == '-')
            {
                Ethereum_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Ethereum_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Tether_24h_Chg.Text[0] == '-')
            {
                Tether_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Tether_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Litecoin_24h_Chg.Text[0] == '-')
            {
                Litecoin_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Litecoin_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Ripple_24h_Chg.Text[0] == '-')
            {
                Ripple_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Ripple_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Dogecoin_24h_Chg.Text[0] == '-')
            {
                Dogecoin_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Dogecoin_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Solana_24h_Chg.Text[0] == '-')
            {
                Solana_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Solana_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Monero_24h_Chg.Text[0] == '-')
            {
                Monero_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Monero_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Cardano_24h_Chg.Text[0] == '-')
            {
                Cardano_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Cardano_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Travala_24h_Chg.Text[0] == '-')
            {
                Travala_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Travala_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Terra_24h_Chg.Text[0] == '-')
            {
                Terra_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Terra_24h_Chg.ForeColor = Color.Green;
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            Thread myThread = new Thread(new ThreadStart(update_price));
            myThread.Start();
            BitcoinPrice.Text = BitcoinPrice2;
            EthereumPrice.Text = EthereumPrice2;
            TetherPrice.Text = TetherPrice2;
            LitecoinPrice.Text = LitecoinPrice2;
            RipplePrice.Text = RipplePrice2;
            DogecoinPrice.Text = DogecoinPrice2;
            SolanaPrice.Text = SolanaPrice2;
            MoneroPrice.Text = MoneroPrice2;
            CardanoPrice.Text = CardanoPrice2;
            TravalaPrice.Text = TravalaPrice2;
            TerraPrice.Text = TerraPrice2;


            Thread myThread2 = new Thread(new ThreadStart(update_24h_Chg));
            myThread2.Start();
            Bitcoin_24h_Chg.Text = Bitcoin_24h_Chg2;
            Ethereum_24h_Chg.Text = Ethereum_24h_Chg2;
            Tether_24h_Chg.Text = Tether_24h_Chg2;
            Litecoin_24h_Chg.Text = Litecoin_24h_Chg2;
            Ripple_24h_Chg.Text = Ripple_24h_Chg2;
            Dogecoin_24h_Chg.Text = Dogecoin_24h_Chg2;
            Solana_24h_Chg.Text = Solana_24h_Chg2;
            Monero_24h_Chg.Text = Monero_24h_Chg2;
            Cardano_24h_Chg.Text = Cardano_24h_Chg2;
            Travala_24h_Chg.Text = Travala_24h_Chg2;
            Terra_24h_Chg.Text = Terra_24h_Chg2;

        }
    }
}
