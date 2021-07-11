
$(document).ready(function () {
    let collapsors = $('.collapsor');
    collapsors.hide();

    let iterator = Object.values(collapsors).slice(0, collapsors.length);
    console.log(iterator)
    iterator.forEach(collapsor => {

        const [minW, minH] = [collapsor.getAttribute('min-width'), collapsor.getAttribute('min-height')];
        let targetId = collapsor.getAttribute('target');

        collapsor.inBoundary = false;
        let factory = predicateFactory({ collapsor, targetId });
        let data = { collapsor, targetId };
        console.log(factory);
        resizeHandler(factory, data);
       // resizeHandler(collapsor, targetId, minW);
      //  $(window).on('resize', { collapsor, minW, targetId }, (event) => resizeHandler(event.data.collapsor, event.data.targetId, event.data.minW));
        $(window).on('resize', { factory,data }, (event) => resizeHandler(event.data.factory, event.data.data));

        console.log(collapsor);
        $(collapsor).on("click", () => {
            $(targetId).toggle();
        })

    });

});

/*const resizeHandler = (collapsor, targetId, minW) => {
    console.log("resizing....");
    if (minW && window.innerWidth < minW) {

        if (!collapsor.inBoundary) {
            $(collapsor).show();
            $(targetId).hide();
            collapsor.inBoundary = true;
        }
    }
    else {
        $(collapsor).hide();
        $(targetId).show();
        collapsor.inBoundary = false;
    }
    console.log($(collapsor).parent().css('margin-left'));
}*/

function resizeHandler(predicate, data) {
    let collapsor = data.collapsor;
    let targetId = data.targetId;

    if (predicate()) {
        if (!collapsor.inBoundary) {
            $(collapsor).show();
            $(targetId).hide();
            collapsor.inBoundary = true;
        }
    }
    else {
        $(collapsor).hide();
        $(targetId).show();
        collapsor.inBoundary = false;
    }
}

function predicateFactory(data) {
    let collapsor = data.collapsor;
    let targetId = data.targetId;
    
    if (collapsor.getAttribute('margin-left')) {
        let minSize = parseFloat($(targetId).css('margin-left'));
        
        return (() => {
            console.log($(targetId).offset().left);
            let marginSize = $(targetId).outerWidth(true) - $(targetId).outerWidth();
            console.log("Left margin size " + marginSize);
            return marginSize < minSize;
        });
    }
    else if (collapsor.getAttribute('min-width')) {
        let minWidth = collapsor.getAttribute('min-width');
        return (() => window.innerWidth < minWidth);
    }
}