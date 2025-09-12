/* eslint-env jquery */
/* eslint semi: ["error", "always", { "omitLastInOneLineBlock": false}] */
/* eslint brace-style: ["error", "stroustrup", { "allowSingleLine": true }] */
/* eslint prefer-const: "off" */
/* eslint space-before-function-paren: "off" */
/* eslint unicode-bom: "off" */
/*
 * Custom client-side validation for custom data annotations using jQuery unobtrusive
 * Read more here https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-7.0#custom-client-side-validation
 * Another good blog post here https://bradwilson.typepad.com/blog/2010/10/mvc3-unobtrusive-validation.html
 */




/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
/* UI behavior affects on input fields (supports numerical input, radio button, checkbox) */
function setAffect(target, attribute, value) {
    let element = $(`[name="${target}"]`);
    if (element.length) {
        if (attribute === "disabled") {
            if (value === "true" || value === true) {
                element.attr("disabled", "disabled");
                // Clear values
                if (element.is(":radio") || element.is(":checkbox")) {
                    element.prop("checked", false);
                }
                else {
                    element.val("");
                }
            }
            else {
                element.removeAttr("disabled");
            }
        }
    }
}
function setAffects(targets) {
    $.each(targets, function (index, behavior) {
        $.each(behavior, function (target, affects) {
            $.each(affects, function (attribute, value) {
                setAffect(target, attribute, value);
            });
        });
    });
}
function toggleAffects(targets, isSelected) {
    $.each(targets, function (index, target) {
        // console.log(target + " disabled to " + !isSelected);
        setAffect(target, "disabled", !isSelected);
    });
}
function compareRange(low, high, targets, value) {
    if (value === "") {
        $.each(targets, function (index, behavior) {
            $.each(behavior, function (target, affects) {
                setAffect(target, "disabled", true);
            });
        });
    }
    else {
        if (value >= low && value <= high) {
            $.each(targets, function (index, behavior) {
                $.each(behavior, function (target, affects) {
                    setAffect(target, "disabled", false);
                });
            });
        }
        else {
            $.each(targets, function (index, behavior) {
                $.each(behavior, function (target, affects) {
                    setAffect(target, "disabled", true);
                });
            });
        }
    }
}

function debounce(func, wait) {
    let timeout;
    return function () {
        const context = this, args = arguments;
        clearTimeout(timeout);
        timeout = setTimeout(() => func.apply(context, args), wait);
    };
}

$(function () {

    let affects = $("[data-affects]");

    // initialize the form, check to see if some should have a default state
    // text inputs with ranges defaults are set with compareRange()
    let allNames = affects.map(function () {
        let name = $(this).attr("name");
        return name;
    });

    let uniqueNames = jQuery.unique(allNames);

    uniqueNames.each(function () {
        let element = $(`input[name="${this}"]`);

        if (element.is(":radio")) {
            if (element.is(":checked")) {
                // console.log(element.attr('name') + " checked");
            }
            else {
                let toggleTargets = element.data("affects-targets");
                $.each(toggleTargets, function (index, behavior) {
                    $.each(behavior, function (target, affects) {
                        // don't use setAffect() for initialization because it clears the value
                        let element = $(`[name="${target}"]`);
                        element.attr("disabled", "disabled");
                    });
                });
            }
        }
    });


    if (affects.length) {
        // for each input with data-affects check to see if it is selected or is a checkbox that should toggle
        affects.each(function () {
            // set initial status
            if ($(this).data("affects-targets")) {
                if ($(this).is(":radio")) {
                    // radio button groups
                    let isSelected = $(this).is(":checked");
                    if (isSelected) {
                        let targets = $(this).data("affects-targets");
                        setAffects(targets);
                    }
                }
            }
            else if ($(this).data("affects-toggle-targets")) {
                // checkboxes
                let isSelected = $(this).is(":checked");
                let toggleTargets = $(this).data("affects-toggle-targets");
                toggleAffects(toggleTargets, isSelected);
            }
            else if ($(this).data("affects-range-targets")) {
                // text or number inputs
                let low = $(this).data("affects-range-low");
                let high = $(this).data("affects-range-high");
                let targets = $(this).data("affects-range-targets");

                compareRange(low, high, targets, $(this).val());
            }

            // watch for changes
            $(this).on("change", function () {
                if ($(this).data("affects-targets")) {
                    let targets = $(this).data("affects-targets");
                    setAffects(targets);
                }
                else if ($(this).data("affects-toggle-targets")) {
                    let isSelected = $(this).is(":checked");
                    let toggleTargets = $(this).data("affects-toggle-targets");
                    toggleAffects(toggleTargets, isSelected);
                }
            });

            // if it's a range input, add a debounced input handler
            if ($(this).data("affects-range-targets")) {
                let low = $(this).data("affects-range-low");
                let high = $(this).data("affects-range-high");
                let targets = $(this).data("affects-range-targets");

                $(this).on("input", debounce(function () {
                    compareRange(low, high, targets, $(this).val());
                }, 300));
            }
        });
    }
});

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Save Status and Form Mode */
function setValidationStatus(statusValue, modeValue) {
    // get the current form
    let form = $("#UDSForm");

    // get validator object
    let validator = form.validate();
    let settings = validator.settings;

    var formStatusFinalizedValue = $(
        "input[name=\"Enum.FormStatus.Finalized\"]"
    ).val();
    var formModeNotCompletedValue = $(
        "input[name=\"Enum.FormMode.NotCompleted\"]"
    ).val();

    if (
        statusValue === formStatusFinalizedValue &&
        modeValue != formModeNotCompletedValue
    ) {
        // figure out which fields needs to be required
        // enable client-side validation
        settings.ignore = "";
    }
    else {
        // get errors that were created using jQuery.validate.unobtrusive
        // and remove messages
        let errors = form.find(".field-validation-error span");
        errors.each(function () {
            validator.settings.success($(this));
        });

        // clear summary
        let summary = form.find(".validation-summary-errors ul");
        summary.empty();

        // clear errors from validation
        validator.resetForm();

        // disable client-side validation
        settings.ignore = "*";
    }
}

