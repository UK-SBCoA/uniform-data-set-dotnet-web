import { Application } from "https://unpkg.com/@hotwired/stimulus@3.2.2/dist/stimulus.js"

/* Import custom stimulus controllers */
import Dropdown from "./js_controllers/dropdown_controller.js"
import MobileMenu from "./js_controllers/mobilemenu_controller.js"
import FancyCheckboxes from "./js_controllers/fancycheckboxes_controller.js"
import CheckboxDisable from "./js_controllers/checkboxDisable_controller.js"
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
import c2 from "./js_controllers/c2_controller.js"

const application = Application.start()

/* Register custom stimulus controllers*/
application.register("dropdown", Dropdown)
application.register("mobilemenu", MobileMenu)
application.register("fancycheckboxes", FancyCheckboxes)
application.register("checkboxDisable", CheckboxDisable)
application.register("checkboxSelectAll", checkboxSelectAll)
application.register("rxNormDisplayNames", rxNormDisplayNames)
application.register("autocomplete", autocomplete)
application.register("b4", b4)
application.register("b6", b6)
application.register("dropdownReset", dropdownReset)
application.register("formlessSubmit", FormlessSubmit)
application.register("a4", a4)
application.register("modal", modal)
application.register("checkboxButton", checkboxButton)
application.register("pageRefreshOnSubmit", pageRefreshOnSubmit)
application.register("a3-enable-rows", A3EnableRows)
application.register("a3-enable-intra-row", A3EnableIntraRow)
application.register("c2", c2)
