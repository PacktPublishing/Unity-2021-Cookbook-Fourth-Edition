<?php

foreach ($players as $player):
    $username = $player->getUsername();
    $score = $player->getScore();

    print "$username = $score \n";
endforeach;
