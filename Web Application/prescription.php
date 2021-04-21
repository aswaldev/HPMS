<?php
   // Initialize the session
   session_start();

   // Check if the user is logged in, if not then redirect him to login page
   if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){
       header("location: index.php");
       exit;
   }
   require_once "config.php";
   $details;
   $prescription_err="";
   $sql = "SELECT details FROM prescription WHERE code = ? and number = ?";
   if($stmt = mysqli_prepare($link, $sql)){
        mysqli_stmt_bind_param($stmt, "ss", $_SESSION["code"], $_SESSION["number"]);
        if(mysqli_stmt_execute($stmt)){
            mysqli_stmt_store_result($stmt);
            if(mysqli_stmt_num_rows($stmt) >= 1){
                mysqli_stmt_bind_result($stmt, $details);
            }
            else{
                $prescription_err="You have no prescription";
            }
        }
        else{
            $prescription_err="cannot execute query";
        }
   }
   mysqli_close($link);
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Prescription</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <table>
        <tr>
            <th>details</th>
        </tr>
        <?php
            while(mysqli_stmt_fetch($stmt)){
        ?>
        <tr>
            <td><?php echo $details;?></td>
        </tr>
        <?php
            }
        ?>
    </table>

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

    <p><?php echo $prescription_err; ?></p>
</body>
</html>
