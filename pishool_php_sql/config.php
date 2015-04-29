<?php 
//You have to fill in this information to connect to your database!
header("Content-Type: text/html; charset=UTF-8");
mysql_query("SET NAMES 'utf8'"); 
mysql_query('SET CHARACTER SET utf8');

		$db = mysql_connect('localhost', 'dbuserName', 'dbPassword') or die('Failed to connect: ' . mysql_error()); 
        mysql_select_db('pishoodb') or die('Failed to access database'. mysql_error());
		//mysql_query("SET NAMES utf8");
		//This is your key. You have to fill this in! Go and generate a strong one.
        $secretKey="aaaa";
?>