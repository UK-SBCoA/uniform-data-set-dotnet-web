import { Application } from "@hotwired/stimulus"

/* Naming conventions: https://stimulus.hotwired.dev/reference/controllers#naming-conventions */
/* Import custom stimulus controllers */
import Autocomplete from "./js_controllers/autocomplete_controller.js"
import B4 from "./js_controllers/b4_controller.js"
import B6 from "./js_controllers/b6_controller.js"
import CheckboxDisable from "./js_controllers/checkbox_disable_controller.js"
import CheckboxSelectAll from "./js_controllers/checkbox_select_all_controller.js"
import Dropdown from "./js_controllers/dropdown_controller.js"
import FancyCheckboxes from "./js_controllers/fancy_checkboxes_controller.js"
import FormFooterDropdownReset from "./js_controllers/form_footer_dropdown_reset_controller.js"
import MobileMenu from "./js_controllers/mobile_menu_controller.js"
import RxNormDisplayNames from "./js_controllers/rx_norm_display_names_controller.js"
import SelectEndpoint from "./js_controllers/select_endpoint_controller.js"

window.Stimulus = Application.start()

/* Register custom stimulus controllers*/
Stimulus.register("autocomplete", Autocomplete)
Stimulus.register("b4", B4)
Stimulus.register("b6", B6)
Stimulus.register("checkbox-disable", CheckboxDisable)
Stimulus.register("checkbox-select-all", CheckboxSelectAll)
Stimulus.register("dropdown", Dropdown)
Stimulus.register("fancy-checkboxes", FancyCheckboxes)
Stimulus.register("form-footer-dropdown-reset", FormFooterDropdownReset)
Stimulus.register("mobile-menu", MobileMenu)
Stimulus.register("rx-norm-display-names", RxNormDisplayNames)
Stimulus.register("select-endpoint", SelectEndpoint)
