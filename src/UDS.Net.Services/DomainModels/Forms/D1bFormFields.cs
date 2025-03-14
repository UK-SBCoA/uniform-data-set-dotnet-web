using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class D1bFormFields : IFormFields
    {
        public int? BIOMARKDX { get; set; }
        public int? FLUIDBIOM { get; set; }
        public int? BLOODAD { get; set; }
        public int? BLOODFTLD { get; set; }
        public int? BLOODLBD { get; set; }
        public int? BLOODOTH { get; set; }
        public string BLOODOTHX { get; set; }
        public int? CSFAD { get; set; }
        public int? CSFFTLD { get; set; }
        public int? CSFLBD { get; set; }
        public int? CSFOTH { get; set; }
        public string CSFOTHX { get; set; }
        public int? IMAGINGDX { get; set; }
        public int? PETDX { get; set; }
        public int? AMYLPET { get; set; }
        public int? TAUPET { get; set; }
        public int? FDGPETDX { get; set; }
        public int? FDGAD { get; set; }
        public int? FDGFTLD { get; set; }
        public int? FDGLBD { get; set; }
        public int? FDGOTH { get; set; }
        public string FDGOTHX { get; set; }
        public int? DATSCANDX { get; set; }
        public int? TRACOTHDX { get; set; }
        public string TRACOTHDXX { get; set; }
        public int? TRACERAD { get; set; }
        public int? TRACERFTLD { get; set; }
        public int? TRACERLBD { get; set; }
        public int? TRACEROTH { get; set; }
        public string TRACEROTHX { get; set; }
        public int? STRUCTDX { get; set; }
        public int? STRUCTAD { get; set; }
        public int? STRUCTFTLD { get; set; }
        public int? STRUCTCVD { get; set; }
        public int? IMAGLINF { get; set; }
        public int? IMAGLAC { get; set; }
        public int? IMAGMACH { get; set; }
        public int? IMAGMICH { get; set; }
        public int? IMAGWMH { get; set; }
        public int? IMAGWMHSEV { get; set; }
        public int? OTHBIOM1 { get; set; }
        public string OTHBIOMX1 { get; set; }
        public int? BIOMAD1 { get; set; }
        public int? BIOMFTLD1 { get; set; }
        public int? BIOMLBD1 { get; set; }
        public int? BIOMOTH1 { get; set; }
        public string BIOMOTHX1 { get; set; }
        public int? OTHBIOM2 { get; set; }
        public string OTHBIOMX2 { get; set; }
        public int? BIOMAD2 { get; set; }
        public int? BIOMFTLD2 { get; set; }
        public int? BIOMLBD2 { get; set; }
        public int? BIOMOTH2 { get; set; }
        public string BIOMOTHX2 { get; set; }
        public int? OTHBIOM3 { get; set; }
        public string OTHBIOMX3 { get; set; }
        public int? BIOMAD3 { get; set; }
        public int? BIOMFTLD3 { get; set; }
        public int? BIOMLBD3 { get; set; }
        public int? BIOMOTH3 { get; set; }
        public string BIOMOTHX3 { get; set; }
        public int? AUTDOMMUT { get; set; }
        public bool? ALZDIS { get; set; }
        public int? ALZDISIF { get; set; }
        public bool? LBDIS { get; set; }
        public int? LBDIF { get; set; }
        public bool? FTLD { get; set; }
        public bool? PSP { get; set; }
        public int? PSPIF { get; set; }
        public bool? CORT { get; set; }
        public int? CORTIF { get; set; }
        public bool? FTLDMO { get; set; }
        public int? FTLDMOIF { get; set; }
        public bool? FTLDNOS { get; set; }
        public int? FTLDNOIF { get; set; }
        public int? FTLDSUBT { get; set; }
        public string FTLDSUBX { get; set; }
        public bool? CVD { get; set; }
        public int? CVDIF { get; set; }
        public bool? MSA { get; set; }
        public int? MSAIF { get; set; }
        public bool? CTE { get; set; }
        public int? CTEIF { get; set; }
        public int? CTECERT { get; set; }
        public bool? DOWNS { get; set; }
        public int? DOWNSIF { get; set; }
        public bool? HUNT { get; set; }
        public int? HUNTIF { get; set; }
        public bool? PRION { get; set; }
        public int? PRIONIF { get; set; }
        public bool? CAA { get; set; }
        public int? CAAIF { get; set; }
        public bool? LATE { get; set; }
        public int? LATEIF { get; set; }
        public bool? OTHCOG { get; set; }
        public int? OTHCOGIF { get; set; }
        public string OTHCOGX { get; set; }

        public IEnumerable<FormMode> FormModes
        {
            get
            {
                return new List<FormMode>() { FormMode.InPerson, FormMode.Remote };
            }
        }

        public IEnumerable<NotIncludedReasonCode> NotIncludedReasonCodes
        {
            get
            {
                return new List<NotIncludedReasonCode>();
            }
        }

        public IEnumerable<RemoteModality> RemoteModalities
        {
            get
            {
                return new List<RemoteModality>() { RemoteModality.Telephone, RemoteModality.Video };
            }
        }

        public string GetDescription()
        {
            return "Biomarker and Etiological Diagnosis";
        }

        public string GetVersion()
        {
            return "4";
        }

        public D1bFormFields() { }
        public D1bFormFields(FormDto dto) : this()
        {
            if (dto is D1bDto)
            {
                var d1bDto = ((D1bDto)dto);
                BIOMARKDX = d1bDto.BIOMARKDX;
                FLUIDBIOM = d1bDto.FLUIDBIOM;
                BLOODAD = d1bDto.BLOODAD;
                BLOODFTLD = d1bDto.BLOODFTLD;
                BLOODLBD = d1bDto.BLOODLBD;
                BLOODOTH = d1bDto.BLOODOTH;
                BLOODOTHX = d1bDto.BLOODOTHX;
                CSFAD = d1bDto.CSFAD;
                CSFFTLD = d1bDto.CSFFTLD;
                CSFLBD = d1bDto.CSFLBD;
                CSFOTH = d1bDto.CSFOTH;
                CSFOTHX = d1bDto.CSFOTHX;
                IMAGINGDX = d1bDto.IMAGINGDX;
                PETDX = d1bDto.PETDX;
                AMYLPET = d1bDto.AMYLPET;
                TAUPET = d1bDto.TAUPET;
                FDGPETDX = d1bDto.FDGPETDX;
                FDGAD = d1bDto.FDGAD;
                FDGFTLD = d1bDto.FDGFTLD;
                FDGLBD = d1bDto.FDGLBD;
                FDGOTH = d1bDto.FDGOTH;
                FDGOTHX = d1bDto.FDGOTHX;
                DATSCANDX = d1bDto.DATSCANDX;
                TRACOTHDX = d1bDto.TRACOTHDX;
                TRACOTHDXX = d1bDto.TRACOTHDXX;
                TRACERAD = d1bDto.TRACERAD;
                TRACERFTLD = d1bDto.TRACERFTLD;
                TRACERLBD = d1bDto.TRACERLBD;
                TRACEROTH = d1bDto.TRACEROTH;
                TRACEROTHX = d1bDto.TRACEROTHX;
                STRUCTDX = d1bDto.STRUCTDX;
                STRUCTAD = d1bDto.STRUCTAD;
                STRUCTFTLD = d1bDto.STRUCTFTLD;
                STRUCTCVD = d1bDto.STRUCTCVD;
                IMAGLINF = d1bDto.IMAGLINF;
                IMAGLAC = d1bDto.IMAGLAC;
                IMAGMACH = d1bDto.IMAGMACH;
                IMAGMICH = d1bDto.IMAGMICH;
                IMAGWMH = d1bDto.IMAGWMH;
                IMAGWMHSEV = d1bDto.IMAGWMHSEV;
                OTHBIOM1 = d1bDto.OTHBIOM1;
                OTHBIOMX1 = d1bDto.OTHBIOMX1;
                BIOMAD1 = d1bDto.BIOMAD1;
                BIOMFTLD1 = d1bDto.BIOMFTLD1;
                BIOMLBD1 = d1bDto.BIOMLBD1;
                BIOMOTH1 = d1bDto.BIOMOTH1;
                BIOMOTHX1 = d1bDto.BIOMOTHX1;
                OTHBIOM2 = d1bDto.OTHBIOM2;
                OTHBIOMX2 = d1bDto.OTHBIOMX2;
                BIOMAD2 = d1bDto.BIOMAD2;
                BIOMFTLD2 = d1bDto.BIOMFTLD2;
                BIOMLBD2 = d1bDto.BIOMLBD2;
                BIOMOTH2 = d1bDto.BIOMOTH2;
                BIOMOTHX2 = d1bDto.BIOMOTHX2;
                OTHBIOM3 = d1bDto.OTHBIOM3;
                OTHBIOMX3 = d1bDto.OTHBIOMX3;
                BIOMAD3 = d1bDto.BIOMAD3;
                BIOMFTLD3 = d1bDto.BIOMFTLD3;
                BIOMLBD3 = d1bDto.BIOMLBD3;
                BIOMOTH3 = d1bDto.BIOMOTH3;
                BIOMOTHX3 = d1bDto.BIOMOTHX3;
                AUTDOMMUT = d1bDto.AUTDOMMUT;
                ALZDIS = d1bDto.ALZDIS;
                ALZDISIF = d1bDto.ALZDISIF;
                LBDIS = d1bDto.LBDIS;
                LBDIF = d1bDto.LBDIF;
                FTLD = d1bDto.FTLD;
                PSP = d1bDto.PSP;
                PSPIF = d1bDto.PSPIF;
                CORT = d1bDto.CORT;
                CORTIF = d1bDto.CORTIF;
                FTLDMO = d1bDto.FTLDMO;
                FTLDMOIF = d1bDto.FTLDMOIF;
                FTLDNOS = d1bDto.FTLDNOS;
                FTLDNOIF = d1bDto.FTLDNOIF;
                FTLDSUBT = d1bDto.FTLDSUBT;
                FTLDSUBX = d1bDto.FTLDSUBX;
                CVD = d1bDto.CVD;
                CVDIF = d1bDto.CVDIF;
                MSA = d1bDto.MSA;
                MSAIF = d1bDto.MSAIF;
                CTE = d1bDto.CTE;
                CTEIF = d1bDto.CTEIF;
                DOWNS = d1bDto.DOWNS;
                DOWNSIF = d1bDto.DOWNSIF;
                HUNT = d1bDto.HUNT;
                HUNTIF = d1bDto.HUNTIF;
                PRION = d1bDto.PRION;
                PRIONIF = d1bDto.PRIONIF;
                CAA = d1bDto.CAA;
                CAAIF = d1bDto.CAAIF;
                LATE = d1bDto.LATE;
                LATEIF = d1bDto.LATEIF;
                OTHCOG = d1bDto.OTHCOG;
                OTHCOGIF = d1bDto.OTHCOGIF;
                OTHCOGX = d1bDto.OTHCOGX;

            }
        }
    }
}

