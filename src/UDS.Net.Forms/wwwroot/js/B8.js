$(document).ready(function () {
    $('input[type=radio][name="B8.NORMNREXAM"]').change(function () {
        const value = $(this).val();
        $('input[type=radio]').each(function () {
            if (!$(this).attr('name').includes('B8.NEUREXAM')) {
                if (value == '0') {
                    $('input[type=radio][name="' + $(this).attr('name') + '"][value="0"]').prop('checked', true);
                } else if (value == '1') {
                    $('input[type=radio][name="' + $(this).attr('name') + '"][value="0"]').prop('checked', false);
                }
            }
        });
    });

    $('input[type=radio][name="B8.PARKSIGN"]').change(function () {
        const value = $(this).val();
        const targetNames = [
            'B8.SLOWINGFM', 'B8.TREMREST', 'B8.TREMPOST', 'B8.TREMKINE',
            'B8.RIGIDARM', 'B8.RIGIDLEG', 'B8.DYSTARM', 'B8.DYSTLEG',
            'B8.CHOREA', 'B8.AMPMOTOR', 'B8.AXIALRIG', 'B8.POSTINST',
            'B8.MASKING', 'B8.STOOPED'
        ];

        targetNames.forEach(function (name) {
            if (value == '0' || value == '8') {
                $(`input[type=radio][name="${name}"][value="${value}"]`).prop('checked', true);
            } else if (value == '1') {
                $(`input[type=radio][name="${name}"][value="0"]`).prop('checked', false);
                $(`input[type=radio][name="${name}"][value="8"]`).prop('checked', false);
            }
        });
    });

    $('input[type=radio][name="B8.OTHERSIGN"]').change(function () {
        const value = $(this).val();
        const targetNames = [
            'B8.LIMBAPRAX', 'B8.UMNDIST', 'B8.LMNDIST', 'B8.VFIELDCUT',
            'B8.LIMBATAX', 'B8.MYOCLON', 'B8.UNISOMATO', 'B8.APHASIA',
            'B8.ALIENLIMB', 'B8.HSPATNEG', 'B8.PSPOAGNO', 'B8.SMTAGNO',
            'B8.OPTICATAX', 'B8.APRAXGAZE', 'B8.VHGAZEPAL', 'B8.DYSARTH',
            'B8.APRAXSP'
        ];

        targetNames.forEach(function (name) {
            if (value == '0' || value == '8') {
                $(`input[type=radio][name="${name}"][value="${value}"]`).prop('checked', true);
            } else if (value == '1') {
                $(`input[type=radio][name="${name}"][value="0"]`).prop('checked', false);
                $(`input[type=radio][name="${name}"][value="8"]`).prop('checked', false);
            }
        });
    });

});
