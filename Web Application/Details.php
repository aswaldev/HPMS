<?php
   // Initialize the session
   session_start();
   // Check if the user is logged in, if not then redirect him to login page
   if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){
       header("location: index.php");
       exit;
   }
   require_once "config.php";
   $email;
   $address;
   $p_number;
   $b_group;
   $dob;
   $sex;
   $height;
   $weight;
   $allergies;
   $e_c;
   $room_no;
   $in_date;
   $out_date;
   $appointment_err="";
   $sql = "select room_no,in_date,out_date,email, address, phone_number, blood_group, DOB, sex, height, weight, allergies, existing_conditions from patient inner join patient_record using (code, number) where code= ? and number = ?;";
   if($stmt = mysqli_prepare($link, $sql)){
        mysqli_stmt_bind_param($stmt, "ss", $_SESSION["code"], $_SESSION["number"]);
        if(mysqli_stmt_execute($stmt)){
            mysqli_stmt_store_result($stmt);
            if(mysqli_stmt_num_rows($stmt) >= 1){
                mysqli_stmt_bind_result($stmt ,$room_no,$in_date,$out_date,$email,$address,$p_number,$b_group,$dob,$sex,$height,$weight,$allergies,$e_c);
            }
            else{
                $appointment_err="You have no appointments";
            }
        }
        else{
            $appointment_err="cannot execute query";
        }
   }
   mysqli_close($link);
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
  <table class="dash">
      <?php
          while(mysqli_stmt_fetch($stmt)){
      ?>
      <tr>
          <th>Staying Room No.</th>
          <td><?php
                if($_SESSION["code"]=="OUP")
                    echo "NOT ASSIGNED";
                else
                    echo $room_no;
            ?>
          </td>
      </tr>
      <tr>
          <th>Admitted Date</th>
          <td><?php
                if($_SESSION["code"]=='OUP')
                    echo "NOT ASSIGNED";
                else
                    echo $in_date;
            ?>
          </td>
      </tr>
      <tr>
          <th>Discharge Date</th>
          <td><?php
                if($_SESSION["code"]=='OUP')
                    echo "NOT ASSIGNED";
                if($out_date==NULL)
                    echo "Patient still admitted";
                else
                    echo $out_date;
            ?>
          </td>
      </tr>
      <tr>
          <th>Blood Group</th>
          <td><?php echo $b_group;?></td>
      </tr>
      <tr>
          <th>Sex</th>
          <td><?php echo $sex;?></td>
      </tr>
      <tr>
          <th>Date Of Birth</th>
          <td><?php echo $dob;?></td>
      </tr>
      <tr>
          <th>Height</th>
          <td><?php echo $height;?></td>
      </tr>
      <tr>
          <th>Weight</th>
          <td><?php echo $weight;?></td>
      </tr>
      <tr>
          <th>Phone Number</th>
          <td><?php echo $p_number;?></td>
      </tr>
      <tr>
          <th>Email</th>
          <td><?php echo $email;?></td>
      </tr>
      <tr>
          <th>Address</th>
          <td><?php echo $address;?></td>
      </tr>
      <tr>
          <th>Allergies</th>
          <td><?php echo $allergies;?></td>
      </tr>
      <tr>
          <th>Existing Conditions</th>
          <td><?php echo $e_c;?></td>
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

    <button onclick="location.href = 'logout.php'" type="button" class ="signout">Sign Out</button>
</body>
</html>