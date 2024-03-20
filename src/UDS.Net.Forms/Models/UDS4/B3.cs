using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDS.Net.Forms.Models.UDS4
{
    public class B3 : FormModel
    {
        public bool? PDNORMAL { get; set; }

        public int? SPEECH { get; set; }
        [MaxLength(60)]
        public string? SPEECHX { get; set; }

        public int? FACEXP { get; set; }
        [MaxLength(60)]
        public string? FACEXPX { get; set; }

        public int? TRESTFAC { get; set; }
        [MaxLength(60)]
        public string? TRESTFAX { get; set; }

        public int? TRESTRHD { get; set; }
        [MaxLength(60)]
        public string? TRESTRHX { get; set; }

        public int? TRESTLHD { get; set; }
        [MaxLength(60)]
        public string? TRESTLHX { get; set; }

        public int? TRESTRFT { get; set; }
        [MaxLength(60)]
        public string? TRESTRFX { get; set; }

        public int? TRESTLFT { get; set; }
        [MaxLength(60)]
        public string? TRESTLFX { get; set; }

        public int? TRACTRHD { get; set; }
        [MaxLength(60)]
        public string? TRACTRHX { get; set; }

        public int? TRACTLHD { get; set; }
        [MaxLength(60)]
        public string? TRACTLHX { get; set; }

        public int? RIGDNECK { get; set; }
        [MaxLength(60)]
        public string? RIGDNEX { get; set; }

        public int? RIGDUPRT { get; set; }
        [MaxLength(60)]
        public string? RIGDUPRX { get; set; }

        public int? RIGDUPLF { get; set; }
        [MaxLength(60)]
        public string? RIGDUPLX { get; set; }

        public int? RIGDLORT { get; set; }
        [MaxLength(60)]
        public string? RIGDLORX { get; set; }

        public int? RIGDLOLF { get; set; }
        [MaxLength(60)]
        public string? RIGDLOLX { get; set; }

        public int? TAPSRT { get; set; }
        [MaxLength(60)]
        public string? TAPSRTX { get; set; }

        public int? TAPSLF { get; set; }
        [MaxLength(60)]
        public string? TAPSLFX { get; set; }

        public int? HANDMOVR { get; set; }
        [MaxLength(60)]
        public string? HANDMVRX { get; set; }

        public int? HANDMOVL { get; set; }
        [MaxLength(60)]
        public string? HANDMVLX { get; set; }

        public int? HANDALTR { get; set; }
        [MaxLength(60)]
        public string? HANDATRX { get; set; }

        public int? HANDALTL { get; set; }
        [MaxLength(60)]
        public string? HANDATLX { get; set; }

        public int? LEGRT { get; set; }
        [MaxLength(60)]
        public string? LEGRTX { get; set; }

        public int? LEGLF { get; set; }
        [MaxLength(60)]
        public string? LEGLFX { get; set; }

        public int? ARISING { get; set; }
        [MaxLength(60)]
        public string? ARISINGX { get; set; }

        public int? POSTURE { get; set; }
        [MaxLength(60)]
        public string? POSTUREX { get; set; }

        public int? GAIT { get; set; }
        [MaxLength(60)]
        public string? GAITX { get; set; }

        public int? POSSTAB { get; set; }
        [MaxLength(60)]
        public string? POSSTABX { get; set; }

        public int? BRADYKIN { get; set; }
        [MaxLength(60)]
        public string? BRADYKIX { get; set; }

        public int? TOTALUPDRS { get; set; }

    }
}
