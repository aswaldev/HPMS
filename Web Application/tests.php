<?php
   // Initialize the session
   session_start();

   // Check if the user is logged in, if not then redirect him to login page
   if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){
       header("location: index.php");
       exit;
   }
   require_once "config.php";
   $testname;
   $report;
   $status;
   $test_err="";
   $sql = "SELECT test_name, status, report FROM tests WHERE code = ? and number = ?";
   if($stmt = mysqli_prepare($link, $sql)){
        mysqli_stmt_bind_param($stmt, "ss", $_SESSION["code"], $_SESSION["number"]);
        if(mysqli_stmt_execute($stmt)){
            mysqli_stmt_store_result($stmt);
            if(mysqli_stmt_num_rows($stmt) >= 1){
                mysqli_stmt_bind_result($stmt, $testname,$status,$report);
            }
            else{
                $test_err="You have no pending tests";
            }
        }
        else{
            $test_err="cannot execute query";
        }
   }
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Test Status</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <table>
        <tr>
            <th>Test_name</th>
            <th>status</th>
            <th>Report</th>
        </tr>
        <?php
            while(mysqli_stmt_fetch($stmt)){
        ?>
        <tr>
            <td><?php echo $testname;?></td>
		    <td><?php echo $status;?></td>
			<td><a href="<?php 
                    if(strtolower($status)!="available")
                        echo "javascript: void(0)";
                    else
                        echo $report;
                    ?>">
                    <?php
                    if(strtolower($status)!="available")
                     echo "-";
                    else
                     echo "click here";
                    ?>
                </a>
            </td>
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

    <p><?php echo $test_err; ?></p></body>
</html>
