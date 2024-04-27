<?php
//create the connection to log into the data base
$servername = "localhost"; 
$username = "root"; 
$password = ""; 
$dbname = "spaceexplorer"; 

//Variables from user
$loginUser = $_POST["loginUser"]; 
$loginPass = $_POST["loginPass"]; 

//Create a connection 
$conn = new mysqli($servername, $username, $password, $dbname); 

//Check connection 
if($conn->connect_error)
{
    die("Connection failed: " . $conn->connect_error); 
}

$sql = "SELECT password, id FROM users WHERE username = '" . $loginUser ."'"; 

$result = $conn->query($sql); 

if($result->num_rows > 0)
{
    //output the data
    while($row = $result->fetch_assoc())
    {
        if($row["password"] == $loginPass)
        {
            echo $row["id"];

            //Get user data

            //Get player info

            //Get inventory

            //Modify player data
        } 
        else
        {
            echo "Wrong credentials, try again..."; 
        }
    }
}
else
{
    echo "Credentials do not exist..."; 
}

$conn->close(); 


?>