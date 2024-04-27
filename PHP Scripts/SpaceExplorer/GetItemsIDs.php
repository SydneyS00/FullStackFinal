<?php

require 'ConnectionSettings.php';
// $servername = "localhost"; 
// $username = "root"; 
// $password = ""; 
// $dbname = "spaceexplorer"; 

//create a new user submitted var
$userID = $_POST["userID"]; 


// //create a connection 
// $conn = new mysqli($servername, $username, $password, $dbname); 

//check creation 
if($conn->connect_error)
{
    die("Connection failed: " . $conn->connect_error); 
}

$sql = "SELECT planetID FROM userplanets WHERE userID = '" . $userID ."'"; ; 

$result = $conn->query($sql); 

if($result->num_rows > 0)
{
    //output the data 
    $rows = array(); 

    while($row = $result->fetch_assoc())
    {
        $rows[] = $row; 
    }

    echo json_encode($rows); 
}
else
{
     echo "0 results for items"; 
}

$conn->close(); 


?>