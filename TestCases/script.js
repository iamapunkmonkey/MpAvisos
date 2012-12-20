
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
        var li = $('<li class="aviso"></li>');
        li.append('<div class="toprow"><span class="icon">   Type: ' + data.Type + '</span><span class="date">Date: ' + data.Created + '</span><span>   ' + data.Text + '</span></div>');
        return li;
    }


    //Clearing
    function ClearAvisos() {
        $('.tweet').remove();
    }

