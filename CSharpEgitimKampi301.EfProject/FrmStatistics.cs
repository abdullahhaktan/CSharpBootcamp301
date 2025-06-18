using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EfProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text=db.Location.Sum(x=>x.Capacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAverageCapacity.Text = db.Location.Average(x=>x.Capacity).ToString();
            lblAvgLocationPrice.Text = db.Location.Average(x=>x.Price ?? 0).ToString("F2");
        
            int lastCountryId = db.Location.Max(x=>x.LocationId);     
            lblLastEnteredCountry.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(x => x.Country).FirstOrDefault();

            lblCapadociaTurCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(x => x.Capacity).FirstOrDefault().ToString();

            lblTurkiyeAvgCapacity.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            var romaGuideId = db.Location.Where(x => x.City == "Roma Turistik").Select(y => y.GuideId).FirstOrDefault();

            lblRomaGuideName.Text = db.Guide.Where(x => x.GuideId == romaGuideId)
                .Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault();

            var maxCapasity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity == maxCapasity).Select(y => y.City).FirstOrDefault();
        
            var maxPrice = db.Location.Max(x=>x.Price);
            lblMaxPriceLocation.Text = db.Location.Where(x=>x.Price==maxPrice).Select(y=>y.City).FirstOrDefault();
        
            var guideIdByName=db.Guide.Where(x=>x.GuideName=="Ayşegül" && x.GuideSurname=="Çınar")
                .Select(x=>x.GuideId).FirstOrDefault();

            lblAysegulCinarLocationCount.Text = db.Location.Where(x => x.GuideId == guideIdByName).Count().ToString();
        }
    }
}
