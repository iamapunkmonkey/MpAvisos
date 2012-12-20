
    $(document).ready(function () {
        $.ajax({

            type: "GET",
            url: "http://miparqueaviso.apphb.com/api/avisos",
            dataType: "json",
            success: function (datalist) {
                     handle_avisos(datalist);
            }
        });
    });


    function handle_avisos(datalist) {
        
        //clear avisos
        ClearAvisos();
        console.log(datalist);

        for (var i = 0; i < datalist.length; i++) {
            var data = datalist[i];
            var li = AddAvisoToAvisoList(data);
            $('#avisos').append(li);
        }

    }

    function AddAvisoToAvisoList(data) {
        var li = $('<li class="tweet"></li>');
        li.append('<span>Date: ' + data.Created + '</span></li>');
        li.append('<span>   Type: ' + data.Type + '</span></li>');
        li.append('<span>   ' + data.Text + '</span></li>');
        return li;
    }


    //Clearing
    function ClearAvisos() {
        $('.tweet').remove();
    }

