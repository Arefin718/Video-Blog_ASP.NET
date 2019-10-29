<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
        <link href="bootstrap.min.css" type="text/css" rel="stylesheet">
</head>
<body>

<div class="container">
<button  class="btn btn-info btn-lg" onclick="login()">Login with out App</button>
<a class="btn btn-info  btn-lg" href="myvideos.php">My Videos</a>
</div>

<script>
   function login() {
       var APIKEY="0c63bb1aa988689c5782b968efd51d46";
       window.open("http://localhost:62210/API/Login/"+APIKEY,"contestrules", "menubar=0,resizable=0,width=350,height=350");
 }
</script>


<script src="bootstrap.min.js"></script>
<script src="jquery-3.2.1.js"></script>

</body>
</html>