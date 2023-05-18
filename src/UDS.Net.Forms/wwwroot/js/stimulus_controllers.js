import { Application } from "@hotwired/stimulus"
/* Import custom stimulus controllers */
import Dropdown from "./js_controllers/dropdown_controller.js"
import MobileMenu from "./js_controllers/mobilemenu_controller.js"

window.Stimulus = Application.start()

/* Register custom stimulus controllers*/
Stimulus.register("dropdown", Dropdown)
Stimulus.register("mobilemenu", MobileMenu)