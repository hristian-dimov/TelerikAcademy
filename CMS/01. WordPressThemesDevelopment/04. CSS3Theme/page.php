<?php 
get_header(); 
				if(have_posts()) : 
					while(have_posts()) :
						the_post(); 
?>
				<h2><?php the_title(); ?></h2>
				<div><?php the_content(); ?></div>
<?php 
					endwhile;
				endif;

get_template_part('content', 'page');
comments_template('', true);
get_footer(); 
?>