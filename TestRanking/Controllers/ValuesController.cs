using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using coding_test_ranking.infrastructure.api;
using coding_test_ranking.infrastructure.persistence;
using Microsoft.AspNetCore.Mvc;

namespace TestRanking.Controllers
{


    public class ValuesController : ApiController
    {

        [System.Web.Http.HttpGet]
        public ActionResult<IEnumerable<QualityAd>> GetScore()
        {
            InMemoryPersistence Persistence = new InMemoryPersistence();
            int score = 0;
            int LengthDescription = 0;
            string Description = "";
            List<QualityAd> QualityList = new List<QualityAd>();
            List<string> terms = new List<string>() { "Luminoso", "Nuevo", "Céntrico", "Reformado", "Ático" };
            List<string> PictureUrls = new List<string>();
            for (int i = 0; i < Persistence.Ads.Count; i++)
            {
                LengthDescription = Persistence.Ads[i].Description.Length;
                Description = Persistence.Ads[i].Description;

                if (Persistence.Ads[i].Pictures.Count < 0)
                    score = score - 10; //comprobación de imagen
                else
                {
                    foreach (int item in Persistence.Ads[i].Pictures)
                    {
                        PictureUrls.Add(Persistence.Pictures[item - 1].Url);
                        if (Persistence.Pictures[item - 1].Quality == "HD") score = score + 20;
                        else score = score + 10;
                    }
                }

                if (LengthDescription > 0) score = score + 5; //comprobación de descripción

                if (Persistence.Ads[i].Typology == "CHALET")      //comprobación de tamaño descripción
                {
                    if (LengthDescription > 20 && LengthDescription < 50) score = score + 10;
                    if (LengthDescription > 50) score = score + 30;
                }

                if (Persistence.Ads[i].Typology == "FLAT")
                {

                    if (LengthDescription > 50) score = score + 20;
                }

                for (int a = 0; a < terms.Count; a++)
                {
                    if (Description.ToLower().Contains(terms[a].ToLower())) score = score + 5;
                }

                if (iscomplete(Persistence.Ads[i], LengthDescription)) score = score + 40;

                Persistence.Ads[i].Score = score;

                QualityList.Add(new QualityAd
                {
                    Id = Persistence.Ads[i].Id,
                    Typology = Persistence.Ads[i].Typology,
                    Description = Persistence.Ads[i].Description,
                    PictureUrls = PictureUrls,
                    HouseSize = Persistence.Ads[i].HouseSize,
                    GardenSize = Persistence.Ads[i].GardenSize,
                    Score = score,
                    IrrelevantSince = Persistence.Ads[i].IrrelevantSince
                });

            }
            QualityList = QualityList.OrderBy(s => s.Score).ToList();
            return QualityList;

        }
        [System.Web.Http.HttpGet]
        public ActionResult<IEnumerable<PublicAd>> GetPublicListing()
        {
            List<PublicAd> PublicAds = new List<PublicAd>();
            List<QualityAd> QualityList = GetScore().Value.ToList();


            foreach (QualityAd item in QualityList)
            {
                if (item.Score > 40)
                {
                    PublicAds.Add(new PublicAd
                    {
                        Id = item.Id,
                        Typology = item.Typology,
                        Description = item.Description,
                        PictureUrls = item.PictureUrls,
                        HouseSize = item.HouseSize,
                        GardenSize = item.GardenSize

                    });
                }
            }
            //this.PublicAds = PublicAds;
            return PublicAds;


        }
        [System.Web.Http.HttpGet]
        public ActionResult<IEnumerable<QualityAd>> GetQualityListing()
        {
            List<QualityAd> QualityList = new List<QualityAd>();
            List<QualityAd> ScoreList = GetScore().Value.ToList();


            foreach (QualityAd item in ScoreList)
            {
                if (item.Score < 40)
                {
                    QualityList.Add(item);
                }
            }
            //this.QualityList = QualityList;
            return QualityList;
        }





        private bool iscomplete(AdVO ad, int LengthDescription)
        {
            if (ad.Pictures.Count == 0) return false; //comprobación de imagen

            if (LengthDescription == 0 && (ad.Typology != "GARAGE")) return false; //comprobación de descripción

            if (ad.Typology == "FLAT" && ad.HouseSize.HasValue == false) return false;

            if (ad.Typology == "CHALET" && (ad.HouseSize.HasValue == false || ad.GardenSize.HasValue == false)) return false;

            return true;

        }
    }
}
