<script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function(){

        var ContactCreate = {
        	ContactID: 0,
                Phone: ''+$("#phone").val()+'',
        };

        console.log(JSON.stringify(ContactCreate));

        $("#AddCustomer").click(function () {
            createCustomer(CreateContact(), null);
            $("#phone").val("");
        });

        function CreateContact()
        {
        	var ContactCreate = {
        	    ContactID: 0,
                Phone: ''+$("#phone").val()+'',
        	};
        	return ContactCreate;
        }
        
        function createCustomer(CustomerCreate, callback) {
            $.ajax({
                url: "http://miparqueaviso.apphb.com/api/avisos",
                data: JSON.stringify(CustomerCreate),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                statusCode: {
                    201: function (newCustomer) {
                        alert("You will now recieve alerts. Thank you!");
                    },
                    400: function (newCustomer) {
                        alert("Thats not a phone number");
                    }
                }

            });
 
        }});
</script>
