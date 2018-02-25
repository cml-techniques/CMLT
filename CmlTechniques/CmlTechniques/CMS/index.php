<?php

ini_set("zend.ze1_compatibility_mode", 1);
ini_set("display_errors", 1);

if (!file_exists("config.inc.php")) {
	header("Location: install.php");
}


// HACK :-)
if (!file_exists("download.php")) {
	exit;
}


//------------------------------------------------------------------------------
// Installation Check

include('lic.php');
if ($domain != '' && !preg_match('/'.preg_quote($domain, '/').'$/', $_SERVER['HTTP_HOST'])) {
	die("Your document manager is setup to run on: $domain which is not you are using.");
}

if ($directory != '' && !preg_match('/'.preg_quote($directory, '/').'$/', dirname(__FILE__))) {
	die("Your document manager is setup to run under $directory folder. However you are using a folder name: " . basename(dirname($_SERVER['PHP_SELF'])));
}


if ($expire_date != '' && strtotime(preg_replace('/(\d{2})-(\d{2})-(\d{4})/', '\3-\1-\2', $expire_date)) < time()) {
	die("Your document manager is expired it was set to expire ".$expire_date);
}



//------------------------------------------------------------------------------
// Configuration

define("CONFIG_PATH", "config/");

require_once CONFIG_PATH."config.inc.php";

//------------------------------------------------------------------------------
// Modules

require_once INCLUDES_PATH."program.inc.php";

//------------------------------------------------------------------------------
// Debug

if (S_MODE == L_WORK) {
	ini_set("display_errors", 1);
}

//------------------------------------------------------------------------------
// Script Execution
$_POST["area"] = $_GET["area"] = $area = clean_file_name(getFormValue("area", "G", "main"));

$shell_class_path = SCRIPTS_PATH.$area."/class.inc.php";
if (S_MODE == L_WORK && !file_exists($shell_class_path)) {
	$_POST["area"] = $_GET["area"] = $area = "main";
	$shell_class_path = SCRIPTS_PATH.$area."/class.inc.php";
}
include_once $shell_class_path;

$app = new $area($DB, $pref, __FILE__, __LINE__);

$app -> run(__FILE__, __LINE__);

//var_dump($_SESSION);

my_exit();

?>