/* Initialize state of validation */
$(function () {
    let mode = $("select[name$='MODE']");
    let select = $("select[data-val-status]");
    if (mode.length && select.length) {
        let modeOptionSelected = mode.find(":selected");
        let optionSelected = select.find(":selected");
        if (optionSelected.length) {
            setValidationStatus(optionSelected.val(), modeOptionSelected.val());
        }
    }
});

/* If save-status changes */
$("select[data-val-status]").on("change", function () {
    let mode = $("select[name$='MODE']");
    let select = $("select[data-val-status]");
    if (mode.length && select.length) {
        let modeOptionSelected = mode.find(":selected");
        let optionSelected = select.find(":selected");
        if (optionSelected.length) {
            setValidationStatus(optionSelected.val(), modeOptionSelected.val());
        }
    }
});

/* If form mode changes */
$("select[name$='MODE']").on("change", function () {
    let mode = $("select[name$='MODE']");
    let select = $("select[data-val-status]");
    if (mode.length && select.length) {
        let modeOptionSelected = mode.find(":selected");
        let optionSelected = select.find(":selected");
        if (optionSelected.length) {
            setValidationStatus(optionSelected.val(), modeOptionSelected.val());
        }
    }
});

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Birth Month */
$.validator.addMethod("birthmonth", function (value, element, params) {
    let parameters = params[1];

    let allowUnknown = parameters.allowUnknown;

    if (allowUnknown === "true" && value === "99") {
        // TODO after parsing as bool, update conditional
        return true;
    }

    if (value >= 1 && value <= 12) {
        return true;
    }

    return false;
});

/*
 * jQuery.validator.unobtrusive.adapters.add(adapterName, [params], fn);
 * adapterName is the name of the adapter, and matches the name of the rule in the HTML element
 * params is an array of parameter names you're expecting in the HTML attributes
 * fn is a function which is called to adapt the HTML attribute values into jQuery Validate rules and messages
 */
$.validator.unobtrusive.adapters.add(
    "birthmonth",
    ["maximum", "minimum", "allowunknown"],
    function (options) {
        let element = $(options.form).find("input[data-val-birthmonth]")[0];

        let minimum = parseInt(options.params.minimum);
        let maximum = parseInt(options.params.maximum);
        let allowUnknown = options.params.allowunknown; // TODO parse bool

        options.rules.birthmonth = [element, { allowUnknown, maximum, minimum }];

        options.messages.birthmonth = options.message;
    },
);

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Birth Year */
$.validator.addMethod("birthyear", function (value, element, params) {
    let parameters = params[1];

    let minimum = parameters.minimum;
    let maximum = parameters.maximum;
    let parentmaximum = parameters.parentmaximum;
    let parent = parameters.parent;
    let allowUnknown = parameters.allowUnknown;

    if (allowUnknown === "true" && value === "9999") {
        // TODO after parsing as bool, update conditional
        return true;
    }
    if (parent === "true" && value >= minimum && value <= parentmaximum) {
        return true;
    }
    if (parent === "false" && value >= minimum && value <= maximum) {
        return true;
    }
    return false;
});

