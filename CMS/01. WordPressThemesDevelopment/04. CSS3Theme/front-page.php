<?php 
get_header();
		if(have_posts()) :
			while(have_posts()) :
				the_post();
?>
		<h2>
			<a href="<?php the_permalink() ?>" rel="bookmark" title="Permanent Link to <?php the_title_attribute(); ?>"><?php the_title(); ?></a>
		</h2>
		<div class="post-content"><?php the_content();?></div>
<?php
			endwhile;
		endif;
get_footer();
?>