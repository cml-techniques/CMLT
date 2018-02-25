hs.graphicsDir = '/Scripts/highslide/graphics/';
hs.align = 'center';
hs.transitions = ['expand', 'crossfade'];
hs.outlineType = 'rounded-white';
hs.fadeInOut = true;
hs.creditsText = 'Copyright TopWeb';
hs.creditsHref = 'http://www.topweb.vn';
hs.dimmingOpacity = 0.75;

// Add the controlbar
hs.addSlideshow({
    interval: 5000,
    repeat: false,
    useControls: true,
    fixedControls: 'fit',
    overlayOptions: {
        opacity: 0.75,
        position: 'bottom center',
        hideOnMouseOut: true
    }
});