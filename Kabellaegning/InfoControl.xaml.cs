using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using ESRI.ArcGIS.Client;

namespace Kabellaegning
{
    public partial class InfoControl
    {
        // Defaults
        private const string InfoMessageStatusText = "Søg efter en adresse eller klik i kortet for at se aktuel status for gravearbejdet i et område.";
        private const string Step1Text = "Vi forbereder";
        private const string Step2Text = "Vi graver";
        private const string Step3Text = "Vi tilslutter";
        private const string Step4Text = "Vi afslutter";
        private const string HeaderText = "Aktuelt for {0}{1}";
        private const string InfoMessageStatusNotAvailableText = "Vi graver ikke i dette område";

        private readonly CultureInfo _cu = new CultureInfo("da-DK");
        private Graphic _graphic;
        private ObservableCollection<ProgressInfo> _results;

        public InfoControl()
        {
            InitializeComponent();

            Header.Text = string.Empty;
            //InfoMessageStatus.Text = "12345678901234567890123456789012345678901234567890"
            //    + " 2345678901234567890123456789012345678901234567890"
            //    + " 2345678901234567890123456789012345678901234567890"
            //    + " 2345678901234567890123456789012345678901234567890"
            //    + " 2345678901234567890123456789012345678901234567890"
            //    + "hello";
            InfoMessageStatus.Text = InfoMessageStatusText;

            _results = new ObservableCollection<ProgressInfo>
                             {
                                 ToProgressInfo(1, Step1Text),
                                 ToProgressInfo(2, Step2Text),
                                 ToProgressInfo(3, Step3Text),
                                 ToProgressInfo(4, Step4Text)
                             };

            SearchResultItems.ItemsSource = _results;
        }

        /// <summary>
        /// Graphic object retrieved from the maps feature collection
        /// </summary>
        public Graphic Graphic
        {
            get { return _graphic; }
            set
            {
                _graphic = value;

                InitializeInfoPanel();
            }
        }

        /// <summary>
        /// InitializeInfoPanel the InfoPanel
        /// </summary>
        private void InitializeInfoPanel()
        {
            // Clear
            Header.Text = string.Empty;
            InfoMessageStatus.Text = string.Empty;

            if (_graphic != null)
            {
                // Message Panel
                Header.Text = string.Format(HeaderText, _graphic.Attributes["KOMMUNE"], string.IsNullOrEmpty(_graphic.Attributes["NYT_OMRAADE"].ToString()) ? string.Empty : " - " + _graphic.Attributes["NYT_OMRAADE"]);

                var begins = _graphic.Attributes["STATUSSTART"] == null
                                      ? DateTime.Now.AddDays(-1.0)
                                      : DateTime.Parse(_graphic.Attributes["STATUSSTART"].ToString());

                var expires = _graphic.Attributes["STATUSSLUT"] == null
                                       ? DateTime.Now.AddDays(1.0)
                                       : DateTime.Parse(_graphic.Attributes["STATUSSLUT"].ToString());

                if (DateTime.Now.CompareTo(begins) >= 0 & DateTime.Now.CompareTo(expires) <= 0)
                    InfoMessageStatus.Text = string.Format("{0}", _graphic.Attributes["BESKED"]);
            }
            else
            {
                InfoMessageStatus.Text = InfoMessageStatusNotAvailableText;
            }

            InfoMessageStatusBorder.Visibility = InfoMessageStatus.Text.Length == 0 ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;

            // Generate progress info
            _results = new ObservableCollection<ProgressInfo>
                             {
                                 ToProgressInfo(1, Step1Text),
                                 ToProgressInfo(2, Step2Text),
                                 ToProgressInfo(3, Step3Text),
                                 ToProgressInfo(4, Step4Text),
                             };

            SearchResultItems.ItemsSource = _results;
        }

        /// <summary>
        /// Converts Grahics info to ProgressInfo object
        /// </summary>
        /// <param name="fase"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private ProgressInfo ToProgressInfo(int fase, string name)
        {
            var info = new ProgressInfo { Name = name };
            try
            {
                if (_graphic != null)
                {
                    if (_graphic.Attributes["FASE" + fase + "START"] != null)
                    {
                        info.FromDate =
                            TurnFirstToUpper(
                                DateTime.Parse(_graphic.Attributes["FASE" + fase + "START"].ToString()).ToString(
                                    "MMM yyyy", _cu));
                    }

                    if (_graphic.Attributes["FASE" + fase + "START"] != null && _graphic.Attributes["FASE" + fase + "SLUT"] != null)
                    {
                        var startDate =
                            TurnFirstToUpper(
                                DateTime.Parse(_graphic.Attributes["FASE" + fase + "START"].ToString()).ToString(
                                    "MMM yyyy", _cu));
                        var endDate =
                            TurnFirstToUpper(
                                DateTime.Parse(_graphic.Attributes["FASE" + fase + "SLUT"].ToString()).ToString(
                                    "MMM yyyy", _cu));

                        if (startDate != endDate)
                            info.ToDate = endDate;
                    }
                }
            }
            catch(Exception e)
            {
                //There is no need to display an error, the user will just click again
                //Just catch the exception
            }

            return info;
        }

        /// <summary>
        /// Turn first character in a string to Upper case 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string TurnFirstToUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var a = input.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }

    /// <summary>
    /// Item for the ItemsControl
    /// </summary>
    public class ProgressInfo : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _fromDate;
        public string FromDate
        {
            get { return _fromDate; }
            set
            {
                _fromDate = value;
                OnPropertyChanged("FromDate");
            }
        }

        private string _toDate;
        public string ToDate
        {
            get { return _toDate; }
            set
            {
                _toDate = value;
                OnPropertyChanged("ToDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}