 <?php
/*
Template Name: Mi-Aviso
*/
?>
 <!doctype html>
<html>
<head>
	<meta http-equiv="content-type" content="text/html;charset=UTF-8" />
	<meta name="viewport"content="width=device-width,minimum-scale=1.0, maximum-scale=1.0"/>
	<link rel="stylesheet"
	href="<?php bloginfo("stylesheet_url")?>" 
	type="text/css"  />
	<link rel="apple-touch-icon" href="images/apple-touch-icon.png" />
	<!--[if lt IE 9]>
	   <script>
	      document.createElement('header');
	      document.createElement('nav');
	      document.createElement('section');
	      document.createElement('article');
	      document.createElement('footer');
	      document.createElement('phone');
	      document.createElement('adress');
	   </script>
	<![endif]-->
	<?php wp_head(); ?>
	
<script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript" >


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

</script>


</head>


<body>

<?php get_header();?>


<section>

	<?php if(have_posts()) : while(have_posts()) :the_post();?>

	<h1 class="title-text txt-brown font-museo"><?php the_title()?></h1>

	<article class="time txt-brown bg-lightbrown bot-rad">

		<?php the_content(); ?>

	</article>
	<?php endwhile; endif; ?>

</section>



<?php get_footer();?>
<?php wp_footer(); ?>
</body>
</html>