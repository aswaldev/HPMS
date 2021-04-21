<?php
   // Initialize the session
   session_start();

   // Check if the user is logged in, if not then redirect him to login page
   if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){
       header("location: index.php");
       exit;
   }
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
  <!-- <img src="universe.png" alt="dbg" class="dbg"> -->
  <div class="dboard">
    <a href="dashboard.php">Home</a>
    <a href="appointment.php">Appointment</a>
    <a href="prescription.php">Prescription</a>
    <a href="tests.php">Tests</a>
    <a href="billing.php">Billing</a>
    <a href="Details.php">Details</a>
  </div>

  <div class="navbar">
  <p class="hello">Hello, <?php echo $_SESSION["name"]; ?></p>
   <div class="dropdown">
     <button class="dropbtn">Edit Details
     </button>
     <div class="dropdown-content">
       <a href="change_password.php">Change Password</a>
       <a href="change_contact.php">Change Contact Details</a>
     </div>
   </div>
   <a href="logout.php">Sign Out</a>
  </div>

</body>
</html>
