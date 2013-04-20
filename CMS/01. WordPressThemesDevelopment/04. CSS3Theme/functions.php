<?php
$sidebar_args = array(
	'id' => 'right-sidebar',
	'name' => 'Right Sidebar'
);

register_sidebar($sidebar_args);

register_nav_menu('top-site-menu', 'Top site menu');
?>