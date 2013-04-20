<?php
/**
 * Template Name: Blog Template
 */
get_header();
			$blog_query = new WP_Query('author=1');
				if($blog_query->have_posts()) : 
					while($blog_query->have_posts()) :
						$blog_query->the_post(); 
			?>
				<h1><?php the_title(); ?></h1>
				<div><?php the_content(); ?></div>
			<?php
					endwhile;
				endif;
				wp_reset_query();
			?>
<?php get_footer(); ?>