<!DOCTYPE HTML>
<html>
<head>
	<title><?php wp_title(); ?></title>
	<meta name="description" content="website description" />
	<meta name="keywords" content="website keywords, website keywords" />
	<meta charset="<?php bloginfo('charset'); ?>" />
	<link rel="stylesheet" type="text/css" href="<?php bloginfo('stylesheet_url'); ?>" />
	<!-- modernizr enables HTML5 elements and feature detects -->
	<script type="text/javascript" src="<?php echo get_template_directory_uri(); ?>/js/modernizr-1.5.min.js"></script>
	<?php wp_head(); ?>
</head>
<body <?php body_class(); ?>>
	<div id="main">
		<header>
			<div id="logo">
				<div id="logo_text">
					<!-- class="logo_colour", allows you to change the colour of the text -->
					<h1><a href="index.html">CCS3<span class="logo_colour">_four</span></a></h1>
					<h2>Simple. Contemporary. Website Template.</h2>
				</div>
			</div>
			<nav>
				<?php wp_nav_menu(array(
					'theme_location' => 'top-site-menu',
					'container' => 'div',
					'container_id' => 'menu_container',
					'menu_class' => 'sf-menu',
					'menu_id' => 'nav',
					)); 
				?>
			</nav>
		</header>
		<div id="site_content">
			<?php get_sidebar('right-sidebar'); ?>
			<div id="content">