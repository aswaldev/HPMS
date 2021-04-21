<?php
ob_start();
// Initialize the session
session_start();
// Check if the user is already logged in, if yes then redirect him to welcome page
if(isset($_SESSION["loggedin"]) && $_SESSION["loggedin"] === true){
    header("location: dashboard.php");
    exit;
}
// Include config file
require_once "config.php";
// Define variables and initialize with empty values
$username = $password = "";
$username_err = $password_err = "";
// Processing form data when form is submitted
if($_SERVER["REQUEST_METHOD"] == "POST"){

    // Check if username is empty
    if(empty(trim($_POST["username"]))){
        $username_err = "Please enter username.";
    } else{
        $username = trim($_POST["username"]);
    }
    // Check if password is empty
    if(empty(trim($_POST["password"]))){
        $password_err = "Please enter your password.";
    } else{
        $password = trim($_POST["password"]);
    }
    $code = substr($username,0,3);
    $number = substr($username,-5);
    // Validate credentials
    if(empty($username_err) && empty($password_err)){
        // Prepare a select statement
        $sql = "SELECT password, name FROM patient WHERE code = ? and number = ?";
        if($stmt = mysqli_prepare($link, $sql)){
            // Bind variables to the prepared statement as parameters
            mysqli_stmt_bind_param($stmt, "ss", $code, $number);
            // Attempt to execute the prepared statement
            if(mysqli_stmt_execute($stmt)){
                // Store result
                mysqli_stmt_store_result($stmt);
                // Check if username exists, if yes then verify password
                if(mysqli_stmt_num_rows($stmt) == 1){
                    // Bind result variables
                    mysqli_stmt_bind_result($stmt, $hashed_password, $name);
                    if(mysqli_stmt_fetch($stmt)){
                        if( ($password == $hashed_password) && !password_verify($password, $hashed_password)){
                            session_start();
                            $_SESSION["code"] = $code;
                            $_SESSION["number"] = $number;
                            header("location: reset_pass.php");
                            //$password_err = "Please reset password before first login";
                        }
                        elseif(password_verify($password, $hashed_password)){
                            // Password is correct, so start a new session
                            session_start();
                            // Store data in session variables
                            $_SESSION["loggedin"] = true;
                            $_SESSION["code"] = $code;
                            $_SESSION["number"] = $number;
                            $_SESSION["name"]=$name;
                             // Redirect user to welcome page
                            header("location: dashboard.php");
                        }
                        else{
                            // Display an error message if password is not valid
                            $password_err = "The password you entered was not valid.";
                        }
                    }
                }
                else{
                    // Display an error message if username doesn't exist
                    $username_err = "No account found with that username.";
                }
            } else{
                echo "Oops! Something went wrong. Please try again later.";
            }
            // Close statement
            mysqli_stmt_close($stmt);
        }
    }
    // Close connection
    mysqli_close($link);
}
ob_end_flush();
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
<!-- <img class="bg" src="universe.png" alt="default"> -->
    <div class="up-form">
      <form action="index.php" method="post" class="update-form">
        <h2 class="form-title">Welcome</h2>
        <p>Please Login</p>
            <div class="form-group">
              <input type="text" name="username" id="username" placeholder="username">
              <p><?php echo $username_err; ?></p>
            </div>
              <div class="form-group">
              <input type="password" name="password" id="password" placeholder="password">
              <p><?php echo $password_err; ?></p>
            </div>
            <div class="form-group">
              <button class="btn">Login</button><br>
              <a href="change_password.php">Reset/Forgot Password</a>
            </div>
          </form>
    </div>
    <script src="index.js"></script>
</body>
</html>
