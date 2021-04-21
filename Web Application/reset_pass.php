<?php
// Initialize the session
session_start();
if(!isset($_SESSION["code"])){
    header("location: index.php");
    exit;
}
// Include config file
require_once "config.php";
// Define variables and initialize with empty values
$answer = $password = $cpassword= $username= $question= "";
$answer_err = $password_err = $username_err= "";
// Processing form data when form is submitted
if($_SERVER["REQUEST_METHOD"] == "POST"){
    // Check if answer is empty
    if(empty(trim($_POST["dpassword"]))){
        $answer_err = "Please enter your default password.";
    } else{
        $dpassword = trim($_POST["dpassword"]);
    }
    // Check if password is empty
    if(empty(trim($_POST["newpass"]))){
        $password_err = "Please enter your password.";
    } else{
        $password = trim($_POST["newpass"]);
    }
    if(empty(trim($_POST["cnewpass"]))){
        $password_err = "Please confirm your password.";
    } else{
        $cpassword = trim($_POST["cnewpass"]);
    }
    if(empty(trim($_POST["question"]))){
        $answer_err = "question and answer cannot be empty.";
    } else{
        $question = trim($_POST["question"]);
    }
    if(empty(trim($_POST["answer"]))){
        $answer_err = "question and answer cannot be empty.";
    } else{
        $answer = trim($_POST["answer"]);
    }
    if(!preg_match("/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/",$cpassword)){ 
        $password_err = "Password must contain atleast one uppercase, lowercase character and number";
    }
    // Validate credentials
    if(empty($answer_err) && empty($password_err) && empty($username_err)){
        if($password==$cpassword){
            // Prepare a select statement
            $sql = "SELECT password FROM patient WHERE code = ? and number = ?";
            if($stmt = mysqli_prepare($link, $sql)){
                // Bind variables to the prepared statement as parameters
                mysqli_stmt_bind_param($stmt, "ss",$_SESSION["code"], $_SESSION["number"]);
                // Attempt to execute the prepared statement
                if(mysqli_stmt_execute($stmt)){
                    // Store result
                    mysqli_stmt_store_result($stmt);
                    // Check if answer exists, if yes then verify password
                    if(mysqli_stmt_num_rows($stmt) == 1){
                        // Bind result variables
                        mysqli_stmt_bind_result($stmt, $hashed_password);
                        if(mysqli_stmt_fetch($stmt)){
                            if($dpassword == $hashed_password){
                                // Password is correct, so update password and add security question
                                $sql = "UPDATE patient SET password = ? where code = ? and number = ?";
                                $hashed_password = password_hash($cpassword, PASSWORD_DEFAULT);
                                if($stmt = mysqli_prepare($link, $sql)){
                                    mysqli_stmt_bind_param($stmt, "sss", $hashed_password ,$_SESSION["code"], $_SESSION["number"]);
                                    if(mysqli_stmt_execute($stmt)){
                                        mysqli_stmt_store_result($stmt);
                                    }
                                }
                                $sql = "INSERT INTO sec_question (question, answer, code, number) values (?, ?, ?, ?)";
                                $hashed_answer = password_hash($answer, PASSWORD_DEFAULT);
                                if($stmt = mysqli_prepare($link, $sql)){
                                    mysqli_stmt_bind_param($stmt, "ssss",$question, $hashed_answer ,$_SESSION["code"], $_SESSION["number"]);
                                    if(mysqli_stmt_execute($stmt)){
                                        mysqli_stmt_store_result($stmt);
                                    }
                                }
                                header("location: logout.php");
                            }
                            else{
                            // Display an error message if password is not valid
                                $password_err = "The password you entered was not valid.";
                            }
                        }
                    }
                    else{
                    // Display an error message if answer doesn't exist
                    $answer_err = "No account found.";
                    }
                }
                else{
                echo "Oops! Something went wrong. Please try again later.";
                }
                mysqli_stmt_close($stmt);
            }
        }
        else{
            $password_err="new password and confirmed password do not match";
        }
    }
    // Close connection
    mysqli_close($link);
}
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
      <form action="reset_pass.php" method="post" class="update-form">
        <h2 class="form-title">Reset Password</h2>
            <div class="form-group">
              <label>Default Password</label><br>
              <input type="password" name="dpassword" class="passpagebox">
              <p><?php echo $password_err; ?></p>
            </div>
            <div class="form-group">
              <label>New Password</label><br>
              <input type="password" name="newpass" class="passpagebox">
            </div>
            <div class="form-group">
              <label>Confirm New Password</label><br>
              <input type="password" name="cnewpass" class="passpagebox">
              <p><?php echo $password_err; ?></p>
            </div>
            <div class="form-group">
              <label>Security Question</label><br>
              <input type="text" name="question" class="passpagebox">
            </div>
            <div class="form-group">
              <label>Answer</label><br>
              <input type="password" name="answer" class="passpagebox">
              <p><?php echo $answer_err; ?></p>
            </div>
              <button type="submit" class="btn">Submit</button>
          </form>
    </div>
    <script src="index.js"></script>
</body>
</html>
