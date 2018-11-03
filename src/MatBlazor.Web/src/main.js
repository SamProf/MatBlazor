// global css
import './theme/theme.scss';
import * as matButton from './matButton/matButton';
import * as matCheckbox from './matCheckbox/matCheckbox';
import * as matTextField from './matTextField/matTextField';
import * as matRadioButton from './matRadioButton/matRadioButton';
import * as matSelect from './matSelect/matSelect';
import * as matSlider from './matSlider/matSlider';
import * as matSlideToggle from './matSlideToggle/matSlideToggle';
import * as matCard from './matCard/matCard';
import * as matChipSet from './matChipSet/matChipSet';
import * as matAppBar from './matAppBar/matAppBar';


window.matBlazor = {
  matButton,
  matCheckbox,
  matTextField,
  matRadioButton,
  matSelect,
  matSlider,
  matSlideToggle,
  matCard,
  matChipSet,
  matAppBar,

  matMenu: {
    init: function (mdcMenu) {
      try {
        var menu = new window.mdc.menu.MDCMenu(mdcMenu);
        menu.hoistMenuToBody();
        mdcMenu.matBlazorRef = menu;
      } catch (e) {
        debugger;
        throw e;
      }
    },
    open: function (mdcMenu, anchorElement) {
      debugger;
      var menu = mdcMenu.matBlazorRef;
      menu.setAnchorElement(anchorElement);
      menu.open = true;
    }
  }
};


