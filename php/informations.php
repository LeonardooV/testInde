<?php

global $db;
include "db.php";

if($_SERVER["REQUEST_METHOD"] == "POST") {
    $acheter = $_POST["acheter"];
    //die($acheter);
    $sql = "acheter FROM informations WHERE id =$acheter";
    $result = $db->query($sql);

    if ($result == false) {
        die("Une erreur est survenue lors de l'exécution de la requête: ".$db->error."($sql)");
    }
    else {
        echo"<p>La suppression a été effectuée avec succès.</p>";
    }
}

$q = @$_GET[""];
$sql = "SELECT * FROM `informations` WHERE salary_chf > 50000  ORDER BY salary_chf DESC;";
$result = $db->query($sql);


$q = @$_GET["q"];
$sql = "SELECT * FROM `informations` WHERE salary_chf > 5000  AND job_title LIKE '%{$q}%' ORDER BY salary_chf DESC ";
$result = $db->query($sql);




//Parcourir les données
$show_id=[];
while ($row = $result->fetch_assoc()) {
// Attribuez chaque colonne à une variable
    $id[] = $row["id"];
    $rating[] = $row["rating"];
    $company_name[] = $row["company_name"];
    $job_title[] = $row["job_title"];
    $salary[] = $row["salary"];
    $salaries_reported[] = $row["salaries_reported"];
    $location[] = $row["location"];
    $salary_chf[] = $row["salary_chf"];
    $image[] = $row["image"];


}






echo '<title>Informations sur les jobs</title>';

?>




<link href="style2.css" rel="stylesheet">

<link href="home_style.css" rel="stylesheet">
<nav class="nav2">
    <ul>
        <li><a href="home.php">Home</a></li>
    </ul>
</nav>


<form method="GET">
    <input type="search" name="q" placeholder="Recherche..." />
    <input type="submit" value="Valider" />
</form>

<?php
echo '<body>
        <h1 style="text-align: center">Informations sur les jobs</h1>
        <form>
    <table>
        <tr> 
            <th>Note</th>
            <th>nom de la compagnie</th>
            <th>titre de poste</th>
            <th>salaire</th>
            <th>salaire en rouble</th>
            <th>localité</th>
            <th>image</th>
        </tr>';

for ($i = 0; $i < sizeof($id); $i++) {
    ?>

    </tr>
    <td><?php echo $rating[$i]; ?></td>
    <td><?php echo $company_name[$i]; ?></td>
    <td><?php echo $job_title[$i]; ?></td>
    <td><?php echo $salary_chf[$i]; ?></>
    <td><?php echo $salary[$i]; ?></>
    <td><?php echo $location[$i]; ?></td>
    <td><?php echo "<img src='/images/{$image[$i]}' alt='image indisponible'>"; ?></td>
    <link href="style2.css" rel="stylesheet">

    <tr>
        <?php
}

    ?>


