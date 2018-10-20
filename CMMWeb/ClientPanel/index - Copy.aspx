<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="CMMWeb_ClientPanel_index" %>

<!DOCTYPE html>
<!--[if IE 8]> <html class="no-js lt-ie9" lang="en" > <![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js" lang="en">
<!--<![endif]-->
<head runat="server">
    <meta charset="utf-8" />
    <title>FLAIR | responsive bootstrap3 html5 template | themeforest | josweb</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <!--FONTS-->

    <link href='http://fonts.googleapis.com/css?family=Raleway:300,400,700' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Lato:400,700">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>    

    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!--CSS-->
    <style>
        .forh1 {
            font-size: 2em;
            text-align: center;
            color: #fff;
        }

        .forh3 {
            font-size: 1.2em;
            text-align: center;
            color: #fff;
        }
    </style>
    <link rel="stylesheet" href="../Default/assets2/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../Default/assets2/css/style.css" />
    <link rel="stylesheet" href="../Default/assets2/css/animate.css" />
    <link rel="stylesheet" href="../Default/assets2/css/font-awesome.min.css">
    <link href="../Default/assets2/css/owl.carousel.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="../Default/assets2/css/cubeportfolio.min.css">
    <!--[if lt IE 9]>
        <script src="http://html5shim.googlecode.com/svn/trunk/html5.js" type="text/javascript"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
    <script src="../Default/assets2/js/custom.modernizr.js"></script>

</head>

<body class="royal_loader">
    <form runat="server" id="form1">
    <!--HEADER-->
    <div id="header">
        <div class="col-sm-12 col-lg-12">
            <div class="row">
                <!--LOGO-->
                <div id="logo">
                    <a class="scroll" href="#home">
                        <img src="../Default/assets2/img/logo.png" alt="" /></a>
                </div>
                <!--//LOGO-->
                <!--MENU-->
                <ul id="menu">
                    <li><a class="scroll" href="#home">Home</a></li>
                    <li><a class="scroll" href="#about">Features</a></li>
                    <li><a class="scroll" href="#contact">Contact</a></li>
                    <li><asp:LinkButton runat="server" ID="btnLoginLink" OnClick="btnLogin_Click" class="scroll">Login</asp:LinkButton></li>
                </ul>
                <!--//MENU-->
                <!--RESPONSIVE TOGGLE-->
                <div id="nav-toggle">
                    <i class="fa fa-bars"></i>
                </div>
                <!--//RESPONSIVE TOGGLE-->
            </div>
        </div>
    </div>
    <!--//HEADER-->

    <section id="home" class="animation">
        <!--ANIMATED TEXT-->
        <div id="content">
            <div class="wow bounceInDown" data-wow-duration="3s" data-wow-delay="6s" align="center">
                <i class="fa fa-building-o fa-3x wow pulse" data-wow-iteration="infinite" style=" color:#E34834; "></i>
            </div>
            <div class="text-rotator-fade2 wow fadeIn" data-wow-duration="2s" data-wow-delay="6s">
                <span class="rotate" style="">Don't worry*For your*Construction site
                </span>
            </div>
            <h2 class="wow bounceInDown forh1" data-wow-duration="3s" data-wow-delay="4s">WE WILL TAKE CARE OF YOUR CONSTRUCTION MATERIALS
            </h2>

            <h3 class="wow bounceInDown forh3" data-wow-duration="3s" data-wow-delay="3s">Easily manage, control, and track construction materials right from your fingertips free.
            </h3>
            <br />
            <div class="wow bounceInDown forh1" data-wow-duration="3s" data-wow-delay="1s">
                <asp:LinkButton runat="server" ID="btnLogin" OnClick="btnLogin_Click">Start Journy</asp:LinkButton>
            </div>
            <div class="text-center pad30">
                <a href="#about" class="scroll">
                    <i class="fa fa-angle-double-down fa-inverse fa-4x wow rotateIn " data-wow-duration="1s" data-wow-delay="8s"></i>
                </a>
            </div>
        </div>
        <div id="animation-container"></div>
    </section>
    <!--//HOME SECTION ENDS-->
    
    <section id="big_clear"></section>

    <!--BIG IMAGE-->
    <section>
        <img src="../Default/assets2/img/clients/C5.jpg" id="big_image" />
    </section>
    <!--//BIG IMAGE ENDS-->
    <!--ABOUT SECTION STARTS-->
    <section id="about">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 col-lg-12">
                    <h1 class="wow fadeInRightBig" data-wow-offset="80" data-wow-duration="2s">What you can do!
                    </h1>

                    <div class="lead wow fadeInRightBig" data-wow-offset="80" data-wow-duration="2s">
                        Success is no accident. It is hard work, <strong>perseverance</strong>, learning, sacrifice and most of all,
                        <span class="colour"><strong>love</strong></span> of what you are doing or <span class="colour">learning</span> to do.
                    </div>

                    <!--SERVICE 1-->
                    <div class="col-sm-4 col-lg-4 text-center wow fadeIn" data-wow-offset="80" data-wow-duration="2s" data-wow-delay="1s">
                        <div class="service">
                            <i class="fa fa-shopping-bag"></i>
                        </div>
                        <br />
                        <p>
                            Constructor can maintain materials for more than one construction site and store the types
                            of materials which are supplied by Supplier.
                        </p>
                    </div>

                    <!--SERVICE 2-->
                    <div class="col-sm-4 col-lg-4 text-center wow fadeIn" data-wow-offset="80" data-wow-duration="2s" data-wow-delay="1.5s">
                        <div class="service">
                            <i class="fa fa-tasks"></i>
                        </div>
                        <br />
                        <p>
                            Constructor can search and check the details about which materials are supplied between two date and update the information. 
                        </p>
                    </div>

                    <!--SERVICE 3-->
                    <div class="col-sm-4 col-lg-4 text-center  wow fadeIn" data-wow-offset="80" data-wow-duration="2s" data-wow-delay="2s">
                        <div class="service">
                            <i class="fa fa-address-card"></i>
                        </div>
                        <br />
                        <p>
                            Constructor can generate the pdf which can be used as voucher and which contains all the relevant information of construction materials.
                        </p>
                    </div>                  
                </div>
            </div>
        </div>
    </section>
    <!--//ABOUT SECTION ENDS-->
    <!--WE LIKE TICKER-->
    <section id="ticker">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 col-lg-12">
                    <h1 class="like wow fadeInRightBig" data-wow-offset="80" data-wow-duration="2s">We like<br>
                        <span class="ticker"></span>
                    </h1>
                </div>
            </div>
        </div>
    </section>
    <!--//WE LIKE TICKER-->
    <!--CHARTS-->

    <!--//CHARTS-->
    <!--TEAM SECTION STARTS-->

    <!--//TEAM SECTION ENDS-->
    <!--MILESTONES-->

    <!--//MILESTONES-->
    <!--WORK SECTION STARTS-->

    <!--//WORK SECTION ENDS-->
    <!--PRICING SECTION STARTS-->

    <!--//SECTION ENDS-->
    <!--//MP4 VIDEO SECTION STARTS-->

    <!--//MP4 VIDEO SECTION ENDS-->
    <!--BLOG POSTS-->
    <!--//BLOG POSTS-->
    <!--CONTACT SECTION STARTS-->
    <section id="contact">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 col-lg-12 ">

                    <h1 class="wow fadeInRightBig" data-wow-offset="80" data-wow-duration="2s">Contact
                    </h1>

                    <div class="lead wow fadeInRightBig" data-wow-offset="80" data-wow-duration="2s">
                        Sometimes <strong>magic</strong> is just someone <strong>spending</strong> more time on something than anyone else might reasonably expect.
                    </div>

                    <div class="row">
                        <div class="col-sm-6 col-lg-6  wow fadeInUp" data-wow-offset="80" data-wow-duration="2s">

                            <h2>Do you need a website,<br>
                                have a question or comment?</h2>

                            <p>
                                Flair Design Studio,<br>
                                23 Mornington Crescent,<br>
                                Camden High Street,<br>
                                London NW1 7JE
                            </p>

                            <ul class="fa-ul">
                                <li><i class="fa-li fa fa-phone inverse"></i><span class="inverse">+44 020 2345 1987</span></li>
                                <li><i class="fa-li fa fa-envelope inverse"></i><a href="mailto:#">name@example.com</a></li>
                                <li><i class="fa-li fa fa-globe inverse"></i><a href="#">www.example.com</a></li>

                            </ul>

                            <ul class="social-icons">
                                <li class="wow fadeIn" data-wow-offset="80" data-wow-duration="2s">
                                    <a href="#"><i class="fa fa-twitter"></i></a>
                                </li>
                                <li class="wow fadeIn" data-wow-offset="80" data-wow-duration="2s" data-wow-delay="0.5s">
                                    <a href="#"><i class="fa fa-facebook"></i></a>
                                </li>
                                <li class="wow fadeIn" data-wow-offset="80" data-wow-duration="2s" data-wow-delay="1s">
                                    <a href="#"><i class="fa fa-github"></i></a>
                                </li>
                                <li class="wow fadeIn" data-wow-offset="80" data-wow-duration="2s" data-wow-delay="1.5s">
                                    <a href="#"><i class="fa fa-pinterest"></i></a>
                                </li>
                                <li class="wow fadeIn" data-wow-offset="80" data-wow-duration="2s" data-wow-delay="2s">
                                    <a href="#"><i class="fa fa-instagram"></i></a>
                                </li>
                                <li class="wow fadeIn" data-wow-offset="80" data-wow-duration="2s" data-wow-delay="2.5s">
                                    <a href="#"><i class="fa fa-dribbble"></i></a>
                                </li>
                            </ul>
                        </div>

                        <div class="col-sm-6 col-lg-6  wow fadeInUp" data-wow-offset="80" data-wow-duration="2s">
                            <div class="contact_
                                ">
                                <div id="note"></div>
                                <div id="fields">
                                    <div id="ajax-contact-form">
                                        <input class="col-xs-12 col-md-12" type="text" name="name" value="" placeholder="Name" />
                                        <input class="col-xs-12 col-md-12" type="text" name="email" value="" placeholder="Email" />
                                        <input class="col-xs-12 col-md-12" type="text" name="subject" value="" placeholder="Subject" />
                                        <textarea name="message" id="message" class="col-xs-12  col-md-12" placeholder="Message"></textarea>
                                        <div class="clear"></div>
                                        <input type="submit" class="btn marg-right10" value="submit" />
                                        <input type="reset" class="btn" value="reset" />

                                        <div class="clear"></div>
                                    </div>
                                </div>
                            </div>
                            <!-- // End FORM -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="pad60"></div>
    </section>
    <!--//END CONTACT SECTION-->
    <!--START FOOTER-->
    <footer>
        <!--Google Map-->

        <!-- // End Google Map -->

        <div class="center footer">
            <!-- UP TO TOP -->
            <div class="wow bounce" data-wow-offset="80" data-wow-duration="2s">
                <a href="#home" class=" scroll">
                    <span class="fa-stack fa-lg">
                        <i class="fa fa-circle fa-stack-2x "></i>
                        <i class="fa fa-angle-double-up fa-stack-1x fa-inverse"></i>
                    </span>
                </a>
            </div>

            <div id="copyright" class="wow bounceIn" data-wow-offset="80" data-wow-duration="2s">
                &copy; 2014 FLAIR DESIGN STUDIO
                <br>
                <a href="http://www.spiralpixel.com">Template by Spiral Pixel</a>
            </div>
        </div>
    </footer>
    <!--//END-->
    <!--SCRIPTS-->
    <script src="../Default/assets2/js/jquery.js"></script>
    <script src="../Default/assets2/js/retina.js"></script>
    <script src="../Default/assets2/js/bootstrap.min.js"></script>
    <script src="../Default/assets2/js/royal_preloader.min.js"></script>
    <script src="../Default/assets2/js/smooth-scroll.js"></script>
    <script src="../Default/assets2/js/jquery.appear.js"></script>
    <script src="../Default/assets2/js/parallax.js"></script>
    <script src="../Default/assets2/js/wow.js"></script>
    <script src="../Default/assets2/js/count.js"></script>
    <script src="../Default/assets2/js/charts.js"></script>
    <script src="../Default/assets2/js/jquery.cubeportfolio.min.js"></script>
    <script src="../Default/assets2/js/main.js"></script>
    <script src="../Default/assets2/js/owl.carousel.min.js"></script>
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false&amp;language=en"></script>
    <script src="../Default/assets2/js/gmap3.min.js" type="text/javascript"></script>
    <script src="../Default/assets2/js/scripts.js"></script>

    <script type="text/javascript" src="../Default/assets2/js/jquery.fs.wallpaper.js"></script>
    <script type="text/javascript">

	$(document).ready(function() {
	$(".wallpapered").wallpaper();
	});
    </script>
    <script src="../Default/assets2/js/owl.carousel.min.js"></script>
    <script type="text/javascript">

	$(document).ready(function() {
    		$("#clients").owlCarousel({
				autoPlay: 3000, //Set AutoPlay to 3 seconds
				items : 4,
				itemsDesktop : [1199,3],
				itemsDesktopSmall : [979,3]
			});
		});
    </script>
    <!--ANIMATED SCRIPT-->
    <script src="../Default/assets2/js/animated/fss.js"></script>
    <script>
		var container = document.getElementById('animation-container');
		var renderer = new FSS.CanvasRenderer();
		var scene = new FSS.Scene();
		var light = new FSS.Light('#333', '#646A7C');
		var geometry = new FSS.Plane(container.offsetWidth, container.offsetHeight, 16, 12);
		var material = new FSS.Material('#FFFFFF', '#FFFFFF');
		var mesh = new FSS.Mesh(geometry, material);
		var now, start = Date.now();
		function initialise() {
		  scene.add(mesh);
		  scene.add(light);
		  container.appendChild(renderer.element);
		  window.addEventListener('resize', resize);
		}
		function resize() {
		  renderer.setSize(container.offsetWidth, container.offsetHeight);
		}
		function animate() {
		  now = Date.now() - start;
		  light.setPosition(300*Math.sin(now*0.001), 200*Math.cos(now*0.0005), 60);
		  renderer.render(scene);
		  requestAnimationFrame(animate);
		}
		initialise();
		resize();
		animate();
    </script>

    <!--TEXT ROTATE-->
    <script src="../Default/assets2/js/text-rotate.js"></script>
    <script> 
        $(".rotate").show();
		$(".rotate").textrotator({
	      animation: "dissolve",
	      separator: "*",
	      speed: 2000
	    });

    </script>
   </form>
</body>
</html>