$.validator.unobtrusive.adapters.add(
    "birthyear",
    ["allowunknown", "parent", "maximum", "minimum", "parentmaximum"],
    function (options) {
        let element = $(options.form).find("input[data-val-birthyear]")[0];

        let minimum = parseInt(options.params.minimum);
        let maximum = parseInt(options.params.maximum);
        let parentmaximum = parseInt(options.params.parentmaximum);
        let parent = options.params.parent;
        let allowUnknown = options.params.allowunknown; // TODO parse bool

        options.rules.birthyear = [element, { allowUnknown, parent, maximum, minimum, parentmaximum }]; // rules are required for the onChange event to trigger validation
        options.messages.birthyear = options.message;
    },
);

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Diagnosis */
$.validator.addMethod("diagnosis", function (value, element, params) {
    let codes = [
        40, 41, 42, 43, 44, 45, 50, 70, 80, 100, 110, 120, 130, 131, 132, 133, 140,
        150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 310,
        320, 400, 410, 420, 421, 430, 431, 432, 433, 434, 435, 436, 439, 440, 450,
        490, 999,
    ];
    if (codes.includes(value)) {
        return true;
    }
    return false;
});

$.validator.unobtrusive.adapters.add("diagnosis", [], function (options) {
    options.messages.diagnosis = options.message;
});

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Prohibited Characters */

$.validator.addMethod(
    "prohibitedcharacters",
    function (value, element, params) {
        if (
            value.includes("'") ||
            value.includes("\"") ||
            value.includes("&") ||
            value.includes("%")
        ) {
            return false;
        }
        return true;
    },
);

$.validator.unobtrusive.adapters.add(
    "prohibitedcharacters",
    [],
    function (options) {
        options.rules.prohibitedcharacters = true;
        options.messages.prohibitedcharacters = options.message;
    },
);

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
/* RequiredIf */
$.validator.addMethod("requiredif", function (value, element, params) {
    let parameters = params[1];
    let watchedFieldName = parameters.watchedfield;
    let watched = $("input[name=\"" + watchedFieldName + "\"]:checked");
    //get validation message from element
    let elementValidationMessage = $(element).data("valRequiredif");

    if (watched.length) {
        let selected = watched.val();
        let watchedFieldIsRequiredValue = parameters.watchedfieldvalue;

        //checkbox values are lower case while watchedfieldisrequired are pascal case
        if (watched.attr("type") == "checkbox") {
            watchedFieldIsRequiredValue = watchedFieldIsRequiredValue.toLowerCase();
        }

        if (selected == watchedFieldIsRequiredValue) {
            if (!value) {
                return false;
            }
        }
    }

    RemoveValidationMessages(element.name, elementValidationMessage);
    return true;
});

$.validator.unobtrusive.adapters.add(
    "requiredif",
    ["watchedfield", "watchedfieldvalue"],
    function (options) {
        let watchedFieldName = options.params.watchedfield;
        let watchedFieldIsRequiredValue = options.params.watchedfieldvalue;
        let watched = $("input[name=\"" + watchedFieldName + "\"]");
        if (watched.length) {
            watched.on("change", function () {
                //Search for both radio and input field watched element type, there can only be one at a time
                let watchedRadioValue = $(`input[type="radio"][name="${watchedFieldName}"]:checked`).val();

                if (watchedRadioValue != watchedFieldIsRequiredValue) {

                    let elementValidationMessage = $(options.element).data("valRequiredif");
                    RemoveValidationMessages(options.element.name, elementValidationMessage);
                }
            });
        }
        options.rules.requiredif = [options.element, options.params]; // rules are required for the onChange event to trigger validation
        options.messages.requiredif = options.message;
    },
);

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
/* RequiredIfRange */
$.validator.addMethod("requiredifrange", function (value, element, params) {
    let parameters = params[1];
    let watchedFieldName = parameters.watchedfield;

    //detect if current element is a radio or input field 
    let radioElementValue = $(`input[type="radio"][name="${element.name}"]:checked`).val();
    let inputElementValue = $(`input[type="number"][name="${element.name}"]`).val();
    let textElementValue = $(`input[type="text"][name="${element.name}"]`).val();

    //set element value depending on if current element is radio or input field
    let elementValue = radioElementValue || inputElementValue || textElementValue;

    //get validation message from element
    let elementValidationMessage = $(element).data("valRequiredifrange");

    //Search for both radio and input field watched element type, there can only be one at a time
    let watchedRadioValue = $("input[type='radio'][name=\"" + watchedFieldName + "\"]:checked").val();
    let watchedInputValue = $("input[type='number'][name=\"" + watchedFieldName + "\"]").val();

    if (watchedRadioValue || watchedInputValue) {
        let watchedValue = watchedRadioValue || watchedInputValue;

        //parse as float to handle floating and integer values
        watchedValue = parseInt(watchedValue);
        parameters.lowvalue = parseInt(parameters.lowvalue);
        parameters.highvalue = parseInt(parameters.highvalue);

        if (watchedValue >= parameters.lowvalue && watchedValue <= parameters.highvalue) {
            if (!elementValue) {
                return false;
            }
        }
    }

    RemoveValidationMessages(element.name, elementValidationMessage);
    return true;
});

