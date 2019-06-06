import * as styles from './matTooltip.scss';


export const matTooltipRefKey = '$matBlazor.matTooltipRef';
export const matTooltipTargetRefKey = '$matBlazor.matTooltipTargetRef';


export var TooltipPosition =
  {
    top: 'Top',
    right: 'Right',
    left: 'Left',
    bottom: 'Bottom'
  };


class MatTooltip {
  tooltip;
  target;
  ref;
  targetRef;


  constructor(ref, targetRef, targetId, options) {
    // console.log(arguments);

    if (targetId) {

      targetRef = document.getElementById(targetId);
    }
    // debugger;
    this.ref = ref;
    this.targetRef = targetRef;


    this.options = options || {};
    ref[matTooltipRefKey] = this;
    targetRef[matTooltipTargetRefKey] = this;


    targetRef.addEventListener('mouseover', () => {
      this.show();
    });
    targetRef.addEventListener('mouseout', () => {
      this.hide();
    });
    // window.addEventListener('resize', Tooltip.show);
  }


  calculatePos(position) {
    var xy = {};
    // console.log(this.targetRef);
    // console.log(this.ref);

    switch (position) {
      case TooltipPosition.top: {
        xy.x = this.targetRef.offsetLeft + (this.targetRef.offsetWidth / 2) - (this.ref.offsetWidth / 2);
        xy.y = this.targetRef.offsetTop - this.ref.offsetHeight - 10;
        break;
      }

      case TooltipPosition.bottom: {
        xy.x = this.targetRef.offsetLeft + (this.targetRef.offsetWidth / 2) - (this.ref.offsetWidth / 2);
        xy.y = this.targetRef.offsetTop + this.targetRef.offsetHeight + 10;
        break;
      }

      case TooltipPosition.right: {
        xy.x = this.targetRef.offsetLeft + this.targetRef.offsetWidth + 10;
        xy.y = this.targetRef.offsetTop + (this.targetRef.offsetHeight / 2) - (this.ref.offsetHeight / 2);
        break;
      }

      case TooltipPosition.left: {
        xy.x = this.targetRef.offsetLeft - (this.ref.offsetWidth) - 10;
        xy.y = this.targetRef.offsetTop + (this.targetRef.offsetHeight / 2) - (this.ref.offsetHeight / 2);
        break;
      }
    }
    return xy;

  }


  show() {
    // if (window.innerWidth < this.ref.offsetWidth * 1.5) {
    //   this.ref.style.maxWidth = (window.innerWidth / 2) + 'px';
    // } else {
    //   this.ref.style.maxWidth = 320 + 'px';
    // }


    var position = this.options.position || TooltipPosition.bottom;
    var xy = this.calculatePos(position);


    this.ref.classList.remove(TooltipPosition.top);
    this.ref.classList.remove(TooltipPosition.bottom);
    this.ref.classList.remove(TooltipPosition.left);
    this.ref.classList.remove(TooltipPosition.right);
    this.ref.classList.add(position);


    this.ref.style.left = xy.x + 'px';
    this.ref.style.top = xy.y + 'px';
    // console.log(xy);

    this.ref.classList.add('show');
  }


  hide() {
    // console.log('hide');
    this.ref.classList.remove('show');
  }
}

export function init(ref, targetRef, targetId, options) {
  new MatTooltip(ref, targetRef, targetId, options);
}





