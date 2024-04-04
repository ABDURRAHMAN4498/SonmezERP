// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
$(document).ready(function () {
    $('select').selectize({
        sortField: 'text'
    });
});
// Write your JavaScript code.

$(document).ready(fanction(){
    $('search_select_boxselect').selectpicker();
})


$(".js-example-placeholder-single").select2({
    placeholder: "Select a state",
    allowClear: true
});