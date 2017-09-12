(function ($) {
    $(function () {
        loadHelpers();

        $('.modal').modal();

        $('select').material_select();

        //$('.chips').material_chip({
        //    placeholder: 'add tags',
        //    secondaryPlaceholder: 'add tags',
        //});
    });
})(jQuery);