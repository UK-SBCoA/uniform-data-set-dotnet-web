﻿$(document).ready(function () {
    var endFormInputs = [
        "D1a.DEMENTED",
        "D1a.MCICRITCLN",
        "D1a.MCICRITIMP",
        "D1a.MCICRITFUN",
        "D1a.MCI",
        "D1a.IMPNOMCIFU",
        "D1a.IMPNOMCICG",
        "D1a.IMPNOMCLCD",
        "D1a.IMPNOMCIO",
        "D1a.IMPNOMCI",
        "D1a.CDOMMEM",
        "D1a.CDOMLANG",
        "D1a.CDOMATTN",
        "D1a.CDOMEXEC",
        "D1a.CDOMVISU",
        "D1a.CDOMBEH",
        "D1a.CDOMAPRAX",
        "D1a.MBI",
        "D1a.BDOMMOT",
        "D1a.BDOMAFREG",
        "D1a.BDOMIMP",
        "D1a.BDOMSOCIAL",
        "D1a.BDOMTHTS",
        "D1a.PREDOMSYN",
        "D1a.AMNDEM",
        "D1a.DYEXECSYN",
        "D1a.PCA",
        "D1a.PPASYN",
        "D1a.FTDSYN",
        "D1a.LBDSYN",
        "D1a.NAMNDEM",
        "D1a.PSPSYN",
        "D1a.CTESYN",
        "D1a.CBSSYN",
        "D1a.MSASYN",
        "D1a.OTHSYN",
        "D1a.SYNINFCLIN",
        "D1a.SYNINFCTST",
        "D1a.SYNINFBIOM",
        "D1a.MAJDEPDX",
        "D1a.OTHDEPDX",
        "D1a.BIPOLDX",
        "D1a.SCHIZOP",
        "D1a.ANXIET",
        "D1a.GENANX",
        "D1a.PANICDISDX",
        "D1a.OCDDX",
        "D1a.PTSDDX",
        "D1a.NDEVDIS",
        "D1a.DELIR",
        "D1a.OTHPSY",
        "D1a.TBIDX",
        "D1a.EPILEP",
        "D1a.HYCEPH",
        "D1a.NEOP",
        "D1a.NEOPSTAT",
        "D1a.HIV",
        "D1a.POSTC19",
        "D1a.APNEADX",
        "D1a.OTHCOGILL",
        "D1a.ALCDEM",
        "D1a.IMPSUB",
        "D1a.MEDS",
        "D1a.COGOTH",
        "D1a.COGOTH2",
        "D1a.COGOTH3"
    ];

    function toggleInputs(disable) {
        endFormInputs.forEach(function (inputName) {
            $(`input[name="${inputName}"]`).prop("disabled", disable);
        });
    }

    $("input[name='D1a.SCDDXCONF'], input[name='D1a.SCD']").change(function () {
        var scddxconfValue = $("input[name='D1a.SCDDXCONF']").val();
        var scdValue = $("input[name='D1a.SCD']").val();
        var shouldDisable = (scddxconfValue == "0" || scddxconfValue == "1" || scdValue == "0");
        toggleInputs(shouldDisable);
    });

});
