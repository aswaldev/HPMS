<?php
   // Initialize the session
   session_start();
   // Check if the user is logged in, if not then redirect him to login page
   if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){
       header("location: index.php");
       exit;
   }
   $change_contact_err="";
   $change_email_err="";
   $change_pnumber_err="";
   require_once "config.php";
   if($_SERVER["REQUEST_METHOD"] == "POST"){
    $sql = "UPDATE patient SET ? = ? WHERE code = ? and number = ?";
       if(!empty(trim($_POST["new_number"]))){
            $column = "phone_number";
            $val = trim($_POST["new_number"]);
            if(preg_match("/^\+?0*(?:91-)?\K(?:91)?[6-9][0-9]{9}$/",$val)){
                $sql = "UPDATE patient SET phone_number = ? WHERE code = ? and number = ?";
            }
            else{
                $change_pnumber_err="please enter valid phone number";
            }
       }
       if(($stmt = mysqli_prepare($link, $sql)) && empty($change_pnumber_err)){
            mysqli_stmt_bind_param($stmt, "sss", $val ,$_SESSION["code"], $_SESSION["number"]);
            if(mysqli_stmt_execute($stmt)){
                mysqli_stmt_store_result($stmt);
            }
        }
        if(!empty(trim($_POST["new_email"]))){
            $column = "email";
            $val = trim($_POST["new_email"]);
            if(filter_var($val, FILTER_VALIDATE_EMAIL)) {
                $sql = "UPDATE patient SET email = ? WHERE code = ? and number = ?";
            }
            else{
                $change_email_err="please enter valid email";
            }
       }
       if(($stmt = mysqli_prepare($link, $sql)) && empty($change_email_err)){
            mysqli_stmt_bind_param($stmt, "sss", $val ,$_SESSION["code"], $_SESSION["number"]);
            if(mysqli_stmt_execute($stmt)){
                mysqli_stmt_store_result($stmt);
            }
        }
        if(!empty(trim($_POST["new_address"]))){
            $column = "address";
            $val = trim($_POST["new_address"]);
            $sql = "UPDATE patient SET address = ? WHERE code = ? and number = ?";
       }
       if($stmt = mysqli_prepare($link, $sql)){
            mysqli_stmt_bind_param($stmt, "sss", $val ,$_SESSION["code"], $_SESSION["number"]);
            if(mysqli_stmt_execute($stmt)){
                mysqli_stmt_store_result($stmt);
            }
        }
        else if(empty(trim($_POST["new_number"]))&&empty(trim($_POST["new_email"]))&&empty(trim($_POST["new_address"]))){
            $change_contact_err="please fill atleast one attribute to update";
        }
   }
   mysqli_close($link);
?>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>HPMS</title>
    <link rel="stylesheet" href="style.css">
    <link href="https://fonts.googleapis.com/css2?family=PT+Sans&display=swap" rel="stylesheet">
</head>
<body>
  <div class="up-form">
  	<form class="update-form" action="change_contact.php" method="post">
		<h2 class="form-title">Change Details</h2>
		<div class="form-group">
			<label>Change Number</label>
			<input type="text" name="new_number">
            <p><?php echo $change_pnumber_err;?></p>
		</div>
		<div class="form-group">
			<label>Change Email</label>
			<input type="text" name="new_email">
            <p><?php echo $change_email_err;?></p>
		</div>
        <div class="form-group">
			<label>Change Address</label>
			<textarea type="text" name="new_address" class="address" ></textarea>
		</div>
		<div class="form-group">
			<button type="submit" name="change_details" class="update-btn">Submit</button>
		</div>
        <p><?php echo $change_contact_err; ?></p>
	</form>
</div>

    <div class="dboard">
      <a href="dashboard.php">Home</a>
      <a href="appointment.php">Appointment</a>
      <a href="prescription.php">Prescription</a>
      <a href="tests.php">Tests</a>
      <a href="billing.php">Billing</a>
      <a href="Details.php">Details</a>
    </div>

      <div class="navbar">
       <a href="logout.php">Sign Out</a>
      </div>

</body>
</html>
