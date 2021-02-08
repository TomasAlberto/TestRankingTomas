using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coding_test_ranking.infrastructure.persistence
{
    public class AdVO
    {
        public int Id { get; set; }
        public string Typology { get; set; }
        public string Description { get; set; }
        public List<int> Pictures { get; set; }
        public int? HouseSize { get; set; }
        public int? GardenSize { get; set; }
        public int? Score { get; set; }
        public DateTime? IrrelevantSince { get; set; }

    }
}
