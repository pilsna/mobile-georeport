using System.Windows;
using System.Windows.Controls;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Tasks;

namespace Kabellaegning
{
    public partial class MainPage
    {
        public Graphic CurrentLookUpElement;
        private readonly App _app;

        public MainPage()
        {
            InitializeComponent();
            _app = (App)Application.Current;

            var baseLayer = (ArcGISDynamicMapServiceLayer) Map.Layers["BaseLayer"];
            baseLayer.ProxyURL = "http://" + _app.Proxy + ".dongenergy.dk/mapserverproxy/Proxy.ashx";
            baseLayer.Url = "http://kabellaegningGrundkort";            
        }

        void BaseLayerInitialized(object sender, System.EventArgs e)
        {
            MyFeatureSearch.ProxyUrl = "http://" + _app.Proxy + ".dongenergy.dk/mapserverproxy/Proxy.ashx";
            MyFeatureSearch.QueryServiceUri = "http://kabellaegningFeatureSearch/0";
            MyFeatureSearch.ExecuteComplete += MyFeatureSearchExecuteComplete;
        }

        void BaseLayerInitializedFailed(object sender, System.EventArgs e)
        {
            var layer = sender as Layer;
            if (layer != null)
                MessageBox.Show(string.Format("The layer {0} failed to initialize due to {1}", layer.ID, layer.InitializationFailure.Message));
        }

        void MyFeatureSearchExecuteComplete(object sender, QueryEventArgs e)
        {
            var layer = Map.Layers["MyGraphicsLayer"] as GraphicsLayer;
            if (layer != null)
                layer.ClearGraphics();

            if (e.FeatureSet != null)
            {
                foreach (Graphic graphic in e.FeatureSet)
                {
                    if (graphic.Geometry != null)
                    {
                        if (graphic.Geometry.GetType() == typeof(MapPoint))
                        {
                            graphic.Symbol = CustomStrobeMarkerSymbol;
                        }
                        else if (graphic.Geometry.GetType() == typeof(Polyline))
                        {
                            graphic.Symbol = BasicLineSymbol_Red_3;
                        }
                        else
                        {
                            graphic.Symbol = BasicFillSymbol_Red_Trans_5;
                        }

                        if (layer != null) 
                            layer.Graphics.Add(graphic);

                        // Try to make a look up based on the returned graphic
                        ExecuteQueryTask(graphic.Geometry.Extent.GetCenter());
                    }
                }
            }
        }

        private void MapMouseClick(object sender, Map.MouseEventArgs e)
        {
            Reset();

            ExecuteQueryTask(e.MapPoint);
        }

        private void Reset()
        {
            MyFeatureSearch.Reset();

            var layer = Map.Layers["MyGraphicsLayer"] as GraphicsLayer;
            if (layer != null)
                layer.ClearGraphics();
        }

        private void ExecuteQueryTask(Geometry geometry)
        {
            var query = new Query
                            {
                Geometry = geometry
            };
            query.OutFields.Add("*");

            var queryTask = new QueryTask("http://kabellaegningFeatureQuery")
                                {
                                    ProxyURL = "http://" + _app.Proxy + ".dongenergy.dk/mapserverproxy/Proxy.ashx"
                                };
            queryTask.ExecuteCompleted += LookUpCompleted;
            queryTask.Failed += QueryTaskFailed;
            queryTask.ExecuteAsync(query);
        }       

        private void LookUpCompleted(object sender, QueryEventArgs e)
        {
            if (e.FeatureSet != null)
            {
                if (e.FeatureSet.Features != null)
                {
                    if(InfoPanel != null)
                        InfoPanel.Graphic = e.FeatureSet.Features.Count > 0 ? e.FeatureSet.Features[0] : null;
                }
            }
        }

        private void QueryTaskFailed(object sender, TaskFailedEventArgs e)
        {
            MessageBox.Show("Forespørgslen fejlede desværre.");
        }
    }
}