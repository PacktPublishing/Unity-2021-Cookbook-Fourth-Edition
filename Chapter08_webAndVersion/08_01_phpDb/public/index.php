<?php
require_once __DIR__ . '/../vendor/autoload.php';

use Mattsmithdev\WebApplication;

$app = new WebApplication();
$app->run();

/*
use Mattsmithdev\Database;

try{
    $db = new Database();
    print PHP_EOL;
    print 'success - connected to database';

    print '<hr>';
    print 'delete database table: products';
    $db->dropTableProducts();

    $db->createTableProducts();
    print '<hr>';
    print 'created database table: products';

    $db->insertProduct('hammer',66);
    $db->insertProduct('nail',244);
    $db->insertProduct('ladder',2);
    print '<hr>';
    print 'inserted items into database table: products';

    $products = $db->getAllProducts();
    print '<hr>';
    print 'num products = ' . sizeof($products);

    foreach($products as $product)
    {
        print $product;
    }

    print '<hr>';
    print '<hr>';
    print '<hr>';
    print 'delete database table: player';
    $db->dropTablePlayer();

    $db->createTablePlayer();
    print '<hr>';
    print 'created database table: player';


    $db->insertPlayer('matt', 500);
    $db->insertPlayer('jane', 101);
    $db->insertPlayer('jim', 99);
    $db->insertPlayer('amy-jane', 88);
    $db->insertPlayer('ray', 77);

    print '<hr>';
    print 'inserted items into database table: player';

    $players = $db->getAllPlayers();
    print '<hr>';
    print 'num players = ' . sizeof($players);

//    var_dump($players);

    foreach($players as $player)
    {
        print $player;
    }



} catch(\PDOException $e){
    print PHP_EOL;
    print 'error working with PDO database';
}

*/