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
import a4 from "./js_controllers/a4_controller.js"
import modal from "./js_controllers/modal_controller.js"
import checkboxButton from "./js_controllers/checkboxButton_controller.js"
import pageRefreshOnSubmit from "./js_controllers/pageRefreshOnSubmit_controller.js"
import A3EnableRows from "./js_controllers/a3_enable_rows_controller.js"
import A3EnableIntraRow from "./js_controllers/a3_enable_intra_row_controller.js"

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
Stimulus.register("a4", a4)
Stimulus.register("a3-enable-rows", A3EnableRows)
Stimulus.register("a3-enable-intra-row", A3EnableIntraRow)
Stimulus.register("modal", modal)
Stimulus.register("checkboxButton", checkboxButton)
Stimulus.register("pageRefreshOnSubmit", pageRefreshOnSubmit)