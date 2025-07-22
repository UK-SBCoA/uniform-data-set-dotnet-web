import { Application } from "@hotwired/stimulus"
/* Import custom stimulus controllers */
import Dropdown from "./js_controllers/dropdown_controller.js"
import MobileMenu from "./js_controllers/mobilemenu_controller.js"
import FancyCheckboxes from "./js_controllers/fancycheckboxes_controller.js"
import CheckboxDisable from "./js_controllers/checkboxDisable_controller.js"
import selectendpoint_controller from "./js_controllers/selectendpoint_controller.js"
import checkboxSelectAll from "./js_controllers/checkboxSelectAll_controller.js"
import rxNormDisplayNames from "./js_controllers/rxNormDisplayNames_controller.js"
import autocomplete from "./js_controllers/autocomplete_controller.js"
import b4 from "./js_controllers/b4_controller.js"
import b6 from "./js_controllers/b6_controller.js"
import dropdownReset from "./js_controllers/dropdownReset_controller.js"
import FormlessSubmit from "./js_controllers/formlessSubmit_controller.js"

window.Stimulus = Application.start()

/* Register custom stimulus controllers*/
Stimulus.register("dropdown", Dropdown)
Stimulus.register("mobilemenu", MobileMenu)
Stimulus.register("fancycheckboxes", FancyCheckboxes)
Stimulus.register("checkboxDisable", CheckboxDisable)
Stimulus.register("selectendpoint", selectendpoint_controller)
Stimulus.register("checkboxSelectAll", checkboxSelectAll)
Stimulus.register("rxNormDisplayNames", rxNormDisplayNames)
Stimulus.register("autocomplete", autocomplete)
Stimulus.register("b4", b4)
Stimulus.register("b6", b6)
Stimulus.register("dropdownReset", dropdownReset)
Stimulus.register("formlessSubmit", FormlessSubmit)
