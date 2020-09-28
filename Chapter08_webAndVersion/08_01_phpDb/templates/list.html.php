<!DOCTYPE html><html lang="en">
<ul>
    <?php foreach ($players as $player):
        $username = $player->getUsername();
        $score = $player->getScore();
    ?>
       <li><?= $username ?> = <?= $score ?>
    <?php endforeach ?>
</ul>
<hr><a href="index.php">home</a>