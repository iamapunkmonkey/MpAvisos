<script type="text/javascript">
$(document).ready(function () {

	jQuery.support.cors = true;


        var ContactCreate = {
        	ContactID: 0,
                Phone: ''+$("#phone").val()+'',
        };

        $("#AddCustomer").click(function (event) {
            createCustomer(CreateContact(), null);
	    event.preventDefault();
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
            if ($.browser.msie && window.XDomainRequest) {
                // Use Microsoft XDR
                var xdr = new XDomainRequest();
        		if (xdr) {
                        xdr.onerror = function () {
                            alert('xdr onerror');
                        };
                        xdr.ontimeout = function () {
                            alert('xdr ontimeout');
                        };
                        xdr.onprogress = function () {
                            alert("XDR onprogress");
                            alert("Got: " + xdr.responseText);
                        };
                        xdr.onload = function() {
                            alert('onload' + xdr.responseText);
                            callback(xdr.responseText);
                        };
                        xdr.timeout = 5000;
                        xdr.open('post', "/proxy.php?proxy_url=www.miparqueaviso.apphb.com/api/avisos", true);                  
                        xdr.send("JSON.stringify(CustomerCreate)");
                } else {
                        alert('failed to create xdr');
                }
            }
   

            
            $.ajax({
                url: "http://miparqueaviso.apphb.com/api/avisos",
                data: JSON.stringify(CustomerCreate),
		        async: false,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                statusCode: {
                    201: function (newCustomer) {
                        alert("You will now recieve alerts. Thank you!");
                    },
                    400: function (newCustomer) {
                        alert("Thats not a phone number");
                    },
                    409: function (newCustomer) {
                        alert("We already have your number");
                    }
                }

            });
        }
 });
        
</script>