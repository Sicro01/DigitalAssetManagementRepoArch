// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#deletePhaseStrategyModal').on('show.bs.modal',
    function (event) {
        // Extract values from trigger button
        var button = $(event.relatedTarget); // Button that triggered the modal
        var psname = button.data('phasestrategy').name; //Extract Name
        var psid = button.data('phasestrategy').id; //Extract Id
        var psobject = button.data('phasestrategy').objecttype; //Extract object type

        // Insert data into Modal elements
        var modal = $(this);
        $('#deleteTitle').text('Confirm deletion of ' + psobject + ': ' + psname);
        $('#warningMessage').text('Warning: All associated Phase Strategies will also be deleted.');

        // Save values to be used in #Delete confirmation function
        $('#labelpsid').text(psid);
        $('#labelpsobject').text(psobject);
    });

$('#Delete').click(function (e) {
    var deletepsid = $('#labelpsid').text();
    var deletobject = $('#labelpsobject').text();

    if (deletobject === "phase") {
        var url = 'PhaseStrategy/DeletePhase/' + deletepsid;
        console.log(url);
        $.post(url,
            function (response) {
                window.location.href = response.url;
            });
    } else {
        var url = 'PhaseStrategy/DeleteStrategy/' + deletepsid;
        $.post(url,
            function (response) {
                window.location.href = response.url;
            });
    }
});
