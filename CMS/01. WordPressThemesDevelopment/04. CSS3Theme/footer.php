			</div>
		</div>
		<div id="scroll">
			<a title="Scroll to the top" class="top" href="#"><img src="<?php echo get_template_directory_uri(); ?>/images/top.png" alt="top" /></a>
		</div>
		<footer>
			<p><a href="index.html">Home</a> | <a href="examples.html">Examples</a> | <a href="page.html">A Page</a> | <a href="another_page.html">Another Page</a> | <a href="contact.php">Contact Us</a></p>
			<p>Copyright &copy; CSS3_four | <a href="http://www.css3templates.co.uk">design from css3templates.co.uk</a></p>
		</footer>
	</div>
	<!-- javascript at the bottom for fast page loading -->
	<script type="text/javascript" src="<?php echo get_template_directory_uri(); ?>/js/jquery.js"></script>
	<script type="text/javascript" src="<?php echo get_template_directory_uri(); ?>/js/jquery.easing-sooper.js"></script>
	<script type="text/javascript" src="<?php echo get_template_directory_uri(); ?>/js/jquery.sooperfish.js"></script>
	<script type="text/javascript">
	$(document).ready(function() {
		$('ul.sf-menu').sooperfish();
		$('.top').click(function() {$('html, body').animate({scrollTop:0}, 'fast'); return false;});
	});
	</script>
	<?php wp_footer(); ?>
</body>
</html>