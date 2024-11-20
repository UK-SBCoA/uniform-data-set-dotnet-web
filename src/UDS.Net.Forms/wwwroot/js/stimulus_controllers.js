import { Application } from "@hotwired/stimulus"
/* Import custom stimulus controllers */
import Dropdown from "./js_controllers/dropdown_controller.js"
import MobileMenu from "./js_controllers/mobilemenu_controller.js"
import FancyCheckboxes from "./js_controllers/fancycheckboxes_controller.js"
import CheckboxDisable from "./js_controllers/checkboxDisable_controller.js"
import selectendpoint_controller from "./js_controllers/selectendpoint_controller.js"
import StatusFilter from "./js_controllers/status_filter.js"

window.Stimulus = Application.start()

/* Register custom stimulus controllers*/
Stimulus.register("dropdown", Dropdown)
Stimulus.register("mobilemenu", MobileMenu)
Stimulus.register("fancycheckboxes", FancyCheckboxes)
Stimulus.register("checkboxDisable", CheckboxDisable)
Stimulus.register("selectendpoint", selectendpoint_controller)
Stimulus.register("statusFilter", StatusFilter)
