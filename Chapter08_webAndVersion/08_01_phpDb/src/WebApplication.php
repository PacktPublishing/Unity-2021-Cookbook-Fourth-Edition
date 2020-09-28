<?php

namespace Mattsmithdev;


class WebApplication
{
    public function run()
    {
        $mainController = new MainController();
        $action = filter_input(INPUT_GET, 'action');
        $format = filter_input(INPUT_GET, 'format');

        switch($action){
            case 'reset':
                $mainController->resetDatabase();
                break;

            case 'get':
                $id = filter_input(INPUT_GET, 'username');
                $mainController->get($id, $format);
                break;

            case 'insert':
                $username = filter_input(INPUT_GET, 'username');
                $score = filter_input(INPUT_GET, 'score');
                $mainController->insert($username, $score);
                break;

            case 'update':
                $username = filter_input(INPUT_GET, 'username');
                $score = filter_input(INPUT_GET, 'score');
                $mainController->update($username, $score);
                break;

            case 'list':
                $mainController->listPlayers($format);
                break;

            default:
                $mainController->home();
        }
    }
}
