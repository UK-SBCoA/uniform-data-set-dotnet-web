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
/* UI behavior affects on input fields */
function setAffect(target, attribute, value) {
  let element = $('[name="' + target + '"]');
  if (element !== 'undefined') {
    if (attribute === 'disabled') {
      if (value === 'true' || value === true) {
        element.attr('disabled', 'disabled');
        element.attr('value', '');
        // TODO check the element type to decide how to set value to null
        element.removeAttr('checked');
      }
      else {
        element.removeAttr('disabled');
      }
    }
  }
}
function setAffects(targets) {
  $.each(targets, function (index, behavior) {
    $.each(behavior, function (target, affects) {
      // console.log(target);
      $.each(affects, function (attribute, value) {
        // console.log(attribute + " to " + value);
        setAffect(target, attribute, value);
      });
    });
  });
}
function toggleAffects(targets, isSelected) {
  $.each(targets, function (index, target) {
    // console.log(target + " disabled to " + !isSelected);
    setAffect(target, 'disabled', !isSelected);
  });
}

$(function () {
  let affects = $('[data-affects]');
  if (affects.length) {
    // for each input with data-affects check to see if it is selected or is a checkbox that should toggle
    affects.each(function () {
      // set initial status
      if ($(this).data('affects-targets')) {
        // radio button groups
        let isSelected = $(this).is(':checked');
        if (isSelected) {
          let targets = $(this).data('affects-targets');
          setAffects(targets);
        }
      }
      else if ($(this).data('affects-toggle-targets')) {
        // checkboxes
        let isSelected = $(this).is(':checked');
        let toggleTargets = $(this).data('affects-toggle-targets');
        toggleAffects(toggleTargets, isSelected);
      }

      // watch for changes
      $(this).on('change', function () {
        if ($(this).data('affects-targets')) {
          let targets = $(this).data('affects-targets');
          setAffects(targets);
        }
        else if ($(this).data('affects-toggle-targets')) {
          let isSelected = $(this).is(':checked');
          let toggleTargets = $(this).data('affects-toggle-targets');
          toggleAffects(toggleTargets, isSelected);
        }
      });
    });

    // after checking each input, check to see if some should have a default state
    let allNames = affects.map(function () {
      let name = $(this).attr('name');
      return name;
    });

    let uniqueNames = jQuery.unique(allNames);
    uniqueNames.each(function () {
      let element = $('input[name="' + this + '"]');
      if (element.is(':checked')) {
        // console.log(element.attr('name') + " checked");
      }
      else {
        let toggleTargets = element.data('affects-targets');
        $.each(toggleTargets, function (index, behavior) {
          $.each(behavior, function (target, affects) {
            setAffect(target, 'disabled', true);
          });
        });
      }
    });
  }
});

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Status */
function setValidationStatus(statusValue, statusText) {
  // get the current form
  let form = $('#UDSForm');

  // get validator object
  let validator = form.validate();
  let settings = validator.settings;

  if (statusValue === '2') { // TODO don't hardcode status value
    // figure out which fields needs to be required
    // enable client-side validation
    settings.ignore = '';
  }
  else {
    // get errors that were created using jQuery.validate.unobtrusive
    // and remove messages
    let errors = form.find('.field-validation-error span');
    errors.each(function () { validator.settings.success($(this)); });

    // clear summary
    let summary = form.find('.validation-summary-errors ul');
    summary.empty();

    // clear errors from validation
    validator.resetForm();

    // disable client-side validation
    settings.ignore = '*';
  }
}

$(function () {
  let select = $('select[data-val-status]');
  if (select.length) {
    let optionSelected = select.find(':selected');
    if (optionSelected.length) {
      setValidationStatus(optionSelected.val(), optionSelected.text());
    }
  }
});

$('select[data-val-status]').on('change', function () {
  let optionSelected = $('select[data-val-status]').find(':selected');
  if (optionSelected.length) {
    setValidationStatus(optionSelected.val(), optionSelected.text());
  }
});

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Birth Month */
$.validator.addMethod('birthmonth', function (value, element, params) {
  let parameters = params[1];

  let allowUnknown = parameters.allowUnknown;

  if (allowUnknown === 'true' && value === '99') { // TODO after parsing as bool, update conditional
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
$.validator.unobtrusive.adapters.add('birthmonth', ['maximum', 'minimum', 'allowunknown'],
  function (options) {
    let element = $(options.form).find('input[data-val-birthmonth]')[0];

    let minimum = parseInt(options.params.minimum);
    let maximum = parseInt(options.params.maximum);
    let allowUnknown = options.params.allowunknown; // TODO parse bool

    console.log(allowUnknown);

    options.rules.birthmonth = [element, { allowUnknown, maximum, minimum }];

    options.messages.birthmonth = options.message;
  });

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Birth Year */
$.validator.addMethod('birthyear',
  function (value, element, params) {
    let parameters = params[1];

    let minimum = parameters.minimum;
    let maximum = parameters.maximum;
    let allowUnknown = parameters.allowUnknown;

    if (allowUnknown === 'true' && value === '9999') { // TODO after parsing as bool, update conditional
      return true;
    }

    if (value >= minimum && value <= maximum) {
      return true;
    }
    return false;
  });

$.validator.unobtrusive.adapters.add('birthyear', ['allowunknown', 'maximum', 'minimum'],
  function (options) {
    let element = $(options.form).find('input[data-val-birthyear]')[0];

    let minimum = parseInt(options.params.minimum);
    let maximum = parseInt(options.params.maximum);
    let allowUnknown = options.params.allowunknown; // TODO parse bool

    options.rules.birthyear = [element, { allowUnknown, maximum, minimum }]; // rules are required for the onChange event to trigger validation
    options.messages.birthyear = options.message;
  });

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Diagnosis */
$.validator.addMethod('diagnosis', function (value, element, params) {
  console.log(element);
  let codes = [40, 41, 42, 43, 44, 45, 50, 70, 80, 100, 110, 120, 130, 131, 132, 133, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 310, 320, 400, 410, 420, 421, 430, 431, 432, 433, 434, 435, 436, 439, 440, 450, 490, 999];
  if (codes.includes(value)) {
    return true;
  }
  return false;
});

$.validator.unobtrusive.adapters.add('diagnosis', [], function (options) {
  options.messages.diagnosis = options.message;
});

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Special Characters */

$.validator.addMethod('specialcharacter', function (value, element, params) {
  if (value.includes("'") || value.includes('"') || value.includes('&') || value.includes('%')) {
    return false;
  }
  return true;
});

$.validator.unobtrusive.adapters.add('specialcharacter', [], function (options) {
  options.rules.specialcharacter = true;
  options.messages.specialcharacter = options.message;
});
