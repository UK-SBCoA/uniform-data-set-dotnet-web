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
  //console.log(target);
  //console.log(attribute + " to " + value);
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
        let element = $(`[name="${target}"]`);

        if (element.length) {
            setAffect(target, "disabled", !isSelected);

            if (!isSelected) {
                if (element.is(":checkbox") || element.is(":radio")) {
                    element.prop("checked", false);
                } else {
                    element.val("");
                }

                let childTargets = element.data("affectsToggleTargets");
                if (childTargets) {
                    toggleAffects(childTargets, false);
                }
            }
        }
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
  if (watched.length) {
    let selected = watched.val();
    let watchedFieldIsRequiredValue = parameters.watchedfieldvalue;
    if (selected === watchedFieldIsRequiredValue) {
      if (value === "") {
        return false;
      }
    }
  }

  return true;
});

$.validator.unobtrusive.adapters.add(
  "requiredif",
  ["watchedfield", "watchedfieldvalue"],
  function (options) {
    let watchedFieldName = options.params.watchedfield;
    let watched = $("input[name=\"" + watchedFieldName + "\"]");
    if (watched.length) {
      watched.on("change", function () {
        // clear the validation if the watched field is changed
        let element = $(options.element);
        if (element.length) {
          // reset css
          element.removeClass("input-validation-error");
          element.addClass(
            "block w-full max-w-lg rounded-md border-gray-400 shadow-sm focus:border-indigo-500 focus:ring-indigo-500 sm:max-w-xs sm:text-sm placeholder:text-gray-400 disabled:bg-slate-50 disabled:text-slate-500 disabled:border-slate-200 disabled:shadow-none",
          );
          // reset error messages
          let validator = $("#UDSForm").validate();
          validator.form();
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

  let watched = $("input[name=\"" + watchedFieldName + "\"]");
  if (watched.length) {
    let watchedValue = watched.val();
    if (watchedValue.length) {
      let watchedInt = parseInt(watchedValue);
      let lowInt = parseInt(parameters.lowvalue);
      let highInt = parseInt(parameters.highvalue);

      if (watchedInt >= lowInt && watchedInt <= highInt) {
        // if within range field is required
        if (value === "") {
          return false;
        }
      }
    }
  }

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
        // clear the validation if the watched field is changed to outside the range
        let watchedValue = watched.val();
        if (watchedValue.length) {
          let watchedInt = parseInt(watchedValue);
          let lowInt = parseInt(options.params.lowvalue);
          let highInt = parseInt(options.params.highvalue);
          if (watchedInt <= lowInt || watchedInt >= highInt) {
            // outside the range, reset everything

            let element = $(options.element);
            if (element.length) {
              // reset css
              element.removeClass("input-validation-error");
              element.addClass(
                "block w-full max-w-lg rounded-md border-gray-400 shadow-sm focus:border-indigo-500 focus:ring-indigo-500 sm:max-w-xs sm:text-sm placeholder:text-gray-400 disabled:bg-slate-50 disabled:text-slate-500 disabled:border-slate-200 disabled:shadow-none",
              );
              // reset error messages
              let validator = $("#UDSForm").validate();
              validator.form();
            }
          }
        }
      });
    }
    options.rules.requiredifrange = [options.element, options.params]; // rules are required for the onChange event to trigger validation
    options.messages.requiredifrange = options.message;
  },
);