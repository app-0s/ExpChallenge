// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Form submit 
$('#eventForm').submit(function (e) {

   
    // clear div
    $("#resultLoad").empty();

    // spinner
    $("#resultLoad").append('<div class="text-center"><div id="loadData" class="spinner-border spinner-border-sm" role="status"><span class="sr-only">Loading...</span></div></div>');

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