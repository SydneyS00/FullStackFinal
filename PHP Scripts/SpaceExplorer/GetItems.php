<?php

require 'ConnectionSettings.php';
//create the connection to log into the data base
// $servername = "localhost"; 
// $username = "root"; 
// $password = ""; 
// $dbname = "spaceexplorer"; 

//Variables from user
// $loginUser = $_POST["loginUser"]; 
// $loginPass = $_POST["loginPass"]; 

$planetID = $_POST["planetID"]; 

//Create a connection 
// $conn = new mysqli($servername, $username, $password, $dbname); 

//Check connection 
if($conn->connect_error)
{
    die("Connection failed: " . $conn->connect_error); 
}


$sql = "SELECT name, sundistance, earthdistance, temperature, atmosphere, moons, solarday, solaryear, coolfact FROM planets WHERE ID = '" . $planetID ."'"; 

$result = $conn->query($sql); 

if($result->num_rows > 0)
{
    $rows = array(); 

    while($row = $result->fetch_assoc())
    {
        $rows[] = $row; 
    }

    echo json_encode($rows); 
}
else
{
    echo "0"; 
}

$conn->close(); 


?>