<?php
print '<?xml><playerScoreList>';

foreach ($players as $player){
    $username = $player->getUsername();
    $score = $player->getScore();

    print "<player><playerName>$username</playerName>";
    print "<score><$score</score>";
    print "</player>";
}

print '</playerScoreList>';
