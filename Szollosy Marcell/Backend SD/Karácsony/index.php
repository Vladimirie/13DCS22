<!-- index.php -->
<?php
include 'db.php';

// Személyek lekérése
$persons = $pdo->query("SELECT * FROM persons")->fetchAll();
?>

<h1>Megajándékozandók</h1>

<!-- Új személy hozzáadása gomb -->
<a href="add_person.php">+ Új személy</a>
<hr>

<?php foreach ($persons as $person): ?>
    <h2><?= htmlspecialchars($person['name']) ?></h2>

    <!-- Ajándékok listája -->
    <?php
    $gifts = $pdo->prepare("SELECT * FROM gifts WHERE person_id = ?");
    $gifts->execute([$person['id']]);
    $gift_list = $gifts->fetchAll();
    ?>

    <?php if ($gift_list): ?>
        <ul>
        <?php foreach ($gift_list as $gift): ?>
            <li>
                <?= htmlspecialchars($gift['title']) ?>
                <?php if ($gift['image']): ?>
                    <br><img src="uploads/<?= htmlspecialchars($gift['image']) ?>" width="100">
                <?php endif; ?>

                <!-- Törlés link -->
                <a href="delete_gift.php?id=<?= $gift['id'] ?>" 
                   onclick="return confirm('Töröljük?')">[töröl]</a>
            </li>
        <?php endforeach; ?>
        </ul>
    <?php else: ?>
        <p><i>Nincs ajándék.</i></p>
    <?php endif; ?>

    <!-- Új ajándék hozzáadása gomb -->
    <a href="add_gift.php?person_id=<?= $person['id'] ?>">+ Új ajándék</a>

    <!-- Személy törlése -->
    <a href="delete_person.php?id=<?= $person['id'] ?>" 
       onclick="return confirm('Biztosan töröljük ezt a személyt és az összes ajándékát?')">[töröl személyt]</a>
    <hr>
<?php endforeach; ?>