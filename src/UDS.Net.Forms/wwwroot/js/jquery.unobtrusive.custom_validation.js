/*
* Custom client-side validation for custom data annotations using jQuery unobtrusive
* Read more here https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-7.0#custom-client-side-validation
* Another good blog post here https://bradwilson.typepad.com/blog/2010/10/mvc3-unobtrusive-validation.html
*/

/* Birth Month */
$.validator.addMethod('birthmonth', function (value, element, params) {
    var parameters = params[1];

    var allowUnknown = parameters.allowUnknown;

    if (allowUnknown == 'true' && value == 99) { // TODO after parsing as bool, update conditional
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
* params is an array of parameter names  you're expecting in the HTML attributes
* fn is a function which is called to adapt the HTML attribute values into jQuery Validate rules and messages
*/
$.validator.unobtrusive.adapters.add('birthmonth', ['maximum', 'minimum', 'allowunknown'], function (options) {
    var element = $(options.form).find('input[data-val-birthmonth]')[0];

    var minimum = parseInt(options.params['minimum']);
    var maximum = parseInt(options.params['maximum']);
    var allowUnknown = options.params['allowunknown']; // TODO parse bool

    console.log(allowUnknown);

    options.rules['birthmonth'] = [element, { allowUnknown: allowUnknown, maximum: maximum, minimum: minimum }];

    options.messages['birthmonth'] = options.message;
});

/* Birth Year */
$.validator.addMethod('birthyear', function (value, element, params) {
    var parameters = params[1];

    var minimum = parameters.minimum;
    var maximum = parameters.maximum;
    var allowUnknown = parameters.allowUnknown;

    if (allowUnknown == 'true' && value == 9999) { // TODO after parsing as bool, update conditional
        return true;
    }

    if (value >= minimum && value <= maximum) {
        return true;
    }
    return false;
});

$.validator.unobtrusive.adapters.add('birthyear', ['allowunknown', 'maximum', 'minimum'], function (options) {
    var element = $(options.form).find('input[data-val-birthyear]')[0];

    var minimum = parseInt(options.params['minimum']);
    var maximum = parseInt(options.params['maximum']);
    var allowUnknown = options.params['allowunknown']; // TODO parse bool

    options.rules['birthyear'] = [element, { allowUnknown: allowUnknown, maximum: maximum, minimum: minimum }]; // rules are required for the onChange event to trigger validation
    options.messages['birthyear'] = options.message;
});