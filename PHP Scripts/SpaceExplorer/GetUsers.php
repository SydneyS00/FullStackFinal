<?php

require 'ConnectionSettings.php';
//Get users script
// $servername = "localhost"; 
// $username = "root"; 
// $password = ""; 
// $dbname = "spaceexplorer"; 

// //Create a connection 
// $conn = new mysqli($servername, $username, $password, $dbname); 

//Check connection 
if($conn->connect_error)
{
    die("Connection failed: " . $conn->connect_error); 
}

$sql = "SELECT username, level FROM users"; 

$result = $conn->query($sql); 

if($result->num_rows > 0)
{
    echo "Connected sucessfully, now we will show the users."; 
    //output the data
    while($row = $result->fetch_assoc())
    {
        echo "username: ".$row["username"]."<br>level: ".$row["level"]."<br>"; 
    }
}
else
{
    echo "0 results"; 
}

$conn->close(); 


?>