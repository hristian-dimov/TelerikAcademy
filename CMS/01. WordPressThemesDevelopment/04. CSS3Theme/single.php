<?php get_header(); ?>
				<div id="primary">
					<div id="content" role="main">
<?php 
				if(have_posts()) : 
					while(have_posts()) :
						the_post(); 
?>
				<!-- Adding Post title and content -->
				<h2><?php the_title();?></h2>
				<div><?php the_content();?></div>
				<!-- Adding Comments Template -->
				<?php comments_template( '', true ); ?>

<?php 
					endwhile;
				endif;
?>
					</div><!-- #content -->
				</div><!-- #primary -->
<?php get_footer(); ?>