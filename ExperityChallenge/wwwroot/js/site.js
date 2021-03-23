// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#btn-reg").click(function () {
    // clear existing results
    $("#resultLoad").empty();

    // spinner
    $("#resultLoad").append('<div class="text-center"<div id="loadDataJds" class="spinner-border spinner-border-sm" role="status"<span class="sr-only">Loading...</span></div></div>');

    // call to controller
    $.ajax({
        type: "GET",
        url: "Event/register",
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (result) {
            console.log("Getting view")
            //  set partial view 
            $("#resultLoad").html(result);
        },
        error: function (err) {
            console.log(err.Message);
            $("#resultLoad").empty();
            alert("Register results failed to load");
        }
    });
});


$("#btn-diag").click(function () {
    // clear existing results
    $("#resultLoad").empty();

    // spinner
    $("#resultLoad").append('<div class="text-center"<div id="loadDataJds" class="spinner-border spinner-border-sm" role="status"<span class="sr-only">Loading...</span></div></div>');

    // call to controller
    $.ajax({
        type: "GET",
        url: "Event/diagnose",
        dataType: "html",
        success: function (result) {
            console.log("Getting view")
            //  set partial view 
            $("#resultLoad").html(result);
        },
        error: function (err) {
            console.log(err.Message);
            $("#resultLoad").empty();
            alert("Diagnose results failed to load");
        }
    });
});

$('#eventForm').submit(function (e) {

   
    // clear existing results
    $("#resultLoad").empty();

    var input = $('#eventInput').val()

    console.log(input);

    console.log($("#eventForm").serializeArray());

    // spinner
    $("#resultLoad").append('<div class="text-center"<div id="loadDataJds" class="spinner-border spinner-border-sm" role="status"<span class="sr-only">Loading...</span></div></div>');

    //$('#eventForm').submit();
    e.preventDefault();

    $.ajax({
        type: "POST",
        //contentType: "application/json; charset=utf-8",
        data: $("#eventForm").serialize(),
        url: 'Event/GetEventResult',
        dataType: 'html',
        success: function (data) {
            $('#resultLoad').html(data);
        },
        error: function (err) {
            console.log(err.Message);
            $("#resultLoad").empty();
            alert("Diagnose results failed to load");
        }
    });

/*    e.preventDefault();*/
});