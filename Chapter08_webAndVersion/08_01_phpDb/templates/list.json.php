<?php

$playersArray = [];
foreach($players as $player){
    $playersArray[] = $player->toArray();
}
print json_encode($playersArray);

