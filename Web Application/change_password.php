<?php
// Initialize the session
session_start();
// Include config file
require_once "config.php";
// Define variables and initialize with empty values
$username ="";
$username_err="";
// Processing form data when form is submitted
if($_SERVER["REQUEST_METHOD"] == "POST"){
    // Check if username is empty
    if(empty(trim($_POST["username"]))){
        $username_err = "Please enter username.";
    } else{
        $username = trim($_POST["username"]);
    }
    $code = substr($username,0,3);
    $number = substr($username,-5);
    $question = "";
    // Validate credentials
    if(empty($username_err)){
        // Prepare a select statement
        $sql = "SELECT question FROM sec_question WHERE code = ? and number = ?";
        if($stmt = mysqli_prepare($link, $sql)){
            // Bind variables to the prepared statement as parameters
            mysqli_stmt_bind_param($stmt, "ss", $code, $number);
            // Attempt to execute the prepared statement
            if(mysqli_stmt_execute($stmt)){
                $result = $stmt->get_result();   // You get a result object now
                if($result->num_rows > 0) {     // Note: change to $result->...!
                    while ($data = $result->fetch_assoc()) {
                        $_SESSION["code"] = $code;
                        $_SESSION["number"] = $number;
                        $_SESSION["question"] = $data['question'];
                        header("location: new_pass.php");
                    }
                }
                else{
                    // Display an error message if username doesn't exist
                    $username_err = "No account found with that username.";
                }
            }
            else{
                echo "Oops! Something went wrong. Please try again later.";
            }
        }
        // Close statement
        mysqli_stmt_close($stmt);
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
    <div class="container">
        <p>Please Enter username</p>
        <div class="up">
          <form action="change_password.php" method="post">
              <input type="text" name="username" id="username">
              <p><?php echo $username_err; ?></p>
              <button type="submit" class="btn">Submit</button>
          </form>
        </div>
    </div>
    <script src="index.js"></script>
</body>
</html>