$.validator.unobtrusive.adapters.add(
    "requiredifrange",
    ["watchedfield", "lowvalue", "highvalue"],
    function (options) {
        let watchedFieldName = options.params.watchedfield;
        let watched = $("input[name=\"" + watchedFieldName + "\"]");
        if (watched.length) {
            watched.on("change", function () {

                //Search for both radio and input field watched element type, there can only be one at a time
                let watchedRadioValue = $(`input[type="radio"][name="${watchedFieldName}"]:checked`).val();
                let watchedInputValue = $(`input[type="number"][name="${watchedFieldName}"]`).val();

                if (watchedRadioValue || watchedInputValue) {

                    //set watched value depending on which type of watched field is found
                    let watchedValue = watchedRadioValue || watchedInputValue;

                    //Radio group validation
                    if (watchedValue < options.params.lowvalue || watchedValue > options.params.highvalue) {
                        let elementValidationMessage = $(options.element).data("valRequiredifrange");

                        RemoveValidationMessages(options.element.name, elementValidationMessage);
                    }
                }
            });
        }

        options.rules.requiredifrange = [options.element, options.params]; // rules are required for the onChange event to trigger validation
        options.messages.requiredifrange = options.message;
    },
);


/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
/* RequiredIfRegex */
$.validator.addMethod("requiredifregex", function (value, element, params) {
    let parameters = params[1];
    let watchedFieldName = parameters.watchedfield;
    let watchedRadioValue = $("input[type='radio'][name=\"" + watchedFieldName + "\"]:checked").val();
    let watchedInputValue = $("input[type='number'][name=\"" + watchedFieldName + "\"]").val();

    //detect if current element is a radio or input field
    let radioElementValue = $(`input[type="radio"][name="${element.name}"]:checked`).val();
    let inputElementValue = $(`input[type="number"][name="${element.name}"]`).val();
    let textElementValue = $(`input[type="text"][name="${element.name}"]`).val();

    //get validation message from element
    let elementValidationMessage = $(element).data("valRequiredifregex");

    if (watchedRadioValue || watchedInputValue) {
        if (parameters.regex) {
            let watchedValue = watchedRadioValue || watchedInputValue;

            if (watchedValue) {
                let watchedRegex = new RegExp(parameters.regex.toString());
                let watchedRegexMatched = watchedValue.match(watchedRegex);

                //if watchedregex matches watchedvalue then a value is required
                //regex match() will return null if no match found
                if (watchedRegexMatched != null) {
                    let elementValue = radioElementValue || inputElementValue || textElementValue;

                    if (!elementValue) {
                        return false;
                    }
                }
            }
        }
    }

    RemoveValidationMessages(element.name, elementValidationMessage);
    return true;
});

$.validator.unobtrusive.adapters.add(
    "requiredifregex",
    ["watchedfield", "regex"],
    function (options) {
        let watchedFieldName = options.params.watchedfield;
        let watched = $("input[name=\"" + watchedFieldName + "\"]");

        if (watched.length) {
            watched.on("change", function () {
                //Search for input field watched element
                let watchedInputValue = $(`input[type="number"][name="${watchedFieldName}"]`).val();
                let watchedRadioValue = $(`input[type="radio"][name="${watchedFieldName}"]:checked`).val();
                let watchedTextValue = $(`input[type="text"][name="${watchedFieldName}"]`).val();

                let watchedValue = watchedInputValue || watchedRadioValue || watchedTextValue;

                if (watchedValue) {
                    let watchedRegex = new RegExp(options.params.regex.toString());
                    let watchedRegexMatched = watchedValue.match(watchedRegex);

                    //If watched value does not match the watched value regex to require a value, clear error messages
                    if (watchedRegexMatched == null) {
                        let elementValidationMessage = $(options.element).data("valRequiredifregex");

                        RemoveValidationMessages(options.element.name, elementValidationMessage);
                    }
                }
            });
        }

        options.rules.requiredifregex = [options.element, options.params]; // rules are required for the onChange event to trigger validation
        options.messages.requiredifregex = options.message;
    },
);

function RemoveValidationMessages(elementName, validationMessage) {
    $(`input[name='${elementName}']`).removeClass("input-validation-error");
    $(`span[data-valmsg-for="${elementName}"]`).empty();
    $(`.validation-summary-errors li:contains(${validationMessage})`).first().empty();
}