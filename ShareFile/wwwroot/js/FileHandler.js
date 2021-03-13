var FileHandler = (function () {

    function Init() {
        $("#file-add-form").hide();
        HideAndShowAddFileForm();
        SendFileToSave();
    }

    function HideAndShowAddFileForm() {
        $("#add-file-button").click(function () {
            $("#file-add-form").toggle("slow");
            $("#show-add-file").toggle();
            $("#hide-add-file").toggle();
            

        })
    }

    function SendFileToSave() {
        $("#submit-button").click(function () {
            var fileName = $("#file-name-input").val();
            var fileSize = $("#file-size-input").val();

            var sharedFileViewModel = {
                FileName: fileName, FileSize: fileSize
            };
            $.ajax({
                type: "POST",
                url: '/Share/AddFile',
                data: JSON.stringify(sharedFileViewModel),
                contentType: 'application/json; charset=utf-8',
                success: function () {
                    location.reload();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Something went wrong while saving the file.")
                }
            });
        });
    }

    return {
        Init: function () {
            Init();
        },
    };
})();