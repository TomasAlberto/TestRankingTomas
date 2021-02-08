using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coding_test_ranking.infrastructure.persistence
{
    public class InMemoryPersistence
    {
        private List<AdVO> ads;
        private List<PictureVO> pictures;
        public List<AdVO> Ads   // property
        {
            get { return ads; }   // get method
        }

        public List<PictureVO> Pictures   // property
        {
            get { return pictures; }   // get method
        }




        public InMemoryPersistence()
        {
            ads = new List<AdVO>();
            ads.Add(new AdVO { Id = 1, Typology = "CHALET", Description = "Este piso es una ganga, compra, compra, COMPRA!!!!!", Pictures = new List<int>(), HouseSize = 300 });
            ads.Add(new AdVO { Id = 2, Typology = "FLAT", Description = "Nuevo ático céntrico recién reformado. No deje pasar la oportunidad y adquiera este ático de lujo", Pictures = new List<int> { 4 }, HouseSize = 300 });
            ads.Add(new AdVO { Id = 3, Typology = "CHALET", Description = "", Pictures = new List<int> { 2 }, HouseSize = 300 });
            ads.Add(new AdVO { Id = 4, Typology = "FLAT", Description = "Ático céntrico muy luminoso y recién reformado, parece nuevo", Pictures = new List<int> { 5 }, HouseSize = 300 });
            ads.Add(new AdVO { Id = 5, Typology = "FLAT", Description = "Pisazo,", Pictures = new List<int> { 3, 8 }, HouseSize = 300 });
            ads.Add(new AdVO { Id = 6, Typology = "GARAGE", Description = "", Pictures = new List<int> { 6 }, HouseSize = 300 });
            ads.Add(new AdVO { Id = 7, Typology = "GARAGE", Description = "Garaje en el centro de Albacete", Pictures = new List<int>(), HouseSize = 300 });
            ads.Add(new AdVO { Id = 8, Typology = "CHALET", Description = "Maravilloso chalet situado en lAs afueras de un pequeño pueblo rural. El entorno es espectacular, las vistas magníficas. ¡Cómprelo ahora!", Pictures = new List<int> { 1, 7 }, HouseSize = 300 });

            pictures = new List<PictureVO>();
            pictures.Add(new PictureVO { Id = 1, Url = "http://www.idealista.com/pictures/1", Quality = "SD" });
            pictures.Add(new PictureVO { Id = 2, Url = "http://www.idealista.com/pictures/2", Quality = "HD" });
            pictures.Add(new PictureVO { Id = 3, Url = "http://www.idealista.com/pictures/3", Quality = "SD" });
            pictures.Add(new PictureVO { Id = 4, Url = "http://www.idealista.com/pictures/4", Quality = "HD" });
            pictures.Add(new PictureVO { Id = 5, Url = "http://www.idealista.com/pictures/5", Quality = "SD" });
            pictures.Add(new PictureVO { Id = 6, Url = "http://www.idealista.com/pictures/6", Quality = "SD" });
            pictures.Add(new PictureVO { Id = 7, Url = "http://www.idealista.com/pictures/7", Quality = "SD" });
            pictures.Add(new PictureVO { Id = 8, Url = "http://www.idealista.com/pictures/8", Quality = "HD" });



        }
        
}
}
