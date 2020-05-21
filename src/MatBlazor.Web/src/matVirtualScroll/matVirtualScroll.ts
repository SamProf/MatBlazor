export function getScrollView(ref) {
    return {scrollTop: ref.scrollTop, clientHeight: ref.clientHeight};
}


export function init(ref, cmp) {
    ref.addEventListener("scroll",
        (e) => {
//                console.log(e);
            cmp.invokeMethodAsync("VirtualScrollingSetView", getScrollView(ref))
                .then(_ => {
//                        console.log(_);
                });

        });

    window.addEventListener("resize",
        (e) => {
//                console.log(e);


            cmp.invokeMethodAsync("VirtualScrollingSetView", getScrollView(ref))
                .then(_ => {
//                        console.log(_);
                });

        });
    return getScrollView(ref);

}


