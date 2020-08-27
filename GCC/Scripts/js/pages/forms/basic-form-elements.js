$(function () {
    //Textare auto growth
    autosize($('textarea.auto-growth'));

    //Datetimepicker plugin
    $('.datetimepicker').bootstrapMaterialDatePicker({
        format: 'DD/MM/YYYY HH:mm',
        clearButton: true,
        'cancelText': 'Cancelar',
        'okText': 'OK',
        'clearText': 'Limpar',
        lang: 'pt',
        weekStart: 1
    });
    $('.datepicker').bootstrapMaterialDatePicker({
        format: 'DD/MM/YYYY',
        clearButton: true,
        'clearText': 'Limpar',
        'cancelText': 'Cancelar',
        weekStart: 1,
        lang: 'pt',
        time: false
    });
    $('.DataHora').bootstrapMaterialDatePicker({
        format: 'DD/MM/YYYY',
        clearButton: true,
        'clearText': 'Limpar',
        'cancelText': 'Cancelar',
        weekStart: 1,
        lang: 'pt',
        time: false
    });

    $('.timepicker').bootstrapMaterialDatePicker({
        format: 'HH:mm',
        lang: 'pt',
        clearButton: true,
        date: false
    });
    //$('.DataHora').bootstrapMaterialDatePicker({
    //    format: 'DD/MM/YYYY', 'cancelText': 'Cancelar',
    //    'okText': 'OK',
    //    clearButton: true,
    //    'clearText': 'Limpar',
    //    lang: 'pt', minDate: new Date()
    //});
